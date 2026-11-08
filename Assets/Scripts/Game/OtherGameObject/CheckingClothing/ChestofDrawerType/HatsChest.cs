using UnityEngine;

namespace Assets.Scripts.Game.OtherGameObject.CheckingClothing.ChestofDrawerType
{
    /// <summary>
    /// 帽子を取り出せるチェストのクラス
    /// </summary>
    public class HatsChest : ChestofDrawers
    {
        public override void ObjectAction(OwnedClothing myclothe)
        {
            Debug.Log("帽子のチェストに触れた");

            base.ObjectAction(myclothe);

            Clothes = new Clothes(ColorState.None, ClothingType.Hat);

            myclothe.AddClothing(Clothes);
        }
    }
}