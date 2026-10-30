using UnityEngine;

public class Clothes　: MonoBehaviour
{
    [SerializeField] protected float fillDuration;
    // 確定している色
    private ColorState confirmedColor;
    
    // 基本色ごとの進行度
    [Range(0, 1), SerializeField, Min(0.01f)] private float redPaintedRatio;
    [Range(0, 1), SerializeField, Min(0.01f)] private float bluePaintedRatio;
    [Range(0, 1), SerializeField, Min(0.01f)] private float yellowPaintedRatio;

    protected void Update()
    {

    }

    protected void ConfirmedColor(ColorState confirmedColor)
    {

    }

}
