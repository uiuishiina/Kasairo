using Assets.Scripts.Game.UI.Button;
using R3;
using UnityEngine;

public class UIButtonManager : MonoBehaviour
{
    [SerializeField] private GameObject canvas;

    [SerializeField] private GameObject canvas1;

    private void Start()
    {
        if (canvas == null){Debug.LogError("表示されるCanvasがありません");}

        var trigger = canvas.GetComponent<CanvasVisibilityTrigger>();
        var select = canvas.GetComponent<SelectButton>();
        //表示されたときの処理
        trigger.OnBecameVisibleAsObservable
                        .Subscribe(_ =>
                        {
                            Debug.Log("Canvasが表示");
                            select.ActiveButton();
                        })
                        .RegisterTo(destroyCancellationToken); //Unity 6のライフサイクルで自動解除
    }

    public void OnInvisible(bool a)
    {
        canvas1.SetActive(false);
        canvas.SetActive(true);
    }
}