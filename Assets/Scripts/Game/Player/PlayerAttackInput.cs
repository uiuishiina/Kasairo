using Assets.Scripts.StaticObject;
using UnityEngine;
using UnityEngine.InputSystem;
/// <summary>
/// playerがミシンなどのオブジェクトに触れたときの処理だけがあるクラス
/// </summary>
public class PlayerAttackInput : DotJudge
{
    //InputAction
    private InputAction AttackAction;

    Transform P_Body;
    /// <summary>
    /// この関数内で、PlayerAttackInput内のAttackActionにInputAction内のPlayerの中にあるAttackというActionが代入され、引数に入れたBodyがPlayerAttackInput内のP_Bodyに代入される
    /// </summary>
    /// <param name="body">Playerの体として定義しているもの</param>
    public PlayerAttackInput(Transform body)
    {
        AttackAction = StaticInputManager.Instance_.GetInputAction(
                         MapName.Player, "Attack");

        P_Body = body;
    }
    /// <summary>
    /// InputAction内のAttackに登録してあるキーを押すことによってAttack関数が処理される
    /// </summary>
    /// <param name="cont">登録したキーの入力値</param>
    void Attack(InputAction.CallbackContext cont)
    {
        if (cont.performed)
        {
            //光線が出る場所と方向を決める
            Ray ray = new Ray(P_Body.position, P_Body.forward);

            //光線が当たった結果を保持するための変数
            RaycastHit hit;

            //Physics.Raycast()自体はbool型の関数で、光線を放って結果が返ってきて、hitに保持されればtrueが返ってくる
            if (Physics.Raycast(ray, out hit, 5.0f))
            {
                //obj内にhitに入っているgameObjectを代入する
                GameObject obj = hit.collider.gameObject;

                //この時点でobjに何も入っていなければ処理はここで終わる
                if (obj == null) return;

                //内積を調べるためにDot関数にobjのtransformとP_Bodyを入れる
                float dot = Dot(obj.transform, P_Body);

                //obj内に入っているgameobjctのscriptがOtherObjectを継承していて、尚且つ内積がFrontに入っている値以上であれば結果としてOtherが返ってきて、Other内のObjectActionが処理される
                if (obj.TryGetComponent<OtherObject>(out var Other) && dot > DotJudge.Front)
                {
                    Other.ObjectAction();
                }
            }
        }
    }
    float Dot(Transform targettransform, Transform fromtransform)
    {
        Vector3 pos = (fromtransform.position - targettransform.position).normalized;

        float dot = Vector3.Dot(targettransform.forward, pos);

        return dot;
    }
    /// <summary>
    /// AttackInput内にあるAttack関数をAttackActionに登録する
    /// </summary>
    public void Subscribe()
    {
        AttackAction.performed += Attack;
    }
    /// <summary>
    /// Subscribeの逆でAttackActionからAttack関数を削除する
    /// </summary>
    public void Cancel()
    {
        AttackAction.performed -= Attack;
    }
}
