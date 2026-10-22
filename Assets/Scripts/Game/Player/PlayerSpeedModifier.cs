using UnityEngine;
using Cysharp.Threading.Tasks;
using System;
using System.Threading;
/// <summary>
/// 水に触れたときのplayerの移動速度を変化させる処理だけがあるクラス
/// </summary>
public class PlayerSpeedModifier
{
    /// <summary>
    /// playerの移動速度の割合を変化させる変数(プロパティ変数にしており、外部から読み取ることはできるが、数値をいじれるのはクラス内のみとなっている)
    /// </summary>
    public float MoveSpeedPercent { get; private set; } = 1.0f;

    CancellationTokenSource cts;

    /// <summary>
    /// 水に当たり始めたときに、ExitWaterで非同期処理させたDebuffSpeedTimeを強制終了させ、即座に移動速度を70%にする
    /// </summary>
    public void EnterWater()
    {
        CancelCurrentTask();
        MoveSpeedPercent = 0.7f;
    }
    /// <summary>
    /// 水から離れたときに、前回に処理させていたDebuffSpeedTimeがあれば、それを強制終了させて新たにDebuffSpeedTimeを処理させる
    /// </summary>
    /// <param name="lingertime">Showerクラスで測った、playerが水に当たっていた時間</param>
    public void ExitWater(int lingertime)
    {
        CancelCurrentTask();

        cts = new CancellationTokenSource();

        DebuffSpeedTime(lingertime,cts.Token).Forget();
    }
    
    async UniTaskVoid DebuffSpeedTime(int time,CancellationToken token)
    {
        MoveSpeedPercent = 0.7f;

        try
        {
            await UniTask.Delay(TimeSpan.FromSeconds(time),cancellationToken: token);

            MoveSpeedPercent = 1.0f;
        }
        catch(OperationCanceledException)
        {

        }
    }

    void CancelCurrentTask()
    {
        if(cts != null)
        {
            cts.Cancel();
            cts.Dispose();
            cts = null;
        }
    }
}
