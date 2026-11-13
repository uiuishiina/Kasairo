using UnityEngine;

public static class ColorJudge
{

    /// <summary>
    /// 色判定関数
    /// </summary>
    /// <param name="current"></param>
    /// <param name="color"></param>
    /// <returns>同色ならTure</returns>
    public static bool JudgeColor(ColorState current, ColorState color)
    {
        //if(current == ColorState.None)
        //{
        //    return true;
        //}
        return (current & color) != 0;
    }

    /// <summary>
    /// ShowerColor判定オーバーロード
    /// </summary>
    /// <param name="current"></param>
    /// <param name="color"></param>
    /// <returns>同色、または基底色ならTrue</returns>
    public static bool JudgeColor(ColorState current, PrimaryColorState color)
    {
        return JudgeColor(current,(ColorState)color);
    }
}
