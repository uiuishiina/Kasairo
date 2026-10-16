//  色に数字を割り当ててbit演算で色を返す
using UnityEngine;

/// <summary>
/// 色変換クラス
/// </summary>
public class ColorChanger : MonoBehaviour
{
    /// <summary>
    /// 色を混ぜる
    /// </summary>
    /// <param name="a">一つ目の色</param>
    /// <param name="b">二つ目の色</param>
    /// <param name="c">三つ目の色</param>
    /// <returns>引数の色を混ぜた色</returns>
    static public ColorState MixedColor(ColorState a, ColorState b, ColorState c = ColorState.None)
    {
        //  orでbit演算
        var col = a | b | c;

        //  黒に割り当てているbitよりも大きければ黒
        if (col >= ColorState.Black) col = ColorState.Black;

        return col;
    }

    /// <summary>
    /// 色のリセット
    /// </summary>
    /// <returns>白色</returns>
    static public ColorState ClearNone()
    {
        return ColorState.None;
    }
}
