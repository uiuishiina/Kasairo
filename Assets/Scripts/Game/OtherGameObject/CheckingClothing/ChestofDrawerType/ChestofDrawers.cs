using UnityEngine;

namespace Assets.Scripts.Game.OtherGameObject.CheckingClothing.ChestofDrawerType
{
    /// <summary>
    /// OtherObjectを継承した全てのチェストの基底クラス
    /// </summary>
    public class ChestofDrawers : CheckClothingObject
    {
        /// <summary>
        /// playerがタンスに触れた瞬間に発動する、全てのタンスに共通した処理をさせる仮想関数
        /// </summary>
        /// <param name="myclothe">playerの衣類</param>
        public override void ObjectAction(OwnedClothing myclothe)
        {
            if (Check(myclothe))
            {
                Debug.Log("だが服が持てない");
                return;
            }
        }
    }
}