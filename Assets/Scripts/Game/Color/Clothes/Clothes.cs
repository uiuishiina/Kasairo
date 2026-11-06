using System.Runtime.CompilerServices;
using UnityEngine;

public class Clothes : MonoBehaviour
{
    /// <summary>
    /// 現在の色
    /// </summary>
    [SerializeField] private ColorState paintedColor;

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

    private ClothingPainter clothingPainter;

    public Clothes(ColorState paintedColor,ClothingType clothingType)
    {
        this.paintedColor = paintedColor;
        this.clothingType = clothingType;
    }

    private void Awake()
    {
        if (!TryGetComponent(out clothingPainter))
            Debug.LogError($"{name}: ClothingPainter がありません", this);
    }

    /// <summary>
    /// シャワーの色を引数として持ってきて現在の服の色と混ぜて更新する
    /// </summary>
    /// <param name="color">シャワーの色が入る</param>
    public void PaintColor(PrimaryColorState color)
    {
        paintedColor = ColorMixer.MixedColor(paintedColor, color);

        if (clothingPainter != null) return;
        clothingPainter.PaintClothing(paintedColor);
    }
}
