using UnityEngine;
using UnityEngine.InputSystem;
using Assets.Scripts.StaticObject;

namespace Assets.Scripts.Game.Player
{
    /// <summary>
    /// Playerの入力処理と移動・回転処理が組まれていて、これを付けると自動的にRigidBodyがゲームオブジェクトに付く
    /// </summary>
    /// RequireComponentで必要なコンポーネントが付くようにしてある
    [RequireComponent(typeof(CapsuleCollider))]
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerInputController : MonoBehaviour
    {
        const float PlayerRange = 5.0f;
        //回転するための体
        [Tooltip("回転するための体")]
        [SerializeField] private Transform Body;

        [Header("入力設定")]
        //入力値の取得  
        Vector2 InputVer;

        //入力値の参照
        public Vector2 GetInputVer => InputVer;

        //Playerの判定する範囲
        public float GetPlayerRange => PlayerRange;

        //InputAction
        private InputAction MoveAction;

        private InputAction AttackAction;

        private InputAction JumpAction;

        //-----Component取得-----
        PlayerAttackInput AttackInput;

        PlayerMoveInput MoveInput;
        void Awake()
        {
            //InputActionの取得
            AttackAction = StaticInputManager.Instance_.GetInputAction(
                         MapName.Player, "Attack");

            JumpAction = StaticInputManager.Instance_.GetInputAction(
                          MapName.Player, "Jump");

            MoveAction = StaticInputManager.Instance_.GetInputAction(
                          MapName.Player, "Move");

            // AttackInputのコンストラクタ
            AttackInput = new PlayerAttackInput(Body,PlayerRange);

            MoveInput = GetComponent<PlayerMoveInput>();
        }

        void OnEnable()
        {
            AttackAction.performed += AttackInput.Attack;
            JumpAction.performed += MoveInput.JumpInput.Jump;
        }

        void OnDisable()
        {
            AttackAction.performed -= AttackInput.Attack;
            JumpAction.performed -= MoveInput.JumpInput.Jump;
        }
        void Update()
        {
            //移動入力取得
            if (MoveAction != null)
            {
                InputVer = MoveAction.ReadValue<Vector2>();
            }
        }
    }
}
