using UnityEngine;

/// <summary>
/// 衣服を持つか捨てるか
/// </summary>
public class OwnedClothing : MonoBehaviour
{
    [SerializeField] private Clothes ownedClothes;

    /// <summary>
    /// 衣服を持つ
    /// </summary>
    /// <param name="newClothes">Clothesがついているオブジェクト</param>
    /// <returns>持てたかどうか</returns>
    public bool AddClothing(Clothes newClothes)
    {
        if (ownedClothes != null) return false;
        ownedClothes = newClothes;
        
        return true;
    }

    /// <summary>
    /// 衣服を捨てる
    /// </summary>
    /// <returns>衣服を捨てたか持っていなくて捨てれないか</returns>
    public bool RemoveClothing()
    {
        if (ownedClothes == null) return false;
        ownedClothes = null;
        return true;
    }

    /// <summary>
    /// シャワーに入った時持っている服にシャワーの色を渡す
    /// </summary>
    /// <param name="showerColor">シャワーの色</param>
    public void ShowerEnter(PrimaryColorState showerColor)
    {
        if (ownedClothes != null) ownedClothes.PaintColor(showerColor);
    }
}
