using Assets.Scripts.StaticObject;
using Assets.Utility.Time;
using UnityEngine;

namespace Assets.Scripts.Game.OtherGameObject.CheckingClothing
{
    /// <summary>
    /// シャワーのクラス
    /// </summary>
    public class Shower : CheckClothingObject
    {
        [SerializeField] float DebuffTime = 0;//playerの移動速度が下がる時間

        ShowerColor ShowerColor;
        ParticleSystem _particleSystem;

        void Start()
        {
            ShowerColor = GetComponent<ShowerColor>();
            _particleSystem = GetComponentInChildren<ParticleSystem>();

            var renderer = _particleSystem.GetComponent<ParticleSystemRenderer>();

            Material material = renderer.material;
            material.color = StaticColorManager.Instance_.ColorSettings[(ColorState)ShowerColor.CurrentColor];
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent<PlayerMoveInput>(out var player))
            {
                player.EnterWaterDebuff();
                Debug.Log("速度低下");
            }
            if (other.gameObject.TryGetComponent<OwnedClothing>(out var Cloth))
            {
                //服を持っていなかったらここで処理が終わる
                if (!Check(Cloth))
                {
                    Debug.Log("服Model 未所持");
                    return;
                }

                Debug.Log("服Model 所持済み");
                if (ShowerColor.CurrentColor == PrimaryColorState.None)
                {
                    Cloth.ClearShower();
                    Debug.Log("Clear Shower");
                }
                else
                {
                    Cloth.ShowerEnter(ShowerColor.CurrentColor);
                    Debug.Log("Paint Shower");
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