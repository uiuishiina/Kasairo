using Assets.Scripts.Game.GameUI.Equipped;
using UnityEngine;

/// <summary>
/// 服の所持状況
/// </summary>
public class OwnedClothing : MonoBehaviour
{
    /// <summary>
    /// 服のデータを持つ変数
    /// </summary>
    public ClothesModel ownedClothes = null;

    /// <summary>
    /// 服のデータを参照する変数
    /// </summary>
    public Clothes OwnedClothes => ownedClothes._clothes;

    public ClothesModel Model => ownedClothes;

    public bool HasOwnedClothes => ownedClothes != null;

    private Renderer _clothesRenderer = null;

    //  服がないときのマテリアル
    [SerializeField] Material NoneMaterial = null;

    private void Start()
    {
        //  とりあえずBodyから
        _clothesRenderer = GetComponentInChildren<Renderer>();
        _clothesRenderer.material = NoneMaterial;
    }

    /// <summary>
    /// 服の所持
    /// </summary>
    /// <param name="newClothes">Clothesがついているオブジェクト</param>
    /// <returns>持てたかどうか</returns>
    public bool AddClothing(ClothesModel newClothes)
    {
        if (HasOwnedClothes) return false;

        ownedClothes = newClothes;
        Debug.Log($"新規取得 : 取得した種類{ownedClothes._clothes.CurrentClothingType}");

        //  マテリアル上書き
        _clothesRenderer.material = ownedClothes.Marerial;

        EquippedUIManager.Instance.RightEquipped.ChangeClothes(OwnedClothes);

        return true;
    }

    /// <summary>
    /// 服の破棄
    /// </summary>
    /// <returns>衣服を捨てたか持っていなくて捨てれないか</returns>
    public bool RemoveClothing()
    {
        if (ownedClothes == null) return false;
        ownedClothes = null;

        _clothesRenderer.material = NoneMaterial;

        EquippedUIManager.Instance.RightEquipped.ChangeClothes();

        return true;
    }

    /// <summary>
    /// シャワーに入った時持っている服にシャワーの色を渡す
    /// </summary>
    /// <param name="showerColor">シャワーの色</param>
    public void ShowerEnter(PrimaryColorState showerColor)
    {
        if (ownedClothes != null) { 
            ownedClothes.PaintColor(showerColor);
        }
    }

    public void ClearShower()
    {
        if (ownedClothes != null)
        {
            ownedClothes.PaintClear();
        }
    }
}
