using UnityEngine;
using UnityEngine.Rendering;

public class MoveController : MonoBehaviour
{
    [Header("移動設定")]
    //移動速度
    [SerializeField] private float Speed = 500.0f;
    //回転速度
    [SerializeField] private float RotaSpeed = 10.0f;
    //入力値の取得  
    Vector2 InputVer;

    //-----Component取得-----
    Rigidbody rb;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// 入力値をSetする
    /// </summary>
    /// <param name="input">入力値</param>
    public void SetInputVer(Vector2 input)
    {
        InputVer = input;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move(InputVer);
    }

    /// <summary>
    /// 移動,回転処理
    /// </summary>
    private void Move(Vector2 input)
    {
        //移動
        var move = CalculateMove(input);
        rb.linearVelocity = move;

        if (move != Vector3.zero)
        {
            //回転
            var targetRotation = CalculateRotation(input);
            rb.MoveRotation(Quaternion.Slerp(rb.rotation, targetRotation, RotaSpeed * Time.fixedDeltaTime));

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
        //回転
        return Quaternion.LookRotation(dir, Vector3.up);
    }

}
