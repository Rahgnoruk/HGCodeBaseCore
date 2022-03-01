using UnityEngine;

namespace HyperGnosys.Core
{
    public static class HGDebug
    {
        public static void Log(string message, bool debugging)
        {
            if (debugging)
            {
                Debug.Log(message);
            }
        }
        public static void Log(string message, Object context, bool debugging)
        {
            if (debugging)
            {
                Debug.Log(message, context);
            }
        }
        public static void LogWarning(string message, bool debugging)
        {
            if (debugging)
            {
                Debug.LogWarning(message);
            }
        }
        public static void LogWarning(string message, Object context, bool debugging)
        {
            if (debugging)
            {
                Debug.LogWarning(message, context);
            }
        }
        public static void LogError(string message, bool debugging)
        {
            if (debugging)
            {
                Debug.LogError(message);
            }
        }
        public static void LogError(string message, Object context, bool debugging)
        {
            if (debugging)
            {
                Debug.LogError(message, context);
            }
        }
        public static void DrawRay(Vector3 start, Vector3 dir, bool debugging)
        {
            if (debugging)
            {
                Debug.DrawRay(start, dir);
            }
        }
        public static void DrawRay(Vector3 start, Vector3 dir, bool debugging, Color color)
        {
            if (debugging)
            {
                Debug.DrawRay(start, dir, color);
            }
        }
        public static void DrawLine(Vector3 start, Vector3 end, bool debugging)
        {
            if (debugging)
            {
                Debug.DrawLine(start, end);
            }
        }
        public static void DrawLine(Vector3 start, Vector3 end, bool debugging, Color color)
        {
            if (debugging)
            {
                Debug.DrawLine(start, end, color);
            }
        }
        public static void DrawLine(Vector3 start, Vector3 end, bool debugging, Color color, float duration)
        {
            if (debugging)
            {
                Debug.DrawLine(start, end, color, duration);
            }
        }
    }
}