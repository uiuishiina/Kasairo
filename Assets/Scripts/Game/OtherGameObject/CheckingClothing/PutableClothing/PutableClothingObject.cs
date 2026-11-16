using UnityEngine;

namespace Assets.Scripts.Game.OtherGameObject.CheckingClothing.PutableClothingObject
{
    /// <summary>
    /// CheckClothingObjectを継承した、衣類を置く、または入れたり、衣類を取り出すクラスの親クラス
    /// </summary>
    public class PutableClothingObject : CheckClothingObject
    {
        protected ClothesModel model;

        /// <summary>
        /// 服所持確認関数
        /// </summary>
        /// <returns></returns>
        protected bool HasClothes()
        {
            return model != null;
        }

        /// <summary>
        /// 服設置関数
        /// </summary>
        /// <param name="ownedClothing"></param>
        /// <returns></returns>
        protected bool PutCloth(OwnedClothing ownedClothing)
        {
            model = ownedClothing.Model;//playerが衣類を渡す

            Debug.Log("衣類を置いた");

            ownedClothing.RemoveClothing();

            return true;
        }

        /// <summary>
        /// 服取得関数
        /// </summary>
        /// <param name="ownedClothing"></param>
        /// <returns></returns>
        protected bool GetCloth(OwnedClothing ownedClothing)
        {
            //playerに衣類がなくて、且つ机やミシン、洗濯機に衣類がある時

            Debug.Log("衣類を取った");

            ownedClothing.AddClothing(model);//playerに衣類を渡す

            model = null;

            return true;
        }

    }
}