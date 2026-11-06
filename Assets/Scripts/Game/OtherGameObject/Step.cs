using UnityEngine;
/// <summary>
/// 段差のクラス
/// </summary>
public class Step : OtherObject
{
    const float YOffSet = 1.0f;
    /// <summary>
    /// 対象物のcollierの頂点を取得する関数
    /// </summary>
    /// <returns>対象物のcollierの頂点</returns>
    public Vector3 GetVaultTarget()
    {
        Collider mycol = GetComponent<Collider>();

        float topY = mycol.bounds.max.y;

        return new Vector3(transform.position.x,topY + YOffSet,transform.position.z);
    }
}
