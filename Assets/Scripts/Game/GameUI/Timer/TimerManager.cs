using Assets.Utility.Time;
using System;

namespace Assets.Scripts.Game.GameUI.Timer
{
    /// <summary>
    /// ゲームタイマーを管理
    /// </summary>
    public class TimerManager
    {
        private float Timer;
        
        public event Action<float> TimerChangeEvent;
        /// <summary>
        /// タイマーの設定
        /// </summary>
        /// <param name="timer">制限時間</param>
        public void Initialization(float timer)
        {
            Timer = timer;
        }
        /// <summary>
        /// タイマーの更新処理
        /// </summary>
        public void UpdateTimer()
        {
            if (Timer > 0)
            {
                Timer -= GameTime.FixedDeltaTime;
            }
            TimerChangeEvent?.Invoke(Timer);
        }

    }
}
