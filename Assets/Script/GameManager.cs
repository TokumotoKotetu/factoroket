using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool _isMenu = false;
    bool _isCraftMenu = false;
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
        _MenuPanel.SetActive(_isMenu);
        _isMenu = !_isMenu;
    }

    public void ToggleCraftMenu()
    {
        _CraftPanel.SetActive(_isCraftMenu);
        _isCraftMenu = !_isCraftMenu;
    }
}
