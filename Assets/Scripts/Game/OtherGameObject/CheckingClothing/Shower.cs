using Assets.Utility.Time;
using UnityEngine;

namespace Assets.Scripts.Game.OtherGameObject.CheckingClothing
{
    /// <summary>
    /// シャワーのクラス
    /// </summary>
    public class Shower : CheckClothingObject
    {
        float DebuffTime = 0;//playerの移動速度が下がる時間

        ShowerColor ShowerColor;

        void Awake()
        {
            ShowerColor = GetComponent<ShowerColor>();
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent<PlayerMoveInput>(out var player))
            {
                player.EnterWaterDebuff(ShowerColor.CurrentColor);
            }
            if (other.gameObject.TryGetComponent<OwnedClothing>(out var Cloth))
            {
                //服を持っていなかったらここで処理が終わる
                if (!Check(Cloth))
                {
                    Debug.Log("服持ってないよ");
                    return;
                }
                Debug.Log("服持ってるよ");    
                if(ShowerColor.CurrentColor == PrimaryColorState.None)
                {
                    Cloth.ClearShower();
                }
                else
                {
                    Cloth.ShowerEnter(ShowerColor.CurrentColor);
                }
            }
        }

        void OnTriggerStay(Collider other)
        {
            if (DebuffTime >= 5)
            {
                DebuffTime = 5;
            }
            else
            {
                DebuffTime += GameTime.FixedDeltaTime;
            }
        }

        void OnTriggerExit(Collider other)
        {
            int time = Mathf.RoundToInt(DebuffTime) * 2;

            if (other.gameObject.TryGetComponent<PlayerMoveInput>(out var player))
            {
                player.ExitWaterDebuff(time);
            }

            DebuffTime = 0;
        }
    }
}