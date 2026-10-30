using Assets.Scripts.Game.Player;
using Assets.Scripts.StaticObject;
using Assets.Utility.Time;
using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;
/// <summary>
/// playerが段差を跳び越える処理があるクラス
/// </summary>
public class PlayerJumpInput
{
    Transform P_Body;

    Rigidbody Rb;

    PlayerInputController Player;

    CancellationTokenSource cts;

    const float jumpHeight = 1.5f;

    readonly float P_Range;
    /// <summary>
    /// playerが跳び越えている最中かを知らせる変数
    /// </summary>
    public bool IsJump { get; private set; } = false;
    /// <summary>
    /// この関数内で、跳び越えるのに必要なplayerの体やPlayerInputController、RigidbodyをPlayerJumpInput内に渡している
    /// </summary>
    /// <param name="body">playerの体</param>
    /// <param name="player">参照するクラス</param>
    /// <param name="rb">playerの物理演算</param>
    public PlayerJumpInput(Transform body,PlayerInputController player, Rigidbody rb,float range)
    {
        P_Body = body;

        Rb = rb;

        P_Range = range;
    }
    /// <summary>
    /// InputAction内のJumpに登録してあるキーを押すことによってJump関数が処理される
    /// </summary>
    /// <param name="cont">登録したキーの入力値</param>
    public void Jump(InputAction.CallbackContext cont)
    {
        var obj = DotJudge.Dot(P_Body,P_Range);

        if (obj == null) return;

        var step = obj.gameObject.GetComponent<Step>();

        if (step == null) return;

        ExecuteStepJump(step.GetVaultTarget());
    }
    void ExecuteStepJump(Vector3 targetpos)
    {
        if(cts != null)
        {
            cts.Cancel();
            cts.Dispose();
        }

        cts = new CancellationTokenSource();

        StepJump(targetpos, cts.Token).Forget();
    }
    /// <summary>
    /// 段差を跳び越える処理を行っている関数
    /// </summary>
    /// <param name="targetpos">段差の上の面の場所</param>
    /// <param name="token"></param>
    /// <returns></returns>
    async UniTaskVoid StepJump(Vector3 targetpos, CancellationToken token)
    {
        //関数の処理が始まったらbool変数をtrueにして、処理が始まっていることを知らせる
        IsJump = true;

        Rb.isKinematic = true;

        //自分自身を始点とする
        Vector3 startpos = Player.transform.position;

        //何秒かけて跳び越えるかを決める
        float duration = 0.5f;

        //設定した時間の内、今どれくらい経っているかの値をもつ
        float time = 0;

        try
        {
            while (time < duration)
            {
                time += GameTime.FixedDeltaTime;

                float percent = time / duration;

                Vector3 basepos = Vector3.Lerp(startpos, targetpos, percent);

                float heightOffset = Mathf.Sin(percent * Mathf.PI) * jumpHeight;

                basepos.y += heightOffset;

                Player.transform.position = basepos;

                await UniTask.WaitForFixedUpdate(cancellationToken: token);
            }
        }
        finally
        {
            Rb.isKinematic = false;
            IsJump = false;
        }
    }
}
