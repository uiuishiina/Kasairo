using Assets.Scripts.Game.UI.Button;
using Cysharp.Threading.Tasks.Linq;
using Cysharp.Threading.Tasks.Triggers;
using R3;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace Assets.Scripts.Game.UI.Button
{
    /// <summary>
    /// EventSystemにつける
    /// </summary>

    public class CanvasUIManager : MonoBehaviour
    {
        [SerializeField] private GameObject[] canvas;
        //[SerializeField] private GameObject canvas1;

        private void Start()
        {
            if (canvas == null || canvas.Length == 0)
            {
                Debug.LogError("表示されるCanvasがありません");
                return;
            }

            foreach (var canv in canvas)
            {
                if (canv == null)
                {
                    Debug.LogWarning("配列に未設定のCanvasがあります");
                    continue;
                }
                var trigger = canv.GetComponent<CanvasVisibilityTrigger>();
                var select = canv.GetComponent<SelectButton>();

                //表示されたときの処理
                trigger.OnBecameVisibleAsObservable
                                .Subscribe(_ =>
                                {
                                    Debug.Log("Canvasが表示");
                                    select.ActiveButton();

                                })
                                .RegisterTo(destroyCancellationToken); //Unity 6のライフサイクルで自動解除
            }
        }

/*        public void OnInvisible(bool a)
        {
            canvas1.SetActive(false);
            canvas.SetActive(true);
        }*/
    }
}