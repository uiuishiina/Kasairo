using System.Collections;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

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


    private Assets.Scripts.StaticObject.StaticColorManager colorManager; //色のManagerを取得するための変数


    void Start()
    {
        clothes = new Clothes(ColorState.None, ClothingType.Shirt);

        material = GetComponent<Renderer>().material;

        colorManager = Assets.Scripts.StaticObject.StaticColorManager.Instance_;

        //ColorChange(clothes.PaintedColor);
    }



    /// <summary>
    /// シャワーの色を引数として持ってきて現在の服の色と混ぜて更新する
    /// </summary>
    /// <param name="color">シャワーの色が入る</param>
    public void PaintColor(PrimaryColorState color)
    {
        clothes.PaintColorClothes(color);

        ColorChange(clothes.PaintedColor);
    }

    /// <summary>
    /// 色を変更させる関数
    /// </summary>
    /// <param name="color">変更する色</param>
    public void ColorChange(ColorState color)
    {
        material.SetColor("_PaintColor", colorManager.colorSettings[color]);
        StartCoroutine(SetNum("_PaintAmount", colorManager.colorSettings[color]));
    }

    /// <summary>
    /// 色をリセットする関数
    /// </summary>
    public void PaintClear()
    {
        material.SetColor("_BaseColor", Color.white);
        StartCoroutine(SetNum("_ClearAmount", Color.white));

    }

    /// <summary>
    /// 塗った色をベースに変える, :ClearするときにBaseColorに戻すから同じ色から同じ色になって意味がない
    /// Amountのリセット : OK
    /// PaintClear両方 :
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    IEnumerator SetNum(string name, Color color)
    {
        if(name == "_PaintAmount")
        {
            while (true)
            {
                PaintAmount += 0.1f;
                material.SetFloat(name, PaintAmount);
                yield return new WaitForSeconds(0.1f);
                if (PaintAmount >= 1)
                {
                    material.SetColor("_BaseColor", color);
                    PaintAmount = 0;
                    yield break;
                }
            }
        }
        else if(name == "_ClearAmount")
        {
            while (true)
            {
                ClearAmount += 0.1f;
                material.SetFloat(name, ClearAmount);
                yield return new WaitForSeconds(0.1f);
                if (ClearAmount >= 1)
                {
                    material.SetColor("_BaseColor", Color.white);
                    material.SetColor("_PaintColor", Color.white);
                    material.SetFloat("_PaintAmount", 0);
                    material.SetFloat("_ClearAmount", 0);
                    ClearAmount = 0;
                    yield break;
                }
            }
        }
    }
}
