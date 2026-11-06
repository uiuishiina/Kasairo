using UnityEngine;

public class ShowerColor : MonoBehaviour
{
    /// <summary>
    /// シャワーの色
    /// </summary>
    [SerializeField] private PrimaryColorState showerColor;
    
    /// <summary>
    /// 読み取り専用のプロパティ
    /// </summary>
    public PrimaryColorState CurrentColor => showerColor;

    /// <summary>
    /// シャワーの色を変える関数
    /// </summary>
    /// <param name="col">基本色のstateが入る</param>
    public void ChangeShowerColor(PrimaryColorState col)
    {
        if (col is PrimaryColorState.Red or 
            PrimaryColorState.Blue or 
            PrimaryColorState.Yellow) showerColor = col;
    }
}
