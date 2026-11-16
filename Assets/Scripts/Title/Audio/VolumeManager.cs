using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Audio
{
    /// <summary>
    /// 音量調整用UIにアタッチするクラス
    /// </summary>
    public class VolumeManager : MonoBehaviour
    {
        [Header("音量調整用のslider")]
        [SerializeField, Header("全体音量")] private Slider MasterSlider;

        [SerializeField, Header("BGM音量")] private Slider BGMSlider;

        [SerializeField, Header("SE音量")] private Slider SESlider;

        void Start()
        {
            // 現在の音量をスライダーに反映させる
            MasterSlider.value = AudioManager.Instance_.GetMasterVolume();
            BGMSlider.value = AudioManager.Instance_.GetBGMVolume();
            SESlider.value = AudioManager.Instance_.GetSEVolume();

            // スライダーの値が変更されたときに音量を変更するリスナーを追加
            MasterSlider.onValueChanged.AddListener(AudioManager.Instance_.SetMasterVolume);
            BGMSlider.onValueChanged.AddListener(AudioManager.Instance_.SetBGMVolume);
            SESlider.onValueChanged.AddListener(AudioManager.Instance_.SetSEVolume);
        }
    }
}


