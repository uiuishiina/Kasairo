using UnityEngine;
using UnityEngine.UI;

public class SampleColor : MonoBehaviour
{
    [SerializeField] private ColorSettings color;
    private void Start()
    {
        var sprite = GetComponent<Image>();
        ColorState state = ColorChanger.MixedColor(ColorState.Red, ColorState.Red);
        sprite.color = color[state];


        Debug.Log(state);
    }
}
