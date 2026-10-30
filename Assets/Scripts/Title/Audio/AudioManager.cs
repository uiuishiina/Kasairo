using UnityEngine;
using UnityEngine.Audio;
using System.Collections.Generic;
using Assets.Scripts.StaticObject;
using NUnit.Framework;
using Cysharp.Threading.Tasks;
using System.Threading.Tasks;

namespace Assets.Scripts.Audio
{
    /// <summary>
    /// オーディオ管理
    /// </summary>
    public class AudioManager : MonoBehaviour//StaticObject<AudioManager>....テスト用(実際はStaticObjectを継承する)
    {
        public static AudioManager Instance_;

        [SerializeField] AudioSource BGMAudioSource;//BGM再生用

        [SerializeField] AudioMixer AudioMixer;//AudioMixerの参照(全体の音量を制御できる)

        [SerializeField, Header("現在の音量データと曲が入っているScriptableObject")] private VolumeDeta VolumeDeta;//現在の音量データと曲が入っているScriptableObject
        private Queue<int> SEAudioSourceIndexQueue = new Queue<int>();//SE再生用AudioSourceのインデックスを格納するキュー

        [SerializeField]private SEIndex[] SESource;//SE再生用AudioSourceとインデックス


        private void Awake()
        {

            //テスト用(実際はStaticObjectを継承する)
            if (Instance_ == null)
            {
                Instance_ = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
                return;
            }
        }

        private void Start()
        {
            //現在設定されている音量をAudioMixerに反映させる
            SetMasterVolume(VolumeDeta.MasterVolume);
            SetBGMVolume(VolumeDeta.BGMVolume);
            SetSEVolume(VolumeDeta.SEVolume);

            //キューの初期化
            SEAudioSourceIndexQueue.Clear();
            //AudioSourceのインデックスをキューに格納
            for (int i = 0; i < SESource.Length; i++)
            {
                SESource[i].Index = i;
                SEAudioSourceIndexQueue.Enqueue(i);
            }
        }

        //-------------------------------音楽再生---------------------------------//

        /// <summary>
        /// SEの再生
        /// </summary>
        public async Task PlaySE(SoundDeta clip)
        {
            if (clip == null) return;
            
            if(!SEAudioSourceIndexQueue.TryDequeue(out int index))
            {
                return;
            }
            else
            {
                SESource[index].SEAudioSources.PlayOneShot(clip.Clip, clip.Volume);
                //SE再生が終わるまで待機
                await UniTask.WaitUntil(() => !SESource[index].SEAudioSources.isPlaying);
                //SE再生が終わったらAudioSourceのインデックスをキューに戻す
                SEAudioSourceIndexQueue.Enqueue(SESource[index].Index);
            }
        }

        /// <summary>
        /// BGMの再生
        /// </summary>
        /// <param name="clip">再生する曲</param>
        /// <param name="awake">ゲーム開始時にならすか</param>
        /// <param name="loop">ループ再生するか</param>
        public void PlayBGM(AudioClip clip, bool awake, bool loop)
        {
            //再生する曲が設定されていない場合抜ける
            if (clip == null) return;
            //同じ曲が再生中なら抜ける
            if (BGMAudioSource.clip == clip && BGMAudioSource.isPlaying) return;

            BGMAudioSource.clip = clip;
            BGMAudioSource.playOnAwake = awake;//trueなら開始時にならす
            BGMAudioSource.loop = loop;//trueならループ再生する
            BGMAudioSource.Play();
        }
        /// <summary>
        /// BGMの停止
        /// </summary>
        public void StopBGM()
        {
            BGMAudioSource.Stop();
        }


        //--------------------------------音量設定---------------------------------//

        /// <summary>
        /// マスター音量の設定
        /// </summary>
        /// <param name="volume">音量</param>
        public void SetMasterVolume(float volume)
        {
            volume = Mathf.Clamp(volume, 0.001f, 1f);

            VolumeDeta.MasterVolume = volume;

            AudioMixer.SetFloat("Master", Mathf.Log10(volume) * 20);
        }
        /// <summary>
        /// BGM音量の設定
        /// </summary>
        /// <param name="volume">音量</param>
        public void SetBGMVolume(float volume)
        {
            volume = Mathf.Clamp(volume, 0.001f, 1f);

            VolumeDeta.BGMVolume = volume;

            AudioMixer.SetFloat("BGM", Mathf.Log10(volume) * 20);
        }
        /// <summary>
        /// SE音量の設定
        /// </summary>
        /// <param name="volume">音量</param>
        public void SetSEVolume(float volume)
        {
            volume = Mathf.Clamp(volume, 0.001f, 1f);

            VolumeDeta.SEVolume = volume;

            AudioMixer.SetFloat("SE", Mathf.Log10(volume) * 20);
        }
        /// <summary>
        /// 現在のマスター音量を取得
        /// </summary>
        /// <returns>Master音量</returns>
        public float GetMasterVolume()
        {
            return VolumeDeta.MasterVolume;
        }
        /// <summary>
        /// 現在のBGM音量を取得
        /// </summary>
        /// <returns>BGM音量</returns>
        public float GetBGMVolume()
        {
            return VolumeDeta.BGMVolume;
        }
        /// <summary>
        /// 現在のSE音量を取得
        /// </summary>
        /// <returns>SE音量</returns>
        public float GetSEVolume()
        {
            return VolumeDeta.SEVolume;
        }
    }
}
