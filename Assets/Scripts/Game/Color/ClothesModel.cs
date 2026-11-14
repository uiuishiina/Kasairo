using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using Color = UnityEngine.Color;
using Assets.Scripts.StaticObject;
using Cysharp.Threading.Tasks;
using System;
using System.Threading;

public class ClothesModel
{
    /// <summary>
    /// シャワーの色を服に塗るためのクラス
    /// </summary>
    public Clothes _clothes;

    private Material _material;

    Coroutine PaintCorutine;

    private Assets.Scripts.StaticObject.StaticColorManager colorManager; //色のManagerを取得するための変数

    const float timeSpan = 0.01f;

    CancellationTokenSource cancelTaken = new();

    public ClothesModel(Material material, Clothes clothes)
    {
        init(material, clothes);
    }

    public ClothesModel(Material material, ColorState paintedColor = ColorState.None, ClothingType clothingType = ClothingType.None)
    {
        init(material,new Clothes(paintedColor, clothingType));
    }

    private void init(Material material, Clothes clothes)
    {
        _clothes = clothes;
        _material = new Material(material);

        colorManager = StaticColorManager.Instance_;
        Debug.Log("Init");
    }

    ~ClothesModel()
    {
        _material = null;
        Debug.Log("delete");
    }

    /// <summary>
    /// シャワーの色を引数として持ってきて現在の服の色と混ぜて更新する
    /// </summary>
    /// <param name="color">シャワーの色が入る</param>
    public void PaintColor(PrimaryColorState color)
    {
        //  色が違うなら呼び出し
        if (!ColorJudge.JudgeColor(_clothes.PaintedColor, color))
        {
            if (PaintCorutine != null)
            {
                cancelTaken.Cancel();
            }
            _clothes.PaintColorClothes(color);
            _material.SetColor("_PaintColor", colorManager.colorSettings[_clothes.PaintedColor]);

            ChengeColorTask(
                "_PaintAmount",
                    colorManager.colorSettings[_clothes.PaintedColor],
                    ((Color Color) =>
                    {
                        _material.SetColor("_BaseColor", Color);
                    })
            ).Forget();

        }
    }

    /// <summary>
    /// 色をリセットする関数
    /// </summary>
    public void PaintClear()
    {

        if (!ColorJudge.JudgeColor(_clothes.PaintedColor, ColorState.None))
        {
            if (PaintCorutine != null)
            {
                cancelTaken.Cancel();
            }
            _clothes.ClearColor();
            _material.SetColor("_BaseColor", Color.white);
            ChengeColorTask(
                "_ClearAmount", 
                Color.white,
                ((Color Color) =>
                {
                    _material.SetColor("_BaseColor", Color.white);
                    _material.SetColor("_PaintColor", Color.white);
                    _material.SetFloat("_PaintAmount", 0);
                    _material.SetFloat("_ClearAmount", 0);
                })
            ).Forget();

        }
    }


    async UniTask ChengeColorTask(string name, Color color, UnityAction<Color> unityEvent)
    {
        float amount = 0.0f;
        while (amount >= 1)
        {
            amount += timeSpan;
            _material.SetFloat(name, amount);
            try
            {
                await UniTask.Delay(TimeSpan.FromSeconds(timeSpan), cancellationToken: cancelTaken.Token);
            }
            catch
            {
                amount = float.MaxValue;
            }
        }
        unityEvent?.Invoke(color);
    }
}
