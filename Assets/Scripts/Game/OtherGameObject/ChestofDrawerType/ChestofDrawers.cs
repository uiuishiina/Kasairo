using UnityEngine;
/// <summary>
/// OtherObjectを継承した全てのチェストの基底クラス
/// </summary>
public class ChestofDrawers : OtherObject
{
    public override void ObjectAction(OwnedClothing myclothe)
    {
        Debug.Log("チェストに触れた");
    }
}
