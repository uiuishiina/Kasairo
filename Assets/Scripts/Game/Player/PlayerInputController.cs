using UnityEngine;
using UnityEngine.InputSystem;
using Assets.Scripts.StaticObject;
using System;
using Unity.VisualScripting;

namespace Assets.Scripts.Game.Player
{
    /// <summary>
    /// Playerの入力処理と移動・回転処理が組まれていて、これを付けると自動的にRigidBodyがゲームオブジェクトに付く
    /// </summary>
    /// RequireComponentで必要なコンポーネントが付くようにしてある
    [RequireComponent(typeof(CapsuleCollider), (typeof(Rigidbody)))]
    public class PlayerInputController : MonoBehaviour
    {
        /// <summary>
        /// PlayerMoveInputにJumpInputの中の関数を登録してもらうためのイベント変数
        /// </summary>
        public event Action OnJump;

        const float PlayerRange = 5.0f;
        //回転するための体
        [Tooltip("回転するための体")]
        [SerializeField] private Transform Body;

        [Header("入力設定")]
        //入力値の取得  
        Vector2 InputVer;

        /// <summary>
        /// 入力値の参照
        /// </summary>
        public Vector2 GetInputVer => InputVer;

        /// <summary>
        /// Playerの判定する範囲
        /// </summary>
        public float GetPlayerRange => PlayerRange;

        //InputAction
        private InputAction MoveAction;

        private InputAction AttackAction;

        private InputAction JumpAction;

        //-----Component取得-----
        PlayerAttackInput AttackInput;

        private void Awake()
        {
            var Cloth = this.GetComponent<OwnedClothing>();

            //InputActionの取得
            AttackAction = StaticInputManager.Instance_.GetInputAction(
                         MapName.Player, "Attack");

            JumpAction = StaticInputManager.Instance_.GetInputAction(
                          MapName.Player, "Jump");

            MoveAction = StaticInputManager.Instance_.GetInputAction(
                          MapName.Player, "Move");

            // AttackInputのコンストラクタ
            AttackInput = new PlayerAttackInput(Body,PlayerRange, Cloth);
        }

        private void OnCallAttack(InputAction.CallbackContext cont)
        {
            AttackInput?.Attack(cont);
        }

        private void OnCallJumpAction(InputAction.CallbackContext cont)
        {
            OnJump?.Invoke();
        }

        void OnEnable()
        {

            //InputSystemのAttackのキーを押している間の処理にAttackInput.Attack関数を登録する
            AttackAction.performed += OnCallAttack;

            //InputSystemのJumpのキーを押したときの処理にOnJumpイベントを登録する(こちらはMoveInput側でOnJumpに登録してもらった関数を登録している)
            //JumpAction.performed += _ => OnJump?.Invoke();
            JumpAction.performed +=OnCallJumpAction;
        }


        void OnDisable()
        {
            //InputSystemのAttackのキーを押している間の処理からAttackInput.Attack関数を解除する
            AttackAction.performed -= OnCallAttack;
            JumpAction.performed -= OnCallJumpAction;
        }


        private void OnDestroy()
        {
            JumpAction.performed -= null;
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
