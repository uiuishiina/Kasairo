using Assets.Scripts.Game.UI.Button;
using Assets.Scripts.Game.UI.Canvas;
using R3;
using UnityEngine;

namespace Assets.Scripts.Game.UI.Button
{
    /// <summary>
    /// GameManagerかEventSystemにつける
    /// </summary>

    public class CanvasUIManager : MonoBehaviour
    {
        [SerializeField] private GameObject[] Canvas;

        private void Start()
        {
            if (Canvas == null || Canvas.Length == 0)
            {
                Debug.LogError("表示されるCanvasがありません");
                return;
            }

            foreach (var canv in Canvas)
            {
                if (canv == null)
                {
                    Debug.LogError("配列に未設定のCanvasがあります");
                    continue;
                }
                var trigger = canv.GetComponent<CanvasVisibilityTrigger>();
                var select = canv.GetComponent<CanvasButtonSelector>();

                //表示されたときの処理
                trigger.OnBecameVisibleAsObservable
                                .Subscribe(_ =>
                                {
                                    select.ActiveButton();
                                })
                                .RegisterTo(destroyCancellationToken); //Unity 6のライフサイクルで自動解除
            }
        }

        public void OnInvisible(bool a)
        {
            Debug.Log(a ? "100" : "200");
        }
    }
}