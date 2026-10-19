using Assets.Utility.Time;
using UnityEngine;
/// <summary>
/// OtherObjectを継承した、ミシンや洗濯機に共通した変数や関数をまとめたクラス
/// </summary>
public class MachineObject : OtherObject
{
    //機械を使ったときのクールタイム
    [SerializeField]
    protected float CoolTime = 10.0f;

    private float time = 0;

    protected bool iscool()
    {
        return time >= 0;
    }

    protected void cool()
    {
        if(!iscool())
        {
            time = CoolTime;
        }
    }

    private void Update()
    {
        time -= GameTime.DeltaTime;
    }
}
