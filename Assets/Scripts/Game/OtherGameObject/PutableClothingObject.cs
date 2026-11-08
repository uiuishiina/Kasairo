using UnityEngine;

public class PutableClothingObject : OtherObject
{
    protected void Check(OwnedClothing ownedClothing)
    {
        Clothes it = ownedClothing.OwnedClothes;

        if(it != null&&Clothes==null)
        {
            Clothes = it;

            ownedClothing.RemoveClothing();
        }
        else if(it==null&&Clothes!=null)
        {
            ownedClothing.AddClothing(Clothes);
        }
    }
}
