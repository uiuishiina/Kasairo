using UnityEngine;
/// <summary>
/// 内積を取るために使うinterface
/// </summary>
public static class DotJudge
{
    //前方にいるかどうかの基準値
    static float Front = 0.0f;
    /// <summary>
    /// 基準とする物と対象物を入れると基準とするものから見てどの方向にいるかが返ってくる関数
    /// </summary>
    /// <param name="targetpos">対象物の座標</param>
    /// <param name="fromtransform">基準とする物の座標</param>
    /// <returns>どの方向にいるか</returns>
    public static GameObject Dot(Transform fromtransform,float judgerange)
    {
        //光線が出る場所と方向を決める
        Ray ray = new Ray(fromtransform.position, fromtransform.forward);

        //光線が当たった結果を保持するための変数
        RaycastHit hit;

        //Physics.Raycast()自体はbool型の関数で、光線を放って結果が返ってきて、hitに保持されればtrueが返ってくる
        if (Physics.Raycast(ray, out hit, judgerange))
        {
            //obj内にhitに入っているgameObjectを代入する
            GameObject obj = hit.collider.gameObject;

            //この時点でobjに何も入っていなければ処理はここで終わる
            if (obj == null) return null;

            Vector3 pos = (fromtransform.position - obj.transform.position).normalized;

            //内積を調べるためにDot関数にobjのtransformとP_Bodyを入れる
            float dot = Vector3.Dot(obj.transform.forward, pos);

            //obj内に入っているgameobjctのscriptがOtherObjectを継承していて、尚且つ内積がFrontに入っている値以上であれば結果としてOtherが返ってきて、Other内のObjectActionが処理される
            if (obj.TryGetComponent<OtherObject>(out var Other) && dot > Front)
            {
                return Other.gameObject;
            }
        }
        return null;
    }
}
