using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Game.GameUI.Order
{
    /// <summary>
    /// オーダーを参照・表示するクラス
    /// </summary>
    public class OrderUi : MonoBehaviour
    {
        private Transform ViewBox;

        private Queue<Image> StandByImage = new ();
        private List<Image> UsingImage = new ();

        private void OnValidate()
        {
            ViewBox = GetComponent<ScrollRect>().content;

            for(int i = 0;  i < ViewBox.childCount; i++)
            {
                StandByImage.Enqueue(ViewBox.GetChild(i).GetComponent<Image>());
            }
        }

        private void Start()
        {
            for (int i = 0;i < ViewBox.childCount; i++)
            {
                ViewBox.GetChild(i).gameObject.SetActive(false);
            }

            GameUiManager.Instance_.OrderManager.AddOrderEvent += AddOrderImage;
            GameUiManager.Instance_.OrderManager.RemoveOrderEvent += RemoveOrderImage;
        }

        private void OnDestroy()
        {
            if (GameUiManager.Instance_.OrderManager != null)
            {
                GameUiManager.Instance_.OrderManager.AddOrderEvent -= AddOrderImage;
                GameUiManager.Instance_.OrderManager.RemoveOrderEvent -= RemoveOrderImage;
            }
        }

        /// <summary>
        /// オーダー画像の渡す・表示
        /// </summary>
        /// <param name="orderNumber">表示したいマテリアル</param>
        public void AddOrderImage(Material material)
        {
            var useImage = StandByImage.Dequeue();

            //useImageに画像やらマテリアルやらを渡す

            useImage.transform.SetAsLastSibling();

            useImage.gameObject.SetActive(true);

            UsingImage.Add(useImage);
        }

        /// <summary>
        /// オーダー画像の外す(届けようが、時間が来ようがここを使用)
        /// </summary>
        /// <param name="orderNumber">オーダー番号(0～)</param>
        public void RemoveOrderImage(int orderNumber)
        {
            if (orderNumber < 0 || orderNumber >= ViewBox.childCount)
                Debug.Log($"{gameObject.name} で配列外の申請を受けた");

            UsingImage[orderNumber].gameObject.SetActive(false);

            StandByImage.Enqueue(UsingImage[orderNumber]);
            UsingImage.Remove(UsingImage[orderNumber]);
        }
    }
}
