using UnityEngine;

namespace Assets.Scripts.Game.OtherGameObject.CheckingClothing.ChestofDrawerType
{

    public class ChestObject : CheckClothingObject
    {
        [SerializeField] ColorState state_ = ColorState.None;
        [SerializeField] ClothingType type_ = ClothingType.None;
        [SerializeField] Material _material;
        public override void ObjectAction(OwnedClothing myclothe)
        {
            if(myclothe.HasOwnedClothes){
                Debug.Log("服所持済み");
                return;
            }

            Clothes cloth = new Clothes(state_, type_);
            ClothesModel model = new ClothesModel(_material, cloth);

            Debug.Log("Create");
            myclothe.AddClothing(model);
        }
    }
}