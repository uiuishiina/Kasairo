using UnityEngine;
using R3;

public class ShowerHit : MonoBehaviour
{
    ReactiveProperty<bool> isShowerHit;

    private void Start()
    {
        isShowerHit.Value = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isShowerHit.Value = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isShowerHit.Value = false;
        }
    }
}
