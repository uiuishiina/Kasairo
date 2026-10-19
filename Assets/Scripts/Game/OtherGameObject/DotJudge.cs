using UnityEngine;
/// <summary>
/// 内積を取るために使うinterface
/// </summary>
public interface DotJudge
{
    public const float a = 1.0f;
    //前方にいるかどうかの基準値
    const float Front = 0.0f;
    /// <summary>
    /// 基準とする物と対象物を入れると基準とするものから見てどの方向にいるかが返ってくる関数
    /// </summary>
    /// <param name="targetpos">対象物の座標</param>
    /// <param name="fromtransform">基準とする物の座標</param>
    /// <returns>どの方向にいるか</returns>
    float Dot(Vector3 targetpos,Transform fromtransform)
    {
        Vector3 pos = (targetpos - fromtransform.position).normalized;

        float dot = Vector3.Dot(fromtransform.forward,pos);

        return dot;
    }
}
