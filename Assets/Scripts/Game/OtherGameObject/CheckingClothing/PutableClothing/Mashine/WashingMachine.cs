using UnityEngine;

namespace Assets.Scripts.Game.OtherGameObject.CheckingClothing.PutableClothingObject.Mashine
{
    /// <summary>
    /// ô‘ó‹@‚ÌƒNƒ‰ƒX
    /// </summary>
    public class WashingMachine : MachineObject
    {
        public override void ObjectAction(OwnedClothing ownedClothing)
        {
            Check(ownedClothing);

            if (Clothes == null)
            {
                Debug.Log("•‚ª‚È‚¢");
                return;
            }

            if (iscool())
            {
                Debug.Log("‚Ü‚¾ô‘ó‚µ‚Ä‚¢‚éÅ’†‚â");
                return;
            }


            Clothes.PaintColor(PrimaryColorState.None);
        }
    }
}