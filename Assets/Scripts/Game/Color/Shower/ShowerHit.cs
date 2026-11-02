using UnityEngine;

[RequireComponent(typeof(ShowerColor))]
public class ShowerHit : MonoBehaviour
{
    private ShowerColor showerColor;

    private void Awake()
    {
        showerColor = GetComponent<ShowerColor>();
    }

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
