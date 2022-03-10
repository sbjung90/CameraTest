using System.Runtime.CompilerServices;
using UnityEngine;

public class Log4Cs
{
    public delegate void LogListener(string message);
    static public event LogListener Listener;

    static public void Log(string message,
        [CallerFilePath] string file = "",
        [CallerLineNumber] int line = 0,
        [CallerMemberName] string member = "")
    {
        if (message == null)
        {
            return;
        }

#if UNITY_EDITOR
        Debug.Log($"{file}(Line:{line}) {member}:\n{message}");
#endif
        Listener?.Invoke($"{file}(Line:{line}) {member}:\n{message}");
    }

    static public void LogInfo(string message,
        [CallerFilePath] string file = "",
        [CallerLineNumber] int line = 0,
        [CallerMemberName] string member = "")
    {
#if UNITY_EDITOR
        Debug.Log($"{file}(Line:{line}) {member}:\n{message}");
#endif

        Listener?.Invoke($"{file}(Line:{line}) {member}:\n{message}");
    }

    static public void LogWarning(string message,
        [CallerFilePath] string file = "",
        [CallerLineNumber] int line = 0,
        [CallerMemberName] string member = "")
    {
#if UNITY_EDITOR
        Debug.LogWarning($"{file}(Line:{line}) {member}:\n{message}");
#endif

        Listener?.Invoke($"{file}(Line:{line}) {member}:\n{message}");
    }

    static public void LogError(string message,
        [CallerFilePath] string file = "",
        [CallerLineNumber] int line = 0,
        [CallerMemberName] string member = "")
    {
#if UNITY_EDITOR
        Debug.LogError($"{file}(Line:{line}) {member}:\n{message}");
#endif
        Listener?.Invoke($"{file}(Line:{line}) {member}:\n{message}");
    }

}
