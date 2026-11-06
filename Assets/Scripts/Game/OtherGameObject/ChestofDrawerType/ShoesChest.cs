using UnityEngine;
/// <summary>
/// 靴下を取り出せるチェストのクラス
/// </summary>
public class ShoesChest : ChestofDrawers
{
    public override void ObjectAction(OwnedClothing myclothe)
    {
        Debug.Log("靴下のチェストに触れた");

        Clothes = new Clothes(ColorState.None, ClothingType.Shoes);

        myclothe.AddClothing(Clothes);
    }
}
