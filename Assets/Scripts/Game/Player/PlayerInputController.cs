using UnityEngine;
using UnityEngine.InputSystem;
using Assets.Scripts.StaticObject;
public class PlayerInputController : MonoBehaviour
{
    [Header("入力設定")]
    //入力値の取得  
    Vector2 InputVer;
    //入力値の参照
    public Vector2 GetInputVer => InputVer;

    //-----Component取得-----
    //InputAction
    private InputAction MoveAction;

    //-----Script取得-----
    //MoveController管理Script
    private MoveController MoveController;
    //InputSystem管理Script
    private StaticInputManager StaticInputManager_; 

    void Start()
    {
        StaticInputManager_ = StaticInputManager.Instance_;
        MoveController = GetComponent<MoveController>();

        //InputActionの取得
        MoveAction = StaticInputManager.Instance_.GetInputAction(
                      MapName.Player,"Move");
    }

    void Update()
    {
        //移動入力取得
        if (MoveAction != null)
        {
            InputVer = MoveAction.ReadValue<Vector2>();
            //MoveControllerに入力値を渡す
            MoveController.SetInputVer(InputVer);
        }
    }
}
