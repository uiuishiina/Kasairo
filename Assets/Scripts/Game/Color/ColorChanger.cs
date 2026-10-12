//色に数字を割り当てて足し算の合計で変えす色を変える
using UnityEngine;

/// <summary>
/// 色変換クラス
/// </summary>
public class ColorChanger : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="data"></param>
    static public ColorState MixedColor(ColorState a, ColorState b, ColorState c = ColorState.None)
    {

        var col = a | b | c;

        if (col >= ColorState.Black) col = ColorState.Black;

        return col;
    }

    static public ColorState ClearNone()
    {
        return ColorState.None;
    }
}
