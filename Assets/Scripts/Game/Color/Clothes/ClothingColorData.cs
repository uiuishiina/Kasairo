using UnityEngine;
using R3;

public class ClothingColorData : MonoBehaviour
{
    // この服の種類の設定
    ClothingData clothingData;
    // 確定している色
    SerializableReactiveProperty<ColorState> confirmedColor;
    //基本色ごとの進行度
    SerializableReactiveProperty<float> redPaintedRatio;
    SerializableReactiveProperty<float> bluePaintedRatio;
    SerializableReactiveProperty<float> yellowPaintedRatio;
}
