using UnityEngine;

public class ClothingColorData : MonoBehaviour
{
    //基本色ごとの進行度
    [SerializeField, Range(0f, 1f)] private float redPaintedRatio;
    [SerializeField, Range(0f, 1f)] private float bluePaintedRatio;
    [SerializeField, Range(0f, 1f)] private float yellowPaintedRatio;
}
