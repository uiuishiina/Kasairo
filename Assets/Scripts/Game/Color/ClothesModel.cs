using System.Collections;
using System.Drawing;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Events;
using Color = UnityEngine.Color;
using Assets.Scripts.StaticObject;
using Unity.VisualScripting;

public class ClothesModel : MonoBehaviour
{
    /// <summary>
    /// シャワーの色を服に塗るためのクラス
    /// </summary>
    [SerializeField]
    public Clothes clothes;

    private Material material;         //Material取得
    private float PaintAmount = 0;     //塗装値
    private float ClearAmount = 0;     //クリア値

    Coroutine PaintCorutine;

    private UnityAction<Color> endAction;

    private Assets.Scripts.StaticObject.StaticColorManager colorManager; //色のManagerを取得するための変数

    public bool IsInitialized
    {
        get
        {
            return clothes.IsInitialized;
        }
    }

    private void Awake()
    {
        enabled = false;

        clothes = Clothes.NoneClothes;

        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            material = renderer.material;
        }

        colorManager = StaticColorManager.Instance_;
    }

    public bool InitializeClothes(ColorState paintedColor, ClothingType clothingType)
    {
        if (clothes.IsInitialized)
        {
            return false;
        }
        clothes = new Clothes(paintedColor, clothingType);
        return true;
    }


    /// <summary>
    /// シャワーの色を引数として持ってきて現在の服の色と混ぜて更新する
    /// </summary>
    /// <param name="color">シャワーの色が入る</param>
    public void PaintColor(PrimaryColorState color)
    {
        //  色が違うなら呼び出し
        if (!ColorJudge.JudgeColor(clothes.PaintedColor, color))
        {
            if (PaintCorutine != null)
            {
                endAction?.Invoke(colorManager.colorSettings[clothes.PaintedColor]);
                StopCoroutine(PaintCorutine);
            }
            clothes.PaintColorClothes(color);
            material.SetColor("_PaintColor", colorManager.colorSettings[clothes.PaintedColor]);
            PaintCorutine = StartCoroutine(
                ChengeColorCol(
                    "_PaintAmount",
                    colorManager.colorSettings[clothes.PaintedColor],
                    endAction = ((Color Color) =>
                    {
                        material.SetColor("_BaseColor", Color);
                    })
                )
            );
        }
    }

    /// <summary>
    /// 色をリセットする関数
    /// </summary>
    public void PaintClear()
    {

        if (!ColorJudge.JudgeColor(clothes.PaintedColor, ColorState.None))
        {
            if (PaintCorutine != null)
            {
                endAction?.Invoke(Color.white);

                StopCoroutine(PaintCorutine);
            }
            clothes.ClearColor();
            material.SetColor("_BaseColor", Color.white);
            PaintCorutine = StartCoroutine(ChengeColorCol("_ClearAmount", Color.white,
            endAction = ((Color Color) =>
            {
                material.SetColor("_BaseColor", Color.white);
                material.SetColor("_PaintColor", Color.white);
                material.SetFloat("_PaintAmount", 0);
                material.SetFloat("_ClearAmount", 0);
            })));
        }
    }

    /// <summary>
    /// 塗った色をベースに変える, :ClearするときにBaseColorに戻すから同じ色から同じ色になって意味がない
    /// Amountのリセット : OK
    /// PaintClear両方 :
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    IEnumerator ChengeColorCol(string name, Color color, UnityAction<Color> unityEvent)
    {
        var amount = 0.0f;
        while (true)
        {
            amount += 0.01f;
            material.SetFloat(name, amount);
            yield return new WaitForSeconds(0.001f);
            if (amount >= 1)
            {
                unityEvent?.Invoke(color);
                yield break;
            }
        }
    }
}
