using R3;

/// <summary>
/// シャワーの色を参照・購読するためのインターフェース
/// </summary>
public interface IShowerColorReader
{
    ReadOnlyReactiveProperty<PrimaryColorState> ShowerColor { get; }
}