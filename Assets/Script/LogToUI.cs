using UnityEngine.UI;
using UnityEngine;

public class LogToUI : MonoBehaviour
{
    public static LogToUI Instance { get; private set; }

    public Text _debugText;//ゲーム画面に表示するテキスト
    public ScrollRect _scrollRect;

    string _accumulatedLogs = "";

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ShowLog(string message)
    {
        _accumulatedLogs += message + "\n";
        _debugText.text = _accumulatedLogs;

        Canvas.ForceUpdateCanvases();
        _scrollRect.verticalNormalizedPosition = 0f;
    }

    public void ShowDebugLog(string message)
    {
        Debug.Log(message);
        ShowLog(message);
    }

    public void ShowWarningLog(string message)
    {
        Debug.LogWarning(message);  // コンソールにも警告として表示
        _accumulatedLogs += $"<color=red>{message}</color>\n";  // 赤色でメッセージを追加
        _debugText.text = _accumulatedLogs;

        Canvas.ForceUpdateCanvases();  // UIの更新を強制
        _scrollRect.verticalNormalizedPosition = 0f;  // スクロール位置をトップに設定
    }
}
