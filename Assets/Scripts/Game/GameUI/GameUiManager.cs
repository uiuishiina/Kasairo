
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
        /// GameUi全体の初期化
        /// </summary>
        public void Initialization()
        {
            ScoreManager.Initialization();
            OrderManager.Initialization();
        }


    }
}