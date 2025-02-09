using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject _MenuPanel;
    [SerializeField] GameObject _CraftPanel;

    void Start()
    {
        _MenuPanel.SetActive(false);
        _CraftPanel.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleMenu();
        }
    }

    void ToggleMenu()
    {
        if(_MenuPanel != null)
        {
            _MenuPanel.SetActive(!_MenuPanel.activeSelf);
        }
    }

    public void ToggleCraftMenu()
    {
        if (_CraftPanel != null)
        {
            _CraftPanel.SetActive(!_CraftPanel.activeSelf);
        }
    }
}
