using UnityEngine;

namespace Assets.Scripts.Game.OtherGameObject.CheckingClothing.ChestofDrawerType
{
    /// <summary>
    /// OtherObjectを継承した全てのチェストの基底クラス
    /// </summary>
    public class ChestofDrawers : CheckClothingObject
    {
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