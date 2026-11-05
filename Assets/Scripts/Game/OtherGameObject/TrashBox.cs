using UnityEngine;

public class TrashBox : OtherObject
{
    public override void ObjectAction(OwnedClothing myclothe)
    {
        Debug.Log("ƒSƒ~” ‚ÉŽÌ‚Ä‚Ü‚µ‚½");

        myclothe.RemoveClothing();
    }
}
