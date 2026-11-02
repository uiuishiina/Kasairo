using UnityEngine;

public class ShowerColor : MonoBehaviour
{
    [SerializeField] private PrimaryColorState showerColor = PrimaryColorState.None;
    public PrimaryColorState CurrentColor => showerColor;

    public void ChangeShowerColor(PrimaryColorState col)
    {
        if (col is PrimaryColorState.Red or 
            PrimaryColorState.Blue or 
            PrimaryColorState.Yellow) showerColor = col;
    }
}
