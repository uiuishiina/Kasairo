using UnityEngine;
/// <summary>
/// OtherObjectを継承した全てのチェストの基底クラス
/// </summary>
public class ChestofDrawers : OtherObject
{
    [SerializeField]
    protected ClothingType Clothes;
    void Start()
    {
        Clothes = ClothingType.Hat;
    }
    //public override void ObjectAction(OwnedClothing myclothe)
    //{
    //    Debug.Log("帽子のチェストに触れた");

    //    myclothe.AddClothing(Clothes);
    //}
}
