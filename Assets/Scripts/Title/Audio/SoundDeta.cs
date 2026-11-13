using UnityEngine;

[CreateAssetMenu(fileName = "SoundDeta", menuName = "Scriptable Objects/SoundDeta")]
public class SoundDeta : ScriptableObject
{
    [Range(0, 1)] public float Volume; // クリップの音量
    public AudioClip Clip; // クリップの参照
}
