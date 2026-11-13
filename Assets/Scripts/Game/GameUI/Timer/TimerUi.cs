using UnityEngine;
using UnityEngine.UI;


namespace Assets.Scripts.Game.GameUI.Timer
{
    /// <summary>
    /// タイマーの表示クラス
    /// </summary>
    public class TimerUi : MonoBehaviour
    {
        private Text TimeText;

        private void OnValidate()
        {
            TimeText = GetComponent<Text>();
        }

        private void Start()
        {
            GameUiManager.Instance_.TimerManager.TimerChangeEvent += UpdateText;
        }


        private void OnDisable()
        {
            GameUiManager.Instance_.TimerManager.TimerChangeEvent -= UpdateText;
        }
        /// <summary>
        /// タイマーのUI更新
        /// </summary>
        /// <param name="timer"></param>
        private void UpdateText(float timer)
        {
            TimeText.text = ((int)timer).ToString();
        }
    }
}


