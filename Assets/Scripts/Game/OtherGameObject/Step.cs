using Assets.Scripts.Game.Player;
using DG.Tweening;
using UnityEngine;
/// <summary>
/// 段差のクラス
/// </summary>
public class Step : OtherObject
{
    const float YOffSet = 1.0f;

    public override void ObjectAction(PlayerInputController player)
    {
        Debug.Log("段差に触れた！");

        Collider mycol = GetComponent<Collider>();

        float topY = mycol.bounds.max.y;

        Vector3 targetpos = new Vector3(transform.position.x,topY + YOffSet,transform.position.z);

        player.ExecuteStepJump(targetpos);
    }
}
