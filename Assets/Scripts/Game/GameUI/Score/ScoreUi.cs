using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Game.GameUI.Score
{
    /// <summary>
    /// スコアを参照・表示するクラス
    /// </summary>
    [RequireComponent(typeof(Text))]
    public class ScoreUi : MonoBehaviour
    {
        /// <summary>
        /// The UI text component that displays the score.
        /// </summary>
        [SerializeField] private Text ScoreText;

        public void Start()
        {
            if(!ScoreText) ScoreText = GetComponent<Text>();
            UpdateText(0);

            GameUiManager.Instance_.ScoreManager.ScoreChangeEvent += UpdateText;
        }

        private void OnDestroy()
        {
            GameUiManager.Instance_.ScoreManager.ScoreChangeEvent -= UpdateText;
        }

        /// <summary>
        /// スコアの数値を描画
        /// </summary>
        /// <param name="scorePoint"></param>
        private void UpdateText(int scorePoint)
        {
            ScoreText.text = scorePoint.ToString("D6");
        }
    }

}
