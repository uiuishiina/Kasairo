using Assets.Scripts.Game.Player;
using UnityEngine;
/// <summary>
/// ミシンのクラス
/// </summary>
public class SewingMachine : MachineObject, DotJudge
{
    public override void ObjectAction()
    {
        Debug.Log("ミシンに触れた!");
    }
}
