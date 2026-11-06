using UnityEngine;

[RequireComponent(typeof(ShowerColor))]
public class ShowerHit : MonoBehaviour
{
    /// <summary>
    /// シャワーの色を見るために
    /// </summary>
    private ShowerColor showerColor;

    private void Awake()
    {
        if (!TryGetComponent(out showerColor))
            Debug.LogError($"{name}: ShowerColor がありません", this);
    }

    /// <summary>
    /// シャワーの当たり判定にplayerが入ったらplayerについているOwnedClothingを取得しシャワーの色を渡している
    /// </summary>
    /// <param name="other">当たったオブジェクト</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.TryGetComponent(out OwnedClothing clothing))
            {
                clothing.ShowerEnter(showerColor.CurrentColor);
            }
        }
    }
}
