using UnityEngine;

namespace Assets.Scripts.Game.GameUI.Equipped
{
    /// <summary>
    /// 現在所持している衣服の表示用Canvas
    /// </summary>
    public class EquippedUIManager : MonoBehaviour
    {
        /// <summary>
        /// 装備衣類表示UIのインスタンス
        /// </summary>
        public static EquippedUIManager Instance { get; private set; }

        /// <summary>
        /// 右側の衣類表示
        /// </summary>
        public Right.EquippedRightManager RightEquipped { get; private set; } = new();

        private void OnValidate()
        {
            if(TryGetComponent(out Canvas canvas))
            {
                canvas.worldCamera = Camera.main;
            }
        }

        private void Awake()
        {
            if(Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
        }

        private void OnDestroy()
        {
            Instance = null;
        }
    }
}