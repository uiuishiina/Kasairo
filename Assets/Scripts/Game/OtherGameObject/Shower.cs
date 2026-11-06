using Assets.Utility.Time;
using UnityEngine;
/// <summary>
/// シャワーのクラス
/// </summary>
public class Shower : OtherObject
{
    float DebuffTime = 0;

    ShowerColor ShowerColor;

    void Awake()
    {
        ShowerColor = GetComponent<ShowerColor>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<PlayerMoveInput>(out var player))
        {
            player.EnterWaterDebuff(ShowerColor.CurrentColor);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if(DebuffTime >= 5)
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

        if(other.gameObject.TryGetComponent<PlayerMoveInput>(out var player))
        {
            player.ExitWaterDebuff(time);
        }

        DebuffTime = 0;
    }
}
