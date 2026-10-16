using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.StageSelect
{
    /// <summary>
    /// ステージ選択時のオプションを開くボタン
    /// </summary>
    public class OptionButtonSystem : MonoBehaviour
    {
        /// <summary>
        /// オプションのオブジェクト
        /// </summary>
        [SerializeField] GameObject OptionBox;
        /// <summary>
        /// ゲームを開始するボタン
        /// </summary>
        [SerializeField] Button GameStartButton;
        /// <summary>
        /// オプションを開くボタン
        /// </summary>
        [SerializeField] Button OptionOpenButton;
        /// <summary>
        /// オプションを閉じるボタン
        /// </summary>
        [SerializeField] Button OptionCloseButton;
        /// <summary>
        /// タイトルに戻るボタン
        /// </summary>
        [SerializeField] Button GoTitleButton;



        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            TryGetComponent<Button>(out OptionOpenButton);
            OptionOpenButton.onClick.AddListener(OpenOption);

            if (OptionBox == null) Debug.LogError("オプションの塊が無い");

            OptionBox.SetActive(false);

            
        }

        /// <summary>
        /// オプションを開くボタンが押された
        /// </summary>
        void OpenOption()
        {
            OptionBox.SetActive(true);
        }

        /// <summary>
        /// オプションを閉じるボタンが押された
        /// </summary>
        void CloseOption()
        {

        }
    }
}

