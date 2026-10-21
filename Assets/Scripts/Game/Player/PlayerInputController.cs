using UnityEngine;
using UnityEngine.InputSystem;
using Assets.Scripts.StaticObject;
using Assets.Utility.Time;

namespace Assets.Scripts.Game.Player
{
    /// <summary>
    /// Playerの入力処理と移動・回転処理が組まれていて、これを付けると自動的にRigidBodyがゲームオブジェクトに付く
    /// </summary>
    /// RequireComponentで必要なコンポーネントが付くようにしてある
    [RequireComponent(typeof(CapsuleCollider))]
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerInputController : MonoBehaviour,DotJudge
    {
        //回転するための体
        [Tooltip("回転するための体")]
        [SerializeField] private Transform Body;

        [Header("移動設定")]

        //移動速度
        [SerializeField] private float Speed = 500.0f;

        //回転速度
        [SerializeField] private float RotaSpeed = 10.0f;

        [Header("入力設定")]

        //入力値の取得  
        Vector2 InputVer;

        //入力値の参照
        public Vector2 GetInputVer => InputVer;

        //InputAction
        private InputAction MoveAction;

        //-----Component取得-----
        Rigidbody rb;

        PlayerAttackInput AttackInput;

        void Awake()
        {
            // AttackInputのコンストラクタ
            AttackInput = new PlayerAttackInput(Body);
        }

        void OnEnable()
        {
            AttackInput.Subscribe();
        }

        void OnDisable()
        {
            AttackInput.Cancel();
        }

        void Start()
        {
            rb = GetComponent<Rigidbody>();

            //InputActionの取得
            MoveAction = StaticInputManager.Instance_.GetInputAction(
                          MapName.Player, "Move");
        }
        void Update()
        {
            //移動入力取得
            if (MoveAction != null)
            {
                InputVer = MoveAction.ReadValue<Vector2>();
            }
        }

        private void FixedUpdate()
        {
            //動作処理
            Move(InputVer);
        }

        /// <summary>
        /// 移動,回転処理
        /// </summary>
        private void Move(Vector2 input)
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
            return new Vector3(input.x, 0, input.y) * Speed * GameTime.FixedDeltaTime;
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
    }
}
