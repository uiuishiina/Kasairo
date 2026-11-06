using Assets.Scripts.Game.Player;
using Assets.Utility.Time;
using UnityEngine;
using System.Collections;
/// <summary>
/// Playerの移動に関する処理があるクラス
/// </summary>
public class PlayerMoveInput : MonoBehaviour
{
    Coroutine DebuffCoroutine;

    //回転するための体
    [Tooltip("回転するための体")]
    [SerializeField] private Transform Body;
    [Header("移動設定")]
    //移動速度
    [SerializeField] private float Speed = 500.0f;

    //移動速度の割合
    float MoveSpeedPercent = 1.0f;

    //回転速度
    [SerializeField] private float RotaSpeed = 10.0f;

    //-----Component取得-----
    Rigidbody rb;

    PlayerInputController PlayerInput;

    public PlayerJumpInput JumpInput;
    void Awake()
    {
        //Rigidbodyの取得
        rb = GetComponent<Rigidbody>();

        //PlayerInputControllerの取得
        PlayerInput = GetComponent<PlayerInputController>();

        // JumpInputのコンストラクタ
        JumpInput = new PlayerJumpInput(Body, this, rb, PlayerInput.GetPlayerRange);
    }
    void OnEnable()
    {
        // JumpActionのイベント登録
        PlayerInput.OnJump += JumpInput.Jump;
    }
    void OnDisable()
    {
        // JumpActionのイベント解除
        PlayerInput.OnJump -= JumpInput.Jump;
    }
    void FixedUpdate()
    {
        if (JumpInput.IsJump) return;

        //動作処理
        Move(PlayerInput.GetInputVer);
    }
    /// <summary>
    /// 移動,回転処理
    /// </summary>
    void Move(Vector2 input)
    {
        //移動
        var move = CalculateMove(input);

        //移動量をRigidBodyに入れてる
        rb.linearVelocity = move;

        //入力したときだけ子オブジェクトを移動方向に回転させる
        if (move != Vector3.zero)
        {
            //回転
            Body.rotation = CalculateRotation(input);
        }
    }

    /// <summary>
    /// 移動量計算
    /// </summary>
    /// <param name="input">PlayerInputの入力値</param>
    /// <returns>入力値をVectro3に変換したものに移送速度とGameTimeクラスにあるFixedDeltaTimeを掛けた値</returns>
    private Vector3 CalculateMove(Vector2 input)
    {
        return new Vector3(input.x, 0, input.y) * (Speed * MoveSpeedPercent) * GameTime.FixedDeltaTime;
    }

    /// <summary>
    /// Y軸の回転量を計算
    /// </summary>
    /// <param name="input">PlayerInputの入力値</param>
    /// <returns>Quaternion.Slerpで計算した回転量</returns>
    private Quaternion CalculateRotation(Vector2 input)
    {
        //Vector3に変換
        var dir = new Vector3(input.x, 0, input.y);

        //決めた回転方向をtargetRotationに代入している
        var targetRotation = Quaternion.LookRotation(dir, Vector3.up);

        //回転
        return Quaternion.Slerp(Body.rotation, targetRotation, RotaSpeed * GameTime.FixedDeltaTime);
    }

    public void EnterWaterDebuff(PrimaryColorState state)
    {
        PlayerInput.ShowerEnter(state);
        if (DebuffCoroutine != null)
        {
            StopCoroutine(DebuffCoroutine);
            DebuffCoroutine = null;
        }
        MoveSpeedPercent = 0.7f;
    }
    /// <summary>
    /// PlayerSpeedModifier内のExitWaterを処理させる関数
    /// </summary>
    public void ExitWaterDebuff(int lingertime)
    {
        DebuffCoroutine = StartCoroutine(DebuffSpeedTime(lingertime));
    }

    IEnumerator DebuffSpeedTime(int time)
    {
        MoveSpeedPercent = 0.7f;
        yield return new WaitForSeconds(time);
        MoveSpeedPercent = 1.0f;
    }
}
