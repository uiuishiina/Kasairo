using UnityEngine;

namespace Assets.Scripts.StaticObject
{
    /// <summary>
    /// GameSceneカラー設定クラス
    /// </summary>
    public class StaticColorManager : StaticObject<StaticColorManager>
    {
        /// <summary>
        /// カラー設定
        /// </summary>
        [SerializeField] ColorSettings _colorSettings;
        
        /// <summary>
        /// 読み取り用
        /// </summary>
        public ColorSettings ColorSettings => _colorSettings;

        protected override void Initialize()
        { 
            if(_colorSettings == null)
            {
                Debug.LogError("StaticColorManager _colorSettings is Null");
            }
        }
    }
}