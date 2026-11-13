using UnityEngine;
/// <summary>
/// 音量データ
/// </summary>
[CreateAssetMenu(fileName = "VolumeDeta", menuName = "Scriptable Objects/VolumeDeta")]
public class VolumeDeta : ScriptableObject
{
    [Range(0f, 1f), Header("全体の現在の音量")] public float MasterVolume;
    [Range(0f, 1f),Header("BGMの現在の音量")] public float BGMVolume;
    [Range(0f, 1f),Header("SEの現在の音量")] public float SEVolume;

}
