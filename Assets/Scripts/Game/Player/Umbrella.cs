using Assets.Scripts.Game.Player;
using UnityEngine;
using UnityEngine.InputSystem;

public class Umbrella : MonoBehaviour
{
    PlayerInputController PlayerInput;
    public bool IsUmbrella {  get; private set; }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        IsUmbrella = false;
        PlayerInput = GetComponent<PlayerInputController>();
        PlayerInput.OnUmbrella += OnUmbrella;
    }
    void OnUmbrella()
    {
        IsUmbrella = !IsUmbrella;
    }
}
