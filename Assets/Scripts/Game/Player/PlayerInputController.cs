using UnityEngine;
using UnityEngine.InputSystem;
using Assets.Scripts.StaticObject;

namespace Assets.Scripts.Game.Player
{
    /// <summary>
    /// Playerの入力処理と移動・回転処理が組まれていて、これを付けると自動的にRigidBodyがゲームオブジェクトに付く
    /// </summary>
    /// RequireComponentで必要なコンポーネントが付くようにしてある
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerInputController : MonoBehaviour
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

        //-----Component取得-----

        //InputAction
        private InputAction MoveAction;

        //InputSystem管理Script
        private StaticInputManager StaticInputManager_;

        //-----Component取得-----
        Rigidbody rb;

        void Start()
        {
            rb = GetComponent<Rigidbody>();

            StaticInputManager_ = StaticInputManager.Instance_;


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

                Move(InputVer);
            }
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
        /// <param name="input"></param>
        /// <returns></returns>
        private Vector3 CalculateMove(Vector2 input)
        {
            return new Vector3(input.x, 0, input.y) * Speed * Time.fixedDeltaTime;
        }

        /// <summary>
        /// 回転先を計算
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private Quaternion CalculateRotation(Vector2 input)
        {
            //Vector3に変換
            var dir = new Vector3(input.x, 0, input.y);

            //決めた回転方向をtargetRotationに代入している
            var targetRotation = Quaternion.LookRotation(dir, Vector3.up);

            //回転
            return Quaternion.Slerp(Body.rotation, targetRotation, RotaSpeed * Time.fixedDeltaTime);
        }
    }
}
