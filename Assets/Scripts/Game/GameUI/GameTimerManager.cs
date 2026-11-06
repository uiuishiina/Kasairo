using Assets.Scripts.StaticObject;
using Assets.Utility.Time;
using UnityEngine;
using UnityEngine.UI;

public class GameTimerManager : MonoBehaviour
{
    [SerializeField]private float Timer;
    [SerializeField]private Text TimeText;

    private void Awake()
    {
        //StaticTimeManager.Instance_.SetPause(true);

    }

    private void FixedUpdate()
    {
        if (Timer > 0)
        {
            Timer -= GameTime.FixedDeltaTime;
        }

        TimeText.text = ((int)Timer).ToString();
    }
}
