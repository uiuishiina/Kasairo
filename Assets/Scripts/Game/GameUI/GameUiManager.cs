
using UnityEngine;

namespace Assets.Scripts.Game.GameUI
{
    /// <summary>
    /// GameUiのマネージャー
    /// </summary>
    public class GameUiManager : StaticObject.StaticObject<GameUiManager>
    {
        /// <summary>
        /// スコアのマネージャー
        /// </summary>
        public Score.ScoreManager ScoreManager { get; private set; } = new Score.ScoreManager();
        /// <summary>
        /// オーダーのマネージャー
        /// </summary>
        public Order.OrderManager OrderManager { get; private set; } = new Order.OrderManager();
        /// <summary>
        /// タイマーのマネージャー
        /// </summary>
        public Timer.TimerManager TimerManager { get; private set; } = new Timer.TimerManager();

        /// <summary>
        /// GameUi全体の初期化
        /// </summary>
        /// <param name="timer">ゲームの制限時間</param>
        public void Initialization(float timer)
        {
            ScoreManager.Initialization();
            OrderManager.Initialization();
            TimerManager.Initialization(timer);
        }
       
    }
}