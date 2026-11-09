using UnityEngine;

namespace Assets.Scripts.Game.OtherGameObject.CheckingClothing.ChestofDrawerType
{
    /// <summary>
    /// 靴下を取り出せるチェストのクラス
    /// </summary>
    public class ShoesChest : ChestofDrawers
    {
        /// <summary>
        /// playerがタンスに触れた瞬間に発動する、靴下のタンスの仮想関数
        /// </summary>
        /// <param name="myclothe">playerの衣類</param>
        public override void ObjectAction(OwnedClothing myclothe)
        {
            Debug.Log("靴下のチェストに触れた");

            base.ObjectAction(myclothe);

            Clothes = new Clothes(ColorState.None, ClothingType.Shoes);

            myclothe.AddClothing(Clothes);
        }
    }
}