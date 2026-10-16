using UnityEngine;

namespace Assets.Utility.Time
{
    /// <summary>
    /// ゲーム内時間
    /// </summary>
    public static class GameTime
    {
        public static float DeltaTime => UnityEngine.Time.deltaTime;

        public static float FixedDeltaTime => UnityEngine.Time.fixedDeltaTime;
    }

    /// <summary>
    /// リアル時間
    /// </summary>
    public static class RealTime
    {
        public static float DeltaTime => UnityEngine.Time.unscaledDeltaTime;
    }

}