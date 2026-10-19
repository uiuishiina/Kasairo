using UnityEngine;
using R3;

/// <summary>
/// R3を使用したシャワーの色を変更、シャワーの色を取得するInterfaceを実装したスクリプト
/// </summary>
public class ShowerColorHolder : MonoBehaviour, IShowerColorReader, IShowerColorWriter
{
    /// <summary>
    /// Inspectorから確認変更が可能なReactiveProperty(値の変更時、購読中の相手へ通知する）変数
    /// </summary>
    [SerializeField] private SerializableReactiveProperty<PrimaryColorState> showerColor = new(PrimaryColorState.None);

    /// <summary>
    /// 購読用の変数
    /// </summary>
    public ReadOnlyReactiveProperty<PrimaryColorState> ShowerColor => showerColor;

    /// <summary>
    /// シャワーの色変更関数
    /// </summary>
    /// <param name="c">変更後の色</param>
    public void SetColor(PrimaryColorState c) => showerColor.Value = c;

    /// <summary>
    /// Destroyしたとき発信を終了し購読者との繋がりを切る
    /// </summary>
    void OnDestroy() => showerColor.Dispose();
}
