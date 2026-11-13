using Assets.Scripts.Game.GameUI;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Game.GameSystem
{
    /// <summary>
    /// オーダーのマネージャー
    /// </summary>
    public class OrderManager : MonoBehaviour
    {
        /// <summary>
        /// オーダーの
        /// </summary>
        public static OrderManager Instance { get; private set; }

        private int MaxOrder = 4;


        [SerializeField] private List<ColorState> SetColor = new();
        [SerializeField] private List<ClothingType> SetClothing = new();

        private List<Clothes> OrderList = new();

        private void Awake()
        {
            if(Instance != null)
            {
                Destroy(Instance);
                return;
            }

            Instance = this;
        }

        private void OnDisable()
        {
            Instance = null;
        }

        /// <summary>
        /// アルファ用ーーーーーーーーーーーーーーーー↓
        /// </summary>

        bool a = false;
        float timer = 0;
        private void Update()
        {
            if (a) return;

            timer += Time.deltaTime;
            if(timer >= 1)
            {
                timer = 0;
                AddOrder();
            }

            if(OrderList.Count >= MaxOrder) a = true;
        }

        /// <summary>
        /// アルファ用ーーーーーーーーーーーーーーーー↑
        /// </summary>


        /// <summary>
        /// 注文の追加
        /// </summary>
        public void AddOrder()
        {
            if (OrderList.Count >= MaxOrder) return;

            var newOrder = new Clothes(SetColor[RandomValue(SetColor.Count)], SetClothing[RandomValue(SetClothing.Count)]);

            Debug.Log(newOrder.PaintedColor);
            Debug.Log(newOrder.CurrentClothingType);

            GameUiManager.Instance_.OrderManager.AddOrder();

            OrderList.Add(newOrder);
        }
        
        /// <summary>
        /// ランダムな値を返す
        /// </summary>
        /// <param name="maxValue">最大値</param>
        /// <returns>値</returns>
        private int RandomValue(int maxValue)
        {
            return Random.Range(0, maxValue);
        }
        
        /// <summary>
        /// 服の提出
        /// </summary>
        /// <param name="clothes">渡したい服のデータ</param>
        public void Submission(Clothes clothes)
        {
            for (int i = 0; i < OrderList.Count; i++)
            {
                if(OrderList[i].PaintedColor == clothes.PaintedColor && OrderList[i].CurrentClothingType == clothes.CurrentClothingType)
                {
                    int score = 0;
                    switch (clothes.PaintedColor)
                    {
                        case ColorState.Red: case ColorState.Blue: case ColorState.Yellow:
                            score = 100;
                            break;
                        case ColorState.Purple: case ColorState.Green: case ColorState.Orange:
                            score = 250;
                            break;
                        case ColorState.Black:
                            score = 500;
                            break;
                        default:
                            Debug.LogError("存在しない色を提出");
                            score = 999999999;
                            break;
                    }

                    GameUiManager.Instance_.ScoreManager.AddScorePoint(score);
                    return;
                }
            }

            GameUiManager.Instance_.ScoreManager.AddScorePoint(-100);
        }

    }
}
