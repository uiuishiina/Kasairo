using System.Runtime.CompilerServices;
using UnityEngine;

public class Clothes
{
    /// <summary>
    /// 現在の色
    /// </summary>
    private ColorState paintedColor;

    /// <summary>
    /// 現在の色の読み取り専用プロパティ
    /// </summary>
    public ColorState PaintedColor => paintedColor;

    /// <summary>
    /// 服の種類
    /// </summary>
    private ClothingType clothingType;

    /// <summary>
    /// 服の種類の読み取り専用プロパティ
    /// </summary>
    public ClothingType CurrentClothingType => clothingType;

    public Clothes(ColorState paintedColor,ClothingType clothingType)
    {
        this.paintedColor = paintedColor;
        this.clothingType = clothingType;
    }

    /// <summary>
    /// シャワーの色を引数として持ってきて現在の服の色と混ぜて更新する
    /// </summary>
    /// <param name="color">シャワーの色が入る</param>
    public void PaintColor(PrimaryColorState color)
    {
        paintedColor = ColorMixer.MixedColor(paintedColor, color);
    }
}
