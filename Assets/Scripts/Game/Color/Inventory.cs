using System.Collections.Generic;
using R3;
using UnityEngine;

/// <summary>
/// 衣服類のインベントリ
/// </summary>
public class Inventory : MonoBehaviour
{
    /// <summary>
    /// queueの長さ
    /// </summary>
    [SerializeField] private int inventorySize;

    /// <summary>
    /// 衣服類を入れるqueue（固定長）
    /// </summary>
    private Queue<ClothingColorData> inventory;

    /// <summary>
    /// 通知を流す元
    /// </summary>
    private readonly Subject<Unit> changed = new();

    public Observable<Unit> OnChanged => changed;

    /// <summary>
    /// queueの長さを決める
    /// </summary>
    private void Awake() => inventory = new Queue<ClothingColorData>(inventorySize);
    
    /// <summary>
    /// queueに衣服類を追加(先入れ先出し）＋
    /// </summary>
    /// <param name="clothes">衣服類のobj</param>
    /// <returns>追加できたか</returns>
    public bool EnqueueInventory(ClothingColorData clothes)
    {
        if (clothes == null || inventory.Count >= inventorySize) return false;
        inventory.Enqueue(clothes);
        NotifyInventoryChanged();
        return true;
    }

    /// <summary>
    /// queueの衣服類を取り出す
    /// </summary>
    /// <returns>queueの先頭の衣服類obj</returns>
    public bool TryDequeueInventory(out ClothingColorData clothes)
    {
        if (!inventory.TryDequeue(out clothes)) return false;
        inventory.TryDequeue(out clothes);
        return true;
    }

    /// <summary>
    /// 中身が変わったことを通知
    /// </summary>
    private void NotifyInventoryChanged()　=> changed.OnNext(Unit.Default);

    private void OnDestroy() => changed.Dispose();
}
