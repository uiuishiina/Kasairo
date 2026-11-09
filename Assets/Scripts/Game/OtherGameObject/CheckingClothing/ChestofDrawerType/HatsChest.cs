using UnityEngine;

namespace Assets.Scripts.Game.OtherGameObject.CheckingClothing.ChestofDrawerType
{
    /// <summary>
    /// 帽子を取り出せるチェストのクラス
    /// </summary>
    public class HatsChest : ChestofDrawers
    {
        /// <summary>
        /// playerがタンスに触れた瞬間に発動する、帽子が入っているタンスの仮想関数
        /// </summary>
        /// <param name="myclothe">playerの衣類</param>
        public override void ObjectAction(OwnedClothing myclothe)
        {
            Debug.Log("帽子のチェストに触れた");

            base.ObjectAction(myclothe);

            Clothes = new Clothes(ColorState.None, ClothingType.Hat);

            myclothe.AddClothing(Clothes);
        }
    }
}