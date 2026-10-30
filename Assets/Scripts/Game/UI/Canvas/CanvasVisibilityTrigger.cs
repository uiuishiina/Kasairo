using UnityEngine;
using R3;

namespace Assets.Scripts.Game.UI.Canvas
{
    /// <summary>
    /// Canvasにつける
    /// </summary>

    public class CanvasVisibilityTrigger : MonoBehaviour
    {
        //表示されたときを通知するSubject
        private readonly Subject<Unit> onBecameVisibleSubject = new();
        public Observable<Unit> OnBecameVisibleAsObservable => onBecameVisibleSubject;

        //非表示されたときを通知するSubject
        private readonly Subject<Unit> onBecameInvisibleSubject = new();
        public Observable<Unit> OnBecameInvisibleAsObservable => onBecameInvisibleSubject;

        /// <summary>
        /// 表示の瞬間に呼ばれるUnityコールバック
        /// </summary>
        private void OnEnable()
        {
            onBecameVisibleSubject.OnNext(Unit.Default);
        }

        /// <summary>
        ///　非表示の瞬間に呼ばれるUnityコールバック
        /// </summary>
        private void OnDisable()
        {
            onBecameInvisibleSubject.OnNext(Unit.Default);
        }

        /// <summary>
        /// 破棄
        /// </summary>
        private void OnDestroy()
        {
            //イベントを完了させる
            onBecameVisibleSubject.OnCompleted();
            onBecameInvisibleSubject.OnCompleted();
        }
    }

}