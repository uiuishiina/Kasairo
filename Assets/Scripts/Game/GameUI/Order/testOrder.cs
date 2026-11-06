using Assets.Scripts.Game.GameUI;
using UnityEngine;

public class testOrder : MonoBehaviour
{
    [SerializeField] int n;

    public void Add()
    {
        GameUiManager.Instance_.OrderManager.AddOrder();
    }

    public void Remove()
    {
        GameUiManager.Instance_.OrderManager.RemoveOrder(n);
    }
}
