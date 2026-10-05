//色に数字を割り当てて足し算の合計で変えす色を変える
//if文で片方の色がNoneならをのまま返す
using UnityEngine;

/// <summary>
/// 色コード定義
/// </summary>
public enum GameColor
{
    None,
    Red,
    Blue,
    Yellow,
    Purple,
    Green,
    Orange
}

/// <summary>
/// 色変換クラス
/// </summary>
public class ColorChanger : MonoBehaviour
{
    /// <summary>
    /// 色変換関数
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static GameColor Mix(GameColor a, GameColor b) => (a, b) switch
    {
        (GameColor.Red, GameColor.Blue) or (GameColor.Blue, GameColor.Red) => GameColor.Purple,
        (GameColor.Blue, GameColor.Yellow) or (GameColor.Yellow, GameColor.Blue) => GameColor.Green,
        (GameColor.Red, GameColor.Yellow) or (GameColor.Yellow, GameColor.Red) => GameColor.Orange,
        _ => GameColor.None,
    };

}
