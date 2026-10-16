using UnityEngine;

/// <summary>
/// 色のbit定義と実際の色を紐づけ
/// </summary>
[CreateAssetMenu(fileName = "GameColor", menuName = "Scriptable Objects/GameColor")]
public class GameColor : ScriptableObject
{
    /// <summary>
    /// インスペクタから色を変える
    /// </summary>
    [SerializeField] private Color NoneColor = new Color { };
    [SerializeField] private Color RedColor = new Color { };
    [SerializeField] private Color BlueColor = new Color { };
    [SerializeField] private Color PurpleColor = new Color { };
    [SerializeField] private Color YellowColor = new Color { };
    [SerializeField] private Color OrangeColor = new Color { };
    [SerializeField] private Color GreenColor = new Color { };
    [SerializeField] private Color BlackColor = new Color { };

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
            ColorState.None => NoneColor,
            ColorState.Red => RedColor,
            ColorState.Blue => BlueColor,
            ColorState.Purple => PurpleColor,
            ColorState.Yellow => YellowColor,
            ColorState.Orange => OrangeColor,
            ColorState.Green => GreenColor,
            ColorState.Black => BlackColor,
            _ => throw new System.ArgumentOutOfRangeException(nameof(index))
        };
        private set {}
    }

}
