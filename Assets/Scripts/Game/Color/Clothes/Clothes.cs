using UnityEngine;

public class Clothes : MonoBehaviour
{
    // ämíËÇµÇƒÇ¢ÇÈêF
    [SerializeField] private ColorState paintedColor = ColorState.None;

    [SerializeField] private ClothingType clothingType = ClothingType.Shirt;

    public void PaintColor(PrimaryColorState color)
    {
        paintedColor = ColorMixer.MixedColor(paintedColor, color);
        //GetComponent<Renderer>().material.color = paintedColor;
        Debug.Log(paintedColor);
    }
}
