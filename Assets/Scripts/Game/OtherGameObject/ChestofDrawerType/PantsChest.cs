using UnityEngine;
/// <summary>
/// ズボンを取り出せるチェストのクラス
/// </summary>
public class PantsChest : ChestofDrawers
{
    public override void ObjectAction(OwnedClothing myclothe)
    {
        Debug.Log("ズボンのチェストに触れた");

        Clothes = new Clothes(ColorState.None, ClothingType.Pants);

        myclothe.AddClothing(Clothes);
    }
}
