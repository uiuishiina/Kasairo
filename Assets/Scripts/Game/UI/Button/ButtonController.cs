using Assets.Scripts.Game.UI.Button;
using UnityEngine;



namespace Assets.Scripts.Game.UI.Button
{
    using UnityEngine.EventSystems;
    using UnityEngine.UI;
    /// <summary>
    /// ButtonConponentoを外して代わりにつける
    /// </summary>
    public class ButtonController : Button
    {
        // 現在マウスカーソルが重なっているButton
        private static ButtonController HoveredButton;

        // マウス操作を優先している間、Selected状態を抑制する
        private bool suppressSelected;

        /// <summary>
        /// Buttonの見た目の状態を切り替える
        /// </summary>
        protected override void DoStateTransition(
            SelectionState state, bool instant)
        {
            // マウスが別のButton上にある場合、
            // このButtonのSelectedアニメーションを抑制する
            if (HoveredButton != null &&
                HoveredButton != this &&
                state == SelectionState.Selected)
            {
                suppressSelected = true;

                // Normal状態の見た目にする
                base.DoStateTransition(SelectionState.Normal, instant);
                return;
            }

            suppressSelected = false;

            base.DoStateTransition(state, instant);
        }

        public override void OnPointerClick(PointerEventData eventData)
        {
            base.OnPointerClick(eventData);
        }

        public override void OnSubmit(BaseEventData eventData)
        {
            base.OnSubmit(eventData);
        }

        /// <summary>
        /// マウスカーソルがButtonに入ったとき
        /// </summary>
        public override void OnPointerEnter(PointerEventData eventData)
        {
            base.OnPointerEnter(eventData);

            HoveredButton = this;

            // マウスが重なったButtonをEventSystemの選択対象にする
            if (EventSystem.current != null)
            {
                EventSystem.current.SetSelectedGameObject(gameObject);
            }
        }

        /// <summary>
        /// マウスカーソルがButtonから出たとき
        /// </summary>
        public override void OnPointerExit(PointerEventData eventData)
        {
            base.OnPointerExit(eventData);

            if (HoveredButton == this)
            {
                HoveredButton = null;
            }
        }

        public override void OnSelect(BaseEventData eventData)
        {
            base.OnSelect(eventData);
        }

        public override void OnDeselect(BaseEventData eventData)
        {
            base.OnDeselect(eventData);

        }
    }
}