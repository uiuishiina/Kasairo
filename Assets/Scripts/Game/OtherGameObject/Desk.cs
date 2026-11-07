using UnityEngine;
/// <summary>
/// 机のクラス
/// </summary>
public class Desk : OtherObject
{
    public override void ObjectAction(OwnedClothing myclothe)
    {
        if(Clothes!=null&&myclothe.OwnedClothes!=null)
        {
            Debug.Log("机に服が置いてあるからこれ以上置けへん");
            return;
        }
        else if (myclothe.OwnedClothes == null&& Clothes == null)
        {
            myclothe.AddClothing(Clothes);
            Debug.Log("机から服を取った");
        }
        else if (myclothe.OwnedClothes != null)
        {
            Clothes = myclothe.OwnedClothes;
            myclothe.RemoveClothing();
            Debug.Log("机に服を置いた");
        }
    }
}
