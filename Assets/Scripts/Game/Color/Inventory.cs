using System.Collections.Generic;
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
    private Queue<GameObject> inventory;

    /// <summary>
    /// queueの長さを決める
    /// </summary>
    private void Awake()
    {
        inventory = new Queue<GameObject>(inventorySize);
    }
    
    /// <summary>
    /// queueに衣服類を追加(先だし後入れ）＋
    /// </summary>
    /// <param name="clothes">衣服類のobj</param>
    /// <returns>追加できたか</returns>
    public bool EnqueueInventory(GameObject clothes)
    {
        if (inventory.Count >= inventorySize) return false;
        inventory.Enqueue(clothes);
        return true;
    }

    /// <summary>
    /// queueの衣服類を取り出す
    /// </summary>
    /// <returns>queueの先頭の衣服類obj</returns>
    public bool DequeueInventory()
    {
        return inventory.Dequeue();
    }

    /// <summary>
    /// queueに追加消去の通知　R3でする
    /// </summary>
    private void NotifyInventoryChanged()
    {

    }
}
