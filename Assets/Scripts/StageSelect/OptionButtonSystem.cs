using Assets.Scripts.Utility;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.StageSelect
{
    /// <summary>
    /// ステージ選択時のオプションを開くボタン
    /// </summary>
    public class OptionButtonSystem : MonoBehaviour
    {
        [Header("OptionのGameObject")]
        /// <summary>
        /// オプションのオブジェクト
        /// </summary>
        [SerializeField] GameObject OptionBox;

        [Header("StageSelectのButton")]
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

        /// <summary>
        /// タイトルシーン
        /// </summary>
        const string TitleScene = "Title";


        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            //nullチェックたち
            if (!OptionBox) Debug.LogError("OptionBoxが未割当");
            if (!GameStartButton) Debug.LogError("GameStartButtonが未割当");
            if (!OptionOpenButton) Debug.LogError("OptionOpenButtonが未割当");
            if (!OptionCloseButton) Debug.LogError("OptionCloseButtonが未割当");
            if (!GoTitleButton) Debug.LogError("GoTitleButtonが未割当");

            OptionBox.SetActive(false);
        }

        /// <summary>
        /// SetActive true
        /// </summary>
        private void OnEnable()
        {
            //いずれかがnullなら飛ばす
            if(!GameStartButton || !OptionOpenButton || !OptionCloseButton || !GoTitleButton)
                return;

            //Eventの追加
            GameStartButton.onClick.AddListener(GameStart);
            OptionOpenButton.onClick.AddListener(OpenOption);
            OptionCloseButton.onClick.AddListener(CloseOption);
            GoTitleButton.onClick.AddListener(GoTitle);
        }
        /// <summary>
        /// SetActive false
        /// </summary>
        private void OnDisable()
        {
            //いずれかがnullなら飛ばす
            if (!GameStartButton || !OptionOpenButton || !OptionCloseButton || !GoTitleButton)
                return;

            //Eventの削除
            GameStartButton.onClick.RemoveAllListeners();
            OptionOpenButton.onClick.RemoveAllListeners();
            OptionCloseButton.onClick.RemoveAllListeners();
            GoTitleButton.onClick.RemoveAllListeners();
        }

        /// <summary>
        /// ゲーム開始　名前を取得してシーンをロード
        /// </summary>
        void GameStart() => Debug.Log("未実装 GameStart ");

        /// <summary>
        /// オプションを開くボタンが押された
        /// </summary>
        void OpenOption() => OptionBox.SetActive(true);

        /// <summary>
        /// オプションを閉じるボタンが押された
        /// </summary>
        void CloseOption() => OptionBox.SetActive(false);

        /// <summary>
        /// Titleに戻る
        /// </summary>
        void GoTitle() => SceneTransition.Instance_.Load(TitleScene);
    }
}

