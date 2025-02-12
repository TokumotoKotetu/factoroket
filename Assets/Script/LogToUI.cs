using UnityEngine.UI;
using UnityEngine;

public class LogToUI : MonoBehaviour
{
    public static LogToUI Instance { get; private set; }

    public Text _debugText;//�Q�[����ʂɕ\������e�L�X�g
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
        Debug.LogWarning(message);  // �R���\�[���ɂ��x���Ƃ��ĕ\��
        _accumulatedLogs += $"<color=red>{message}</color>\n";  // �ԐF�Ń��b�Z�[�W��ǉ�
        _debugText.text = _accumulatedLogs;

        Canvas.ForceUpdateCanvases();  // UI�̍X�V������
        _scrollRect.verticalNormalizedPosition = 0f;  // �X�N���[���ʒu���g�b�v�ɐݒ�
    }
}
