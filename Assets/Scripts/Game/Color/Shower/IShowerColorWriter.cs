/// <summary>
/// シャワーの色を変更するためのインターフェース
/// </summary>
public interface IShowerColorWriter
{
    /// <summary>
    /// シャワーの色変更関数
    /// </summary>
    /// <param name="c">変更後の色</param>
    void SetColor(PrimaryColorState c);
}