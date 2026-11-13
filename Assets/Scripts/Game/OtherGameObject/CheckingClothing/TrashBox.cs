using UnityEngine;

namespace Assets.Scripts.Game.OtherGameObject.CheckingClothing
{
    /// <summary>
    /// ゴミ箱のクラス
    /// </summary>
    public class TrashBox : CheckClothingObject
    {
        /// <summary>
        /// playerが衣類を持っていたら捨てる関数
        /// </summary>
        /// <param name="myclothe">playerの衣類</param>
        public override void ObjectAction(OwnedClothing myclothe)
        {
            if (!Check(myclothe)) return;//playerが衣類を持っていなかったらここで終わり

            Debug.Log("ゴミ箱に捨てました");

            myclothe.RemoveClothing();
        }
    }
}