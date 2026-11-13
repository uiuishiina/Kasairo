using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public struct WorldToUIData
{
    public Transform TargetObject;
    public RectTransform TargetRectTransform;
    public float OffSet;
}

namespace Assets.Scripts.Game.GameUI.Interact
{
    public class WorldToUI : MonoBehaviour
    {
        [SerializeField, Header("メインカメラ")] private Camera MainCamera;
        [SerializeField, Header("Canvas")] private Canvas TargetCanvas;
        [SerializeField] private List<WorldToUIData> TargetList = new();

        RectTransform CanvasRectTransform;

        Camera UICamera;
        private void Awake()
        {
            //コンポーネントの取得
            CanvasRectTransform = TargetCanvas.GetComponent<RectTransform>();
            //CanvasのRenderModeに応じてカメラを取得
            UICamera =
                TargetCanvas.renderMode == RenderMode.ScreenSpaceOverlay
                ? null
                : TargetCanvas.worldCamera;
        }

        private void LateUpdate()
        {
            UpdateUIPosition();
        }

        public void UpdateUIPosition()
        {
            foreach (var target in TargetList)
            {
                if(target.TargetObject == null || target.TargetRectTransform == null) continue;

                //ゲームオブジェクトのワールド座標を取得し、オフセットを加える
                Vector3 worldPosition = target.TargetObject.position + Vector3.up * target.OffSet;

                //ゲームオブジェクトのワールド座標をスクリーン座標に変換
                Vector3 screenPosition = MainCamera.WorldToScreenPoint(worldPosition);

                //スクリーン座標がカメラの前にあるかどうかを確認し、UIの表示・非表示を切り替える
                if (screenPosition.z <= 0)
                {
                    target.TargetRectTransform.gameObject.SetActive(false);
                    continue;
                }
                target.TargetRectTransform.gameObject.SetActive(true);

                //スクリーン座標をCanvasのローカル座標に変換
                if (RectTransformUtility.ScreenPointToLocalPointInRectangle
                (CanvasRectTransform, screenPosition, UICamera, out Vector2 localPosition))
                {
                    //UIの位置を更新
                    target.TargetRectTransform.anchoredPosition = localPosition;
                }

            }
        }
    }
}


