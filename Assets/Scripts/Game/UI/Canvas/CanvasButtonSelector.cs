using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Game.UI.Canvas
{
    /// <summary>
    /// Canvasにつける
    /// </summary>
    public class CanvasButtonSelector : MonoBehaviour
    {
        public void ActiveButton()
        {
            //ActiveなButtonを参照
            var buttons = GetComponentsInChildren<UnityEngine.UI.Button>(false);

            foreach (var button in buttons)
            {
                // 2. ボタン自体、およびそのGameObjectがアクティブ、かつクリック可能（interactable）かチェック
                if (button.gameObject.activeInHierarchy && button.interactable)
                {
                    // 一旦選択をクリア（Unityの仕様上、同じオブジェクトを再選択する際のバグ防止）
                    EventSystem.current.SetSelectedGameObject(null);

                    // 3. 最初に見つかった有効なボタンを選択して処理を終了
                    EventSystem.current.SetSelectedGameObject(button.gameObject);

                    return;
                }
            }
        }
    }

}