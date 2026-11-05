using UnityEngine;

public class Clothes : MonoBehaviour
{
    /// <summary>
    /// 確定している色
    /// </summary>
    [SerializeField] private ColorState paintedColor = ColorState.None;

    /// <summary>
    /// 確定している色の読み取り専用プロパティ
    /// </summary>
    public ColorState PaintedColor => paintedColor;

    /// <summary>
    /// 服の種類
    /// </summary>
    [SerializeField] private ClothingType clothingType = ClothingType.Shirt;

    /// <summary>
    /// 服の種類の読み取り専用プロパティ
    /// </summary>
    public ClothingType CurrentClothingType => clothingType;

    /// <summary>
    /// シャワーの色を引数として持ってきて現在の服の色と混ぜて更新する
    /// </summary>
    /// <param name="color">シャワーの色が入る</param>
    public void PaintColor(PrimaryColorState color)
    {
        paintedColor = ColorMixer.MixedColor(paintedColor, color);
        //GetComponent<Renderer>().material.color = paintedColor;
        Debug.Log(paintedColor);
    }
}
