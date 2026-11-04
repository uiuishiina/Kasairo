using UnityEngine;
/// <summary>
/// 納品をするクラス
/// </summary>
public class Delivery : OtherObject
{
    public override void ObjectAction()
    {
        Debug.Log("納品しました");
    }
}
