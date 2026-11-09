using UnityEngine;

namespace Assets.Scripts.Game.OtherGameObject.CheckingClothing.PutableClothingObject.Mashine
{
    /// <summary>
    /// 洗濯機のクラス
    /// </summary>
    public class WashingMachine : MachineObject
    {
        /// <summary>
        /// playerが洗濯機に触れた瞬間に発動する、洗濯機側の仮想関数
        /// </summary>
        /// <param name="ownedClothing">playerの衣類</param>
        public override void ObjectAction(OwnedClothing ownedClothing)
        {
            Check(ownedClothing);

            if (Clothes == null)
            {
                Debug.Log("服がない");
                return;
            }

            if (iscool())
            {
                Debug.Log("まだ洗濯している最中や");
                return;
            }


            Clothes.PaintColor(PrimaryColorState.None);
        }
    }
}