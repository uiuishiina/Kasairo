using UnityEngine;
/// <summary>
/// ミシンのクラス
/// </summary>
public class SewingMachine : OtherObject
{
    [SerializeField]
    private float CoolTime = 10.0f;

    public override void ObjectAction()
    {
        Debug.Log("ミシンに触れた!");
    }
}
