using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// StaticObject用名前空間
/// </summary>
namespace Assets.Scripts.StaticObject
{
    /// <summary>
    /// SceneManagerクラス
    /// </summary>
    public class StaticSceneManager : StaticObject<StaticSceneManager>
    {
        /* ========== 関数 ========== */

        /* ===== 派生関数 ===== */

        /// <summary>
        /// Sceneロード時実行派生関数
        /// </summary>
        /// <param name="scene">ロードしたScene情報</param>
        /// <param name="mode">ロード方法</param>
        protected override void OnLoadedScene(
            Scene scene,
            LoadSceneMode mode
            )
        {
            Debug.Log($"SceneName = {scene.name}");
        }


        /* ===== 独自関数 ===== */

        /// <summary>
        /// SceneLoad関数
        /// </summary>
        /// <param name="sceneName">LoadするScene名</param>
        public void LoadScene(
            string sceneName
            )
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}