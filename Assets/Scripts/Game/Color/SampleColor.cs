using UnityEngine;
using UnityEngine.UI;

public class SampleColor : MonoBehaviour
{
    [SerializeField] private GameColor color;
    private void Start()
    {
        var sprite = GetComponent<Image>();
        ColorState state = ColorChanger.MixedColor(ColorState.Red, ColorState.Blue);
        sprite.color = color[state];


        Debug.Log(color);
    }
}
