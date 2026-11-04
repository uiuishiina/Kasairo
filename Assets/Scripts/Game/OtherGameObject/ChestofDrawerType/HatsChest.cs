using UnityEngine;
/// <summary>
/// 帽子を取り出せるチェストのクラス
/// </summary>
public class HatsChest : ChestofDrawers
{
    public override void ObjectAction()
    {
        Debug.Log("帽子のチェストに触れた");
    }
}
