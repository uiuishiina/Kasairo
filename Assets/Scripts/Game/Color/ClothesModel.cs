using System.Collections;
using UnityEngine;

public class ClothesModel : MonoBehaviour
{
    [SerializeField]
    public Clothes clothes;

    private Material material;

    private float Amount = 0;

    private Assets.Scripts.StaticObject.StaticColorManager colorManager;


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

    public void ColorChange(ColorState color)
    {
        //material.SetFloat("_PaintAmount", 0);
        Amount = 0;
        material.SetColor("_PaintColor", colorManager.colorSettings[color]);
        StartCoroutine(SetNum("_PaintAmount", colorManager.colorSettings[color]));

        Invoke(nameof(PaintClear), 5f);
    }

    public void PaintClear()
    {
        Amount = 0;
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
        while (name == "_PaintAmount")
        {
            Amount += 0.1f;
            material.SetFloat(name, Amount);
            yield return new WaitForSeconds(0.1f);
            if(Amount >= 1)
            {
                material.SetColor("_BaseColor", color);
                yield break;
            }
        }
        while (name == "_ClearAmount")
        {
            Amount += 0.1f;
            material.SetFloat(name, Amount);
            yield return new WaitForSeconds(0.1f);
            if (Amount >= 1)
            {
                material.SetFloat("_PaintAmount", 0);
                material.SetFloat("_ClearAmount", 0);
                yield break;
            }
        }
    }
}
