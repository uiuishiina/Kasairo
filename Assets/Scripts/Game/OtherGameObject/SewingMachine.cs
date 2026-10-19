using Assets.Scripts.Game.Player;
using UnityEngine;
/// <summary>
/// ミシンのクラス
/// </summary>
public class SewingMachine : MachineObject, DotJudge
{
    public override void ObjectAction(PlayerInputController player)
    {
        Debug.Log("ミシンに触れた!");

        float dot = Dot(player.transform.position,this.transform);

        if(dot > DotJudge.Front)
        {
            Debug.Log("そして前にいる！");
        }
        else
        {
            Debug.Log("でも前にはいないんよな～");
        }
    }

    float Dot(Vector3 targetpos, Transform fromtransform)
    {
        Vector3 pos = (targetpos - fromtransform.position).normalized;

        float dot = Vector3.Dot(fromtransform.forward, pos);

        return dot;
    }
}
