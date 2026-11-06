using UnityEngine;

public class ClothingPainter : MonoBehaviour
{
    [SerializeField] private ColorSettings colorSettings;

    private Color paintColor;
    private Material Material;

    private void Awake()
    {
        
    }
    public void PaintClothing(ColorState paintedColor)
    {
        paintColor = colorSettings[paintedColor];
    }
}
