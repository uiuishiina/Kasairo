using UnityEngine;
/// <summary>
/// 帽子を取り出せるチェストのクラス
/// </summary>
public class HatsChest : ChestofDrawers
{
    public override void ObjectAction(OwnedClothing myclothe)
    {
        Debug.Log("帽子のチェストに触れた");

        Clothes = new Clothes(ColorState.None, ClothingType.Hat);

        myclothe.AddClothing(Clothes);
    }
}
