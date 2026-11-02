using UnityEngine;

/// <summary>
/// ˆß•—Ş‚ÌƒCƒ“ƒxƒ“ƒgƒŠ
/// </summary>
public class OwnedClothing : MonoBehaviour
{
    //  ˆê’…‚µ‚©‚Ä‚È‚¢
    [SerializeField] private Clothes ownedClothes;

    public bool AddClothing(Clothes newClothes)
    {
        if (ownedClothes != null) return false;
        ownedClothes = newClothes;
        
        return true;
    }

    public bool RemoveClothing()
    {
        if (ownedClothes == null) return false;
        ownedClothes = null;
        return true;
    }

    public void ShowerEnter(PrimaryColorState showerColor)
    {
        if (ownedClothes != null) ownedClothes.PaintColor(showerColor);
    }
}
