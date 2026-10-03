using UnityEngine;

namespace Assets.Utility.Time
{
    /// <summary>
    /// ゲーム内時間
    /// </summary>
    public static class GameTime
    {
        public static float DeltaTime => UnityEngine.Time.deltaTime;
    }

    /// <summary>
    /// リアル時間
    /// </summary>
    public static class RealTime
    {
        public static float DeltaTime => UnityEngine.Time.unscaledDeltaTime;
    }

}