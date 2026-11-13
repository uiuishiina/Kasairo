using UnityEngine;

namespace Assets.Scripts.Game.OtherGameObject.CheckingClothing.ChestofDrawerType
{
    /// <summary>
    /// シャツを取り出せるチェストのクラス
    /// </summary>
    public class ShirtsChest : ChestofDrawers
    {
        /// <summary>
        /// playerがタンスに触れた瞬間に発動する、シャツのタンスの仮想関数
        /// </summary>
        /// <param name="myclothe">playerの衣類</param>
        public override void ObjectAction(OwnedClothing myclothe)
        {
            Debug.Log("シャツのチェストに触れた");

            base.ObjectAction(myclothe);

            Clothes = new Clothes(ColorState.None, ClothingType.Shirt);

            myclothe.AddClothing(Clothes);
        }
    }
}