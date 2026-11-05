using UnityEngine;
/// <summary>
/// 帽子を取り出せるチェストのクラス
/// </summary>
public class HatsChest : ChestofDrawers
{
    Clothes Clothes;

    void Start()
    {
        Clothes = GetComponent<Clothes>();
    }
    public override void ObjectAction(OwnedClothing myclothe)
    {
        Debug.Log("帽子のチェストに触れた");

        myclothe.AddClothing(Clothes);
    }
}
