using UnityEngine;
using UnityEngine.InputSystem;
using Assets.Scripts.Game.OtherGameObject;
using Assets.Scripts.Game.OtherGameObject.CheckingClothing;
using Assets.Scripts.Game.OtherGameObject.CheckingClothing.ChestofDrawerType;
/// <summary>
/// playerがミシンなどのオブジェクトに触れたときの処理だけがあるクラス
/// </summary>
public class PlayerAttackInput 
{
    readonly Transform P_Body;

    readonly float P_Range;

    readonly OwnedClothing OwnedClothing;
    /// <summary>
    /// この関数内で、PlayerAttackInput内のAttackActionにInputAction内のPlayerの中にあるAttackというActionが代入され、引数に入れたBodyがPlayerAttackInput内のP_Bodyに代入される
    /// </summary>
    /// <param name="body">Playerの体として定義しているもの</param>
    public PlayerAttackInput(Transform body,float range,OwnedClothing myclothe)
    {
        P_Body = body;

        P_Range = range;

        OwnedClothing = myclothe;
    }
    /// <summary>
    /// InputAction内のAttackに登録してあるキーを押すことによってAttack関数が処理される
    /// </summary>
    /// <param name="cont">登録したキーの入力値</param>
    public void Attack(InputAction.CallbackContext cont)
    {
        var obj = DotJudge.Dot(P_Body,P_Range);

        if (obj==null) return;

        var otherobj = obj.GetComponent<OtherObject>();

        if (otherobj == null) return;

        otherobj.ObjectAction(OwnedClothing);
    }
}
