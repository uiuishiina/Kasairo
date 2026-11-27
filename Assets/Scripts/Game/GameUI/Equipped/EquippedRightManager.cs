using System;
using System.Diagnostics;

namespace Assets.Scripts.Game.GameUI.Equipped.Right
{
    /// <summary>
    /// 右側の衣類表示
    /// </summary>
    public class EquippedRightManager
    {
        /// <summary>
        /// 所持衣類イベント
        /// </summary>
        public Action<Clothes> ChangeEvent;

        /// <summary>
        /// 重なり状態更新
        /// </summary>
        public Action<bool> OverlappedEvent;


        /// <summary>
        /// 所持衣類表示を変える
        /// </summary>
        /// <param name="clothes">変更後の服 nullなら非表示</param>
        public void ChangeClothes(Clothes clothes = null)
        {
            ChangeEvent?.Invoke(clothes);
        }

        /// <summary>
        /// 重なり状況を伝える
        /// </summary>
        /// <param name="overlapped">重なった ? 何らかしらおこす : 元に戻す</param>
        public void OverlappedImage(bool overlapped)
        {
            OverlappedEvent?.Invoke(overlapped);
        }
    }
}

