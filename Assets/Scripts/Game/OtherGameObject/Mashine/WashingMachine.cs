using UnityEngine;
/// <summary>
/// ô‘ó‹@‚ÌƒNƒ‰ƒX
/// </summary>
public class WashingMachine: MachineObject
{
    public override void ObjectAction(OwnedClothing ownedClothing)
    {
        if (iscool())
        {
            Debug.Log("‚Ü‚¾ô‘ó‚µ‚Ä‚¢‚éÅ’†‚â");
            return;
        }

        Check(ownedClothing);

        if (Clothes==null) return;

        Clothes.PaintColor(PrimaryColorState.None);
    }
}
