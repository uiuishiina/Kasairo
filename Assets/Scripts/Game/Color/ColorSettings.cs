using UnityEngine;

/// <summary>
/// 色のbit定義と実際の色を紐づけ
/// </summary>
[CreateAssetMenu(fileName = "ColorSettings", menuName = "Scriptable Objects/ColorSettings")]
public class GameColor : ScriptableObject
{
    /// <summary>
    /// インスペクタから色を変える
    /// </summary>
    [SerializeField] private Color noneColor;
    [SerializeField] private Color redColor;
    [SerializeField] private Color blueColor;
    [SerializeField] private Color purpleColor;
    [SerializeField] private Color yellowColor;
    [SerializeField] private Color orangeColor;
    [SerializeField] private Color greenColor;
    [SerializeField] private Color blackColor;

    /// <summary>
    /// インスペクタで設定した色とScriptableObjectのbit定義を紐づけ
    /// </summary>
    /// <param name="index">ColorStateがbit定義,=>Colorが実際の色</param>
    /// <returns></returns>
    /// <exception cref="System.ArgumentOutOfRangeException">範囲外の引数による例外</exception>
    public Color this[ColorState index]
    {
        get => index switch
        {
            ColorState.None => noneColor,
            ColorState.Red => redColor,
            ColorState.Blue => blueColor,
            ColorState.Purple => purpleColor,
            ColorState.Yellow => yellowColor,
            ColorState.Orange => orangeColor,
            ColorState.Green => greenColor,
            ColorState.Black => blackColor,
            _ => throw new System.ArgumentOutOfRangeException(nameof(index))
        };
    }

}