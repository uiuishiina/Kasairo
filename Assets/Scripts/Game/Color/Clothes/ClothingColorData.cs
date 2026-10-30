using UnityEngine;
using R3;
using Assets.Utility.Time;

public class ClothingColorData : MonoBehaviour
{
    // この服の種類の設定
    private ClothingData clothingData;
    // 確定している色
    private ColorState confirmedColor;
    //基本色ごとの進行度
    [Range(0, 1), SerializeField, Min(0.01f)] private float redPaintedRatio;
    [Range(0, 1), SerializeField, Min(0.01f)] private float bluePaintedRatio;
    [Range(0, 1), SerializeField, Min(0.01f)] private float yellowPaintedRatio;

    private void Update()
    {
        Mathf.Clamp01(redPaintedRatio += GameTime.DeltaTime / clothingData.FillDuration);
    }


    private void ConfirmedColor(ColorState confirmedColor)
    {

    }
}
