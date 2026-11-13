/// <summary>
/// 色変換クラス(Bit演算で）
/// </summary>
public static class ColorMixer
{
    /// <summary>
    /// 色を混ぜる
    /// </summary>
    /// <param name="a">一つ目の色</param>
    /// <param name="b">二つ目の色</param>
    /// <returns>引数の色を混ぜた色</returns>
    public static ColorState MixedColor(ColorState a, ColorState b)
    {
        //  orでbit演算
        var col = a | b;

        return col;
    }

    /// <summary>
    /// PrimaryColorStateでも色を混ぜる関数を使えるようにするためのオーバーロード
    /// </summary>
    /// <param name="current">服の確定済みの色</param>
    /// <param name="add">シャワーに濡れて100％になった色</param>
    /// <returns>元の関数MixedColorと一緒</returns>
    public static ColorState MixedColor(ColorState current, PrimaryColorState add)
    {
        return MixedColor(current, (ColorState)add);
    }

    /// <summary>
    /// 色のリセット
    /// </summary>
    /// <returns>白色</returns>
    public static ColorState Clear()
    {
        return ColorState.None;
    }
}
