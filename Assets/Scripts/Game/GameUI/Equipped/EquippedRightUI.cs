using Cysharp.Threading.Tasks;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Game.GameUI.Equipped
{
    /// <summary>
    /// 所持している衣類の表示　右側
    /// </summary>
    [RequireComponent(typeof(Image))]
    public class EquippedRightUI : MonoBehaviour
    {
        [SerializeField] private RectTransform Trans;
        [SerializeField] private Image Image;

        [SerializeField] List<Transform> PlayerPos = new(2);

        [SerializeField] Camera Camera;

        //隠れる場所
        Vector3 HidPosi = new (370.0f, -370.0f, 0.0f);

        bool ClothesHold = false;

        bool NowOverlapping = false;

        private void OnValidate()
        {
            Trans = GetComponent<RectTransform>();
            Image = GetComponent<Image>();
            Camera = Camera.main;
        }

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            if(PlayerPos.Count <= 0)
            {
                Debug.LogError("Playerを入れてください");
            } 

            EquippedUIManager.Instance.RightEquipped.ChangeEvent += ChangeClothes;
        }

        private void Update()
        {
            //Playerが割り当てられていない場合、飛ばす
            if (PlayerPos.Count == 0) return;

            bool overlapping = false;

            foreach(Transform player in PlayerPos)
            {
                Vector3 screenPos = Camera.WorldToScreenPoint(player.position);

                overlapping |= RectTransformUtility.RectangleContainsScreenPoint(Trans, screenPos, Camera);

            }

            if(overlapping != NowOverlapping)
            {
                if (overlapping)    //隠れている
                {
                    var color = Image.color;
                    color.a = 0.3f;
                    Image.color = color;
                }
                else                //出てきた
                {
                    var color = Image.color;
                    color.a = 1.0f;
                    Image.color = color;
                }

                    NowOverlapping = overlapping;
            }
        }

        public void ChangeClothes(Clothes clothes = null)
        {
            if (clothes == null)         //次持つ服がない
            {
                NotOwning().Forget();
            }
            else if (!ClothesHold)      //現在未所持
            {
                ToHold(clothes).Forget();
            }
            else                        //下げて、上げて
            {
                Change(clothes).Forget();   //持ってるし、持ち変える
            }
        }

        /// <summary>
        /// イメージを下げるだけ
        /// </summary>
        async UniTask NotOwning()
        {
            float timer = 0;

            while (timer < 0.5f)
            {
                await UniTask.Yield(PlayerLoopTiming.Update);

                timer += Time.deltaTime;

                float t = Mathf.Clamp01(timer / 0.5f);

                Trans.anchoredPosition = Vector3.Lerp(Vector3.zero, HidPosi, t);
            }

            Trans.anchoredPosition = HidPosi;
            ClothesHold = false;
        }
        /// <summary>
        /// イメージを上げるだけ
        /// </summary>
        /// <param name="clothes">持たせるイメージ</param>
        async UniTask ToHold(Clothes clothes)
        {
            float timer = 0;

            while (timer < 0.5f)
            {
                await UniTask.Yield(PlayerLoopTiming.Update);

                timer += Time.deltaTime;

                float t = Mathf.Clamp01(timer / 0.5f);

                Trans.anchoredPosition = Vector3.Lerp(HidPosi, Vector3.zero, t);
            }

            Trans.anchoredPosition = Vector3.zero;
            ClothesHold = true;
        }
        /// <summary>
        /// イメージを下げて上げる
        /// </summary>
        /// <param name="clothes">持たせるイメージ</param>
        async UniTask Change(Clothes clothes)
        {
            await NotOwning();

            await UniTask.Yield();

            ToHold(clothes).Forget();
        }


        public void Overlapped(bool over)
        {
            if (over)
            {

            }
            else
            {

            }
        }
    }

}
