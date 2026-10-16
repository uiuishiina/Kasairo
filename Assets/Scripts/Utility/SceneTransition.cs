using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.Utility
{
    /// <summary>
    /// シーンを切り替えるためのクラス
    /// </summary>
    public class SceneTransition : StaticObject.StaticObject<SceneTransition>
    {
        /// <summary>
        /// フェードのアニメーション
        /// </summary>
        Animator Animator;

        /// <summary>
        /// 読み込みたいシーンの名前
        /// </summary>
        string SceneName;

        void Start()
        {
            if (TryGetComponent<Canvas>(out var canvas))
            {
                canvas.renderMode = RenderMode.ScreenSpaceOverlay;
                canvas.sortingOrder = 1000;
            }
            if (TryGetComponent<CanvasScaler>(out var scaler))
            {
                scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
                scaler.referenceResolution = new Vector2(Screen.width, Screen.height);
            }
            if (TryGetComponent(out Animator))

                FadeIn();
        }


        /// <summary>
        /// フェードインする関数
        /// </summary>
        void FadeIn() => Animator?.Play("FadeIn", 0);


        /// <summary>
        /// フェードアウトする関数
        /// </summary>
        void FadeOut() => Animator?.Play("FadeOut", 0);

        /// <summary>
        /// 名前でシーンをロードする関数
        /// </summary>
        /// <param name="sceneName">読み込みたいシーンの名前</param>
        public void Load(string sceneName)
        {
            SceneName = sceneName;
            Instance_.FadeOut();
        }

        /// <summary>
        /// アニメーションで呼ばれるシーンロード関数
        /// </summary>
        public void LoadScene() => SceneManager.LoadScene(SceneName);

        /// <summary>
        /// シーンが切り替わった
        /// </summary>
        /// <param name="scene"></param>
        /// <param name="mode"></param>
        protected override void OnLoadedScene(Scene scene, LoadSceneMode mode)
        {
            base.OnLoadedScene(scene, mode);
            FadeIn();
        }
    }
}
