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

        //-----Component取得-----

        //InputAction
        private InputAction MoveAction;
        private InputAction AttackAction;

        //-----Component取得-----
        Rigidbody rb;

        void Start()
        {
            rb = GetComponent<Rigidbody>();

            //InputActionの取得
            MoveAction = StaticInputManager.Instance_.GetInputAction(
                          MapName.Player, "Move");

            AttackAction=StaticInputManager.Instance_.GetInputAction(
                          MapName.Player, "Attack");

            AttackAction.performed += Attack;
        }

        void Attack(InputAction.CallbackContext cont)
        {
            if(cont.performed)
            {
                Ray ray = new Ray(Body.position, Body.forward);

                RaycastHit hit;

                if(Physics.Raycast(ray,out hit,5.0f))
                {
                    GameObject obj = hit.collider.gameObject;

                    if (obj==null) return;

                    float dot = Dot(obj.transform,Body);

                    Debug.Log(dot);

                    if (obj.TryGetComponent<OtherObject>(out var Other)&&dot > DotJudge.Front)
                    {
                        //Other.ObjectAction();
                    }
                }
            }
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

        float Dot(Transform targettransform, Transform fromtransform)
        {
            Vector3 pos = (fromtransform.position - targettransform.position).normalized;

            float dot = Vector3.Dot(targettransform.forward, pos);

            return dot;
        }
    }
}
