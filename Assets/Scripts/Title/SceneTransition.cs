using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// シーンを切り替えるためのクラス
/// </summary>
public class SceneTransition : Assets.Scripts.StaticObject.StaticObject<SceneTransition>
{
    /// <summary>
    /// フェードのアニメーション
    /// </summary>
    Animator Animator;

    /// <summary>
    /// シーンのロードタイプ　true:名前でロード　false:インデックスでロード
    /// </summary>
    bool LoadType = false;

    /// <summary>
    /// 読み込みたいシーンの名前
    /// </summary>
    string SceneName;
    /// <summary>
    /// 読み込みたいシーンのインデックス
    /// </summary>
    int SceneIndex;

    void Awake()
    {
        if(TryGetComponent<Canvas>(out var canvas))
        {
            canvas.renderMode = RenderMode.ScreenSpaceCamera;
            canvas.sortingOrder = 1000;
        }
        if(TryGetComponent<CanvasScaler>(out var scaler))
        {
            scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            scaler.referenceResolution = new Vector2(Screen.width, Screen.height);
        }
        if(TryGetComponent<Animator>(out var animator))
        {
            Animator = animator;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        FadeIn();
    }

    /// <summary>
    /// フェードインする関数
    /// </summary>
    void FadeIn()
    {
        Animator.Play("FadeIn", 0);
    }
    /// <summary>
    /// フェードアウトする関数
    /// </summary>
    void FadeOut()
    {
        Animator.Play("FadeOut", 0);
    }

    /// <summary>
    /// 名前でシーンをロードする関数
    /// </summary>
    /// <param name="sceneName">読み込みたいシーンの名前</param>
    public void Load(string sceneName)
    {
        LoadType = true;
        SceneName = sceneName;
        Instance_.FadeOut();
    }
    /// <summary>
    /// 番号でシーンをロードする関数
    /// </summary>
    /// <param name="sceneIndex">読み込みたいシーンのインデックス</param>
    public void Load(int sceneIndex)
    {
        LoadType = false;
        SceneIndex = sceneIndex;
        Instance_.FadeOut();
    }

    /// <summary>
    /// アニメーションで呼ばれるシーンロード関数
    /// </summary>
    public void LoadScene()
    {
        if (LoadType)
        {
            Debug.Log($"Load Scene : {SceneName}");
        }
        else
        {
            Debug.Log($"Load Scene : {SceneIndex}");
        }
    }

}