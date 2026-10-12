//  色のビットと実際の色を紐づけ
using UnityEngine;

[CreateAssetMenu(fileName = "GameColor", menuName = "Scriptable Objects/GameColor")]
public class GameColor : ScriptableObject
{
    public Color NoneColor = new Color { };
    public Color RedColor = new Color { };
    public Color BlueColor = new Color { };
    public Color PurpleColor = new Color { };
    public Color YellowColor = new Color { };
    public Color OrangeColor = new Color { };
    public Color GreenColor = new Color { };
    public Color BlackColor = new Color { };


    public Color this[ColorState index]
    {
        get => index switch
        {
            ColorState.None => NoneColor,
            ColorState.Red => RedColor,
            ColorState.Blue => BlueColor,
            ColorState.Purple => PurpleColor,
            ColorState.Yellow => YellowColor,
            ColorState.Orange => OrangeColor,
            ColorState.Green => GreenColor,
            ColorState.Black => BlackColor,
            _ => throw new System.ArgumentOutOfRangeException(nameof(index))
        };
        private set {}
    }

}
