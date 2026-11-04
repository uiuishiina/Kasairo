using Assets.Scripts.Game.Player;
using UnityEngine;
/// <summary>
/// ミシンのクラス
/// </summary>
public class SewingMachine : MachineObject
{
    public override void ObjectAction()
    {
        Debug.Log("ミシンに触れた!");

        cool();
    }
}
