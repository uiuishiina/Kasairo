using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


namespace Assets.Scripts.Game.GameUI.Interact
{
    /// <summary>
    /// 待機割合の表示
    /// </summary>
    public class WaitUI : MonoBehaviour
    {
        Image WaitImage;

        //イベントの効果時間
        float MaxWaitTime = 0f;
        //現在の経過時間
        float CurrentWaitTime = 0f;

        void Start()
        {
            //コンポーネントの取得
            WaitImage = GetComponentInChildren<Image>();
            //オブジェクトの非表示
            gameObject.SetActive(false);
        }


        void FixedUpdate()
        {
            if (!gameObject.activeSelf) return;
            //経過時間の更新
            CurrentWaitTime -= Time.fixedDeltaTime;
            //UIの更新
            WaitImage.fillAmount = CurrentWaitTime / MaxWaitTime;

            //経過時間が0になったら非表示にする
            if (CurrentWaitTime <= 0f)
            {
                gameObject.SetActive(false);
            }
        }
        /// <summary>
        /// UIの表示
        /// </summary>
        /// <param name="waitTime">イベントの効果時間</param>
        public void SetWaitUI(float waitTime)
        {
            //UIの表示
            gameObject.SetActive(true);
            //UIの初期化
            WaitImage.fillAmount = 1;
            //経過時間の初期化
            MaxWaitTime = CurrentWaitTime = waitTime;
        }

    }
}



