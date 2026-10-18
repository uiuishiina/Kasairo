using Assets.Scripts.Game.Player;
using UnityEngine;
/// <summary>
/// 洗濯機やシャワー、ミシン等の基底クラス
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class OtherObject : MonoBehaviour
{
    public virtual void ObjectAction()
    {
        Debug.Log("何に触れた?");
    }

    public virtual void ObjectAction(PlayerInputController player)
    {
        Debug.Log("何に触れた?");
    }
}
