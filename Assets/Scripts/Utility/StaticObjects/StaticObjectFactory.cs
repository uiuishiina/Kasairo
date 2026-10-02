using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// StaticObject用名前空間
/// </summary>
namespace Assets.Scripts.StaticObject
{
    /// <summary>
    /// StaticObject生成クラス
    /// </summary>
    public class StaticObjectFactory : MonoBehaviour
    {
        [SerializeField, Header("StaticObjectPrefabリスト")]
        private List<StaticObjectBase> ObjectList_ = new();

        /// <summary>
        /// インスタンス生成時実行関数
        /// </summary>
        private void Awake()
        {
            //  リスト内オブジェクト一括生成
            foreach(var obj in ObjectList_)
            {
                Instantiate(obj);
            }

            //  生成したら自身は削除
            Destroy(gameObject);
        }
    }
}