using System.Collections;
using UnityEngine;

/*
 * Custom Gui Logger for printing Console logs into scene.
 */
public class GuiLogger : MonoBehaviour
{
    private Vector2 _scrollPosition;
    private readonly Queue _myLogQueue = new Queue();

    private void OnEnable()
    {
        Application.logMessageReceived += HandleLog;
    }

    private void OnDisable()
    {
        Application.logMessageReceived -= HandleLog;
    }

    void HandleLog(string logString, string stackTrace, LogType type)
    {
        var log = "[" + type + "] : " + logString;
        _myLogQueue.Enqueue(log);
        if (type == LogType.Exception)
        {
            _myLogQueue.Enqueue(stackTrace);
        }
    }

    private void OnGUI()
    {
        _scrollPosition = GUILayout.BeginScrollView(_scrollPosition, GUILayout.Width(Screen.width-10), GUILayout.Height(Screen.height-10));
        var style = GUI.skin.label;
        style.fontSize = 24;
        GUILayout.Label("\n" + string.Join("\n", _myLogQueue.ToArray()), style);
        GUILayout.EndScrollView();
    }
}
