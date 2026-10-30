using UnityEngine;

/// <summary>
/// 衣服類で違うデータ
/// </summary>
[CreateAssetMenu(fileName = "ClothingData", menuName = "Scriptable Objects/ClothingData")]
public class ClothingData : ScriptableObject
{
    /// <summary>
    ///  何秒で１００％になるか（衣服の種類ごとで塗る進行速度が変わる）
    /// </summary>
    [SerializeField, Min(0.01f)] private float fillDuration = 3f;
    public float FillDuration => fillDuration;
}
