using UnityEngine;
using UnityEngine.UI;


namespace Assets.Scripts.Game.GameUI.Timer
{
    /// <summary>
    /// タイマーの表示クラス
    /// </summary>
    public class TimerUi : MonoBehaviour
    {
        [SerializeField] private Text TimeText;


        private void Start()
        {
            if(!TimeText) TimeText = GetComponent<Text>();
            GameUiManager.Instance_.TimerManager.TimerChangeEvent += UpdateText;
        }


        private void OnDestroy()
        {
            if(GameUiManager.Instance_.TimerManager != null)
            {
                GameUiManager.Instance_.TimerManager.TimerChangeEvent -= UpdateText;
            }      
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


