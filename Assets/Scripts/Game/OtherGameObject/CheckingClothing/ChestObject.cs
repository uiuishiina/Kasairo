using UnityEngine;

namespace Assets.Scripts.Game.OtherGameObject.CheckingClothing.ChestofDrawerType
{

    public class ChestObject : CheckClothingObject
    {
        [SerializeField] ClothingType type_ = ClothingType.None;
        [SerializeField] Material _material;
        public override void ObjectAction(OwnedClothing myclothe)
        {
            Clothes cloth = new Clothes(ColorState.None, type_);
            ClothesModel model = new ClothesModel(_material, cloth);

            Debug.Log("Create");
            myclothe.AddClothing(model);
        }
    }
}