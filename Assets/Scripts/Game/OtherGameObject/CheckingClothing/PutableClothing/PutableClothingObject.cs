using UnityEngine;

namespace Assets.Scripts.Game.OtherGameObject.CheckingClothing.PutableClothingObject
{
    /// <summary>
    /// CheckClothingObjectを継承した、衣類を置く、または入れたり、衣類を取り出すクラスの親クラス
    /// </summary>
    public class PutableClothingObject : CheckClothingObject
    {
        /// <summary>
        /// playerが衣類を持っているかどうかと机やミシン、洗濯機に衣類があるかどうかを判定する関数
        /// </summary>
        /// <param name="ownedClothing">playerの衣類</param>
        /// <returns>こっちでは戻り値はほぼ飾りなので気にしなくていい</returns>
        protected override bool Check(OwnedClothing ownedClothing)
        {
            Clothes it = ownedClothing.OwnedClothes;

            if (it != null && clothes == null)//playerに衣類があって、且つ机やミシン、洗濯機に衣類がない時
            {
                clothes = ownedClothing.Model;//playerが衣類を渡す

                Debug.Log("衣類を置いた");

                ownedClothing.RemoveClothing();
            }
            else if (it == null && clothes != null)//playerに衣類がなくて、且つ机やミシン、洗濯機に衣類がある時
            {
                Debug.Log("衣類を取った");

                ownedClothing.AddClothing(clothes);//playerに衣類を渡す

                clothes = null;
            }

            return true;
        }
    }
}