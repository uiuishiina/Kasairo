using UnityEngine;

namespace Assets.Scripts.Game.OtherGameObject.CheckingClothing.ChestofDrawerType
{
    /// <summary>
    /// ズボンを取り出せるチェストのクラス
    /// </summary>
    public class PantsChest : ChestofDrawers
    {
        /// <summary>
        /// playerがタンスに触れた瞬間に発動する、ズボンのタンスの仮想関数
        /// </summary>
        /// <param name="myclothe">playerの衣類</param>
        public override void ObjectAction(OwnedClothing myclothe)
        {
            Debug.Log("ズボンのチェストに触れた");

            base.ObjectAction(myclothe);

            Clothes = new Clothes(ColorState.None, ClothingType.Pants);

            myclothe.AddClothing(Clothes);
        }
    }
}