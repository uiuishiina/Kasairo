using UnityEngine;

namespace Assets.Scripts.Game.OtherGameObject.CheckingClothing
{
    /// <summary>
    /// 納品をするクラス
    /// </summary>
    public class Delivery : CheckClothingObject
    {
        /// <summary>
        /// 納品をする関数
        /// </summary>
        /// <param name="ownedClothing"></param>
        public override void ObjectAction(OwnedClothing ownedClothing)
        {
            if (!Check(ownedClothing)) return;//playerが衣類を持っていなかったらここで終わり

            Debug.Log("納品しました");

            Clothes = ownedClothing.OwnedClothes;//playerが衣類を渡す

            ownedClothing.RemoveClothing();
        }
    }
}