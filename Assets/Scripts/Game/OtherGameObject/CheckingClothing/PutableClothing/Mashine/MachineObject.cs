using Assets.Utility.Time;
using UnityEngine;

namespace Assets.Scripts.Game.OtherGameObject.CheckingClothing.PutableClothingObject.Mashine
{
    /// <summary>
    /// OtherObjectを継承した、ミシンや洗濯機に共通した変数や関数をまとめたクラス
    /// </summary>
    public class MachineObject : PutableClothingObject
    {
        //機械を使ったときのクールタイム
        [SerializeField]
        protected float CoolTime = 10.0f;
        [SerializeField]
        protected float time = 0;

        protected bool iscool()
        {
            if (time > 0)
            {
                return true;
            }

            time = CoolTime;

            return false;
        }

        public override void ObjectAction(OwnedClothing ownedClothing)
        {
            if (iscool())
            {
                Debug.Log("まだ使えへんで");
                return;
            }
            Check(ownedClothing);
        }

        private void Update()
        {
            if (time <= 0)
            {
                time = 0;
            }
            else
            {
                time -= GameTime.DeltaTime;
            }
        }
    }
}