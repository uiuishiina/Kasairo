using System;
using UnityEngine;

namespace Assets.Scripts.Game.GameUI.Order
{
    /// <summary>
    /// 注文を管理するクラス
    /// </summary>
    public class OrderManager
    {

        /// <summary>
        /// 表示内容を変える事を伝えるイベント
        /// </summary>
        public event Action<Material> AddOrderEvent;
        public event Action<int> RemoveOrderEvent;

        /// <summary>
        /// オーダーの初期化
        /// </summary>
        public void Initialization()
        {

        }

        /// <summary>
        /// UIにオーダーを追加申請
        /// </summary>
        /// <param name="material">表示したいマテリアル</param>
        public void AddOrder(Material material = null)
        {
            AddOrderEvent?.Invoke(material);
        }

        /// <summary>
        /// オーダーUIの削除イベント
        /// </summary>
        /// <param name="number"></param>
        public void RemoveOrder(int number)
        {
            RemoveOrderEvent?.Invoke(number);
        }


        /// <summary>
        /// アルファ用ーーーーーーーーーーーーーーーー↓
        /// </summary>

        /// <summary>
        /// Alpha用　オーダーUI追加イベント
        /// </summary>
        public event Action<string, string> AddAlphaOrderEvent;
        /// <summary>
        /// Alpha用　オーダーUI追加
        /// </summary>
        /// <param name="color"></param>
        /// <param name="clothing"></param>
        public void AddAlphaOrder(string color, string clothing)
        {
            AddAlphaOrderEvent?.Invoke(color, clothing);
        }

        /// <summary>
        /// アルファ用ーーーーーーーーーーーーーーーー↑
        /// </summary>
    }

}
