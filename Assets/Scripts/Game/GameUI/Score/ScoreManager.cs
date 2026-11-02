using System;

namespace Assets.Scripts.Game.GameUI.Score
{
    /// <summary>
    /// スコアを管理するクラス
    /// </summary>
    public class ScoreManager
    {
        /// <summary>
        /// The current score.
        /// </summary>
        private int ScorePoint = 0;

        /// <summary>
        /// 表示内容を変える事を伝えるイベント
        /// </summary>
        public event Action<int> ScoreChangeEvent;


        /// <summary>
        /// スコアの初期化
        /// </summary>
        public void Initialization() => ScorePoint = 0;

        /// <summary>
        /// スコアの加算
        /// </summary>
        /// <param name="point">加算する値</param>
        public void AddScorePoint(int point)
        {
            ScorePoint += point;

            ScoreChangeEvent?.Invoke(ScorePoint);
        }
    }
}