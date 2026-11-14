using UnityEngine;

namespace Assets.Scripts.Game.OtherGameObject
{
    /// <summary>
    /// 洗濯機やシャワー、ミシン等の基底クラス
    /// </summary>
    [RequireComponent(typeof(Rigidbody))]
    public class OtherObject : MonoBehaviour
    {
        //CheckClothingObjectやその派生先で使う、衣類のデータを保持する変数
        protected ClothesModel Clothes;
        public virtual void ObjectAction(OwnedClothing myclothe)
        {
            Debug.Log("何に触れた?");
        }

        private void Awake()
        {
        }
    }
}


