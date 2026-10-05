using System;
using UnityEngine;
using UnityEngine.Audio;
using Assets.Scripts.StaticObject;

namespace Assets.Scripts.Audio
{
    public class AudioManager : StaticObject<AudioManager>
    {
        [SerializeField] AudioMixer AudioMixer;//全体の音量調整

        [SerializeField] AudioSource BGMAudioSource;//BGMの再生

        [SerializeField] AudioSource SEAudioSource;//SEの再生


        [SerializeField] float BGMVolume;

        [SerializeField] float SEVolume;

        [SerializeField] float MasterVolume;

        /// <summary>
        /// SEの再生
        /// </summary>
        /// <param name="clip">再生する曲</param>
        public void PlaySE(AudioClip clip)
        {
            if (clip == null) return;

            SEAudioSource.PlayOneShot(clip);
        }
        /// <summary>
        /// BGMの再生
        /// </summary>
        /// <param name="clip">再生する曲</param>
        public void PlayBGM(AudioClip clip)
        {
            BGMAudioSource.clip = clip;
            BGMAudioSource.Play();
        }
        /// <summary>
        /// BGMの停止
        /// </summary>
        public void StopBGM()
        {
            BGMAudioSource.Stop();
        }
        /// <summary>
        /// SEの音量調整,Sliderから操作
        /// </summary>
        public void ChangeSEVolume()
        {

        }
        /// <summary>
        /// BGMの音量調整,Sliderから操作
        /// </summary>
        public void ChangeBGMVolume()
        {

        }
        /// <summary>
        /// Masterの音量調整,Sliderから操作
        /// </summary>
        public void ChangeMasterVolume()
        {

        }

    }
}
