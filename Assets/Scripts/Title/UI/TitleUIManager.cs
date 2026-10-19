using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 真偽を表す 2 つの Button と関連する GameObject パネルの参照をまとめて保持するシリアライズ可能な構造体。
/// </summary>
/// <remarks>Unity のシリアライズ対象としてエディタからフィールドに割り当て、UI 制御用の参照グループとして使用することを想定。</remarks>
[System.Serializable]
struct Controllers{
    public Button True_;
    public Button False_;
    public GameObject Panel_;
}

public class TitleUIManager : MonoBehaviour
{
    //本当にゲームを終了するかを確認するボタン
    [SerializeField,Header("ゲーム終了用ボタン")] private Button QuitButton;

    [SerializeField,Header("ボタンとパネル")]
    [Tooltip("1つ目が表示用ボタン、2つ目が非表示用ボタン、3つ目がパネル")] private Controllers[] Action;

    private void OnEnable()
    {
        //----------ボタンのイベント登録----------//
        QuitButton.onClick.AddListener(ExitGame);
        
        foreach(var data in Action)
        {
            data.True_.onClick.AddListener(() => data.Panel_.SetActive(true));
            data.False_.onClick.AddListener(() => data.Panel_.SetActive(false));
        }

    }
    private void OnDisable()
    {
        //----------ボタンのイベント解除----------//
        QuitButton.onClick.RemoveListener(ExitGame);

        foreach (var data in Action)
        {
            data.True_.onClick.RemoveListener(() => data.Panel_.SetActive(true));
            data.False_.onClick.RemoveListener(() => data.Panel_.SetActive(false));
        }
    }

    public void ExitGame()
    {
        Debug.Log("ゲーム終了します");
        Application.Quit();
    }
}
