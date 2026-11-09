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
                //衣類を持っていたらここで衣類の色が変わる
                if (Check(player.PlayerInputController.PlayerClothing))
                {
                    player.PlayerInputController.ShowerEnter(ShowerColor.CurrentColor);
                }

                player.EnterWaterDebuff();
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