using Assets.Scripts.Game.Player;
using UnityEngine;
/// <summary>
/// シャワーのクラス
/// </summary>
public class Shower : OtherObject
{
    public override void ObjectAction()
    {
        Debug.Log("シャワーに触れた");
    }
}
