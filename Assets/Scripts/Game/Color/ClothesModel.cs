using System.Collections;
using UnityEngine;

public class ClothesModel : MonoBehaviour
{
    [SerializeField]
    public Clothes clothes;

    private Material material;

    private float paintAmount = 0;
    private float clearAmount = 0;



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
        paintAmount = 0;
        material.SetColor("_PaintColor", colorManager.colorSettings[color]);
        StartCoroutine(SetNum("_PaintAmount", colorManager.colorSettings[color], paintAmount));
    }

    public void PaintClear(ColorState color)
    {
        clearAmount = 0;
        material.SetColor("_BaseColor", Color.white);
        StartCoroutine(SetNum("_ClearAmount", Color.white, clearAmount));
    }

    /// <summary>
    /// 塗った色をベースに変える,
    /// Amountのリセット
    /// PaintClear両方
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    IEnumerator SetNum(string name, Color color,float amount)
    {
        while (true)
        {
            amount += 0.1f;
            material.SetFloat(name, amount);
            yield return new WaitForSeconds(0.1f);
            if(amount >= 1)
            {
                //material.SetColor("_BaseColor", color);
                yield break;
            }
        }
    }
}
