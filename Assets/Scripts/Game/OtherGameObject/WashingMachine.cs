using UnityEngine;
/// <summary>
/// 洗濯機のクラス
/// </summary>
public class WashingMachine: OtherObject
{
    public override void ObjectAction()
    {
        Debug.Log("洗濯機に触れた!");
    }
}
