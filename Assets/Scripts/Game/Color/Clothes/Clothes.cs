using UnityEngine;

/// <summary>
/// ���ɂ���F�Ǝ�ނ����N���X
/// </summary>
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

    /// <summary>
    /// コンストラクタ　このクラスをnewしたとき初期値を設定する
    /// </summary>
    /// <param name="paintedColor">服の色</param>
    /// <param name="clothingType">服の種類</param>
    public Clothes(ColorState paintedColor,ClothingType clothingType)
    {
        this.paintedColor = paintedColor;
        this.clothingType = clothingType;
    }

    /// <summary>
    /// シャワーの色を引数として持ってきて現在の服の色と混ぜて更新する
    /// </summary>
    /// <param name="color">シャワーの色が入る</param>
    public void PaintColorClothes(PrimaryColorState color)
    {
        paintedColor = ColorMixer.MixedColor(paintedColor, color);


        Debug.Log(paintedColor);
    }

    public void ClearColor()
    {
        paintedColor = ColorMixer.Clear();
    }
}
