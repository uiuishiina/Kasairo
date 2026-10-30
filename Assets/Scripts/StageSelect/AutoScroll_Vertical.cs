using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts
{
    /// <summary>
    /// スクロールビューの自動化
    /// </summary>
    public class AutoScroll_Vertical : MonoBehaviour
    {
        /// <summary>
        /// ScrollRect
        /// </summary>
        ScrollRect ScrollRect;
        /// <summary>
        /// 描画エリア
        /// </summary>
        RectTransform Viewport;
        /// <summary>
        /// 内容物の親のTransform
        /// </summary>
        Transform Content;
        /// <summary>
        /// レイアウトグラフ
        /// </summary>
        VerticalLayoutGroup LayoutGroup;
        /// <summary>
        /// 注目中オブジェクト
        /// </summary>
        RectTransform Aattention;


        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            if (TryGetComponent<ScrollRect>(out ScrollRect))
            {
                Viewport = ScrollRect.viewport;
                Content = ScrollRect.content;
                if (!Content.TryGetComponent<VerticalLayoutGroup>(out LayoutGroup))
                    Debug.LogError("VerticalLayoutGroup が未割当");
                Aattention = (RectTransform)Content.GetChild(0).transform;
            }
            else
                Debug.LogError("不要な割当");

        }

        // Update is called once per frame
        void Update()
        {
            GameObject selectedObj = EventSystem.current.currentSelectedGameObject;
            if (selectedObj == null) return;

            RectTransform selectedRect = selectedObj.GetComponent<RectTransform>();
            if (selectedRect == null) return;

            // Contentの階層下にあるか確認
            if (!selectedRect.IsChildOf(Content)) return;

            //つづき
            //https://qiita.com/toRisouP/items/3619ad3d2b7d785968f1
        }
    }
}

