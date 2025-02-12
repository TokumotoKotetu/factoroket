using UnityEngine;
using Cinemachine;
public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject _menuPanel;
    [SerializeField] GameObject _craftPanel;
    [SerializeField] GameObject _rocket;
    [SerializeField] GameObject _virtualCamera;
    [SerializeField] GameObject _gameClearPanel;
    [SerializeField] GameObject _upgradePanel;
    [SerializeField] GameObject _optionPanel;
    Animator _anim;
    CinemachineVirtualCamera _cinemachine;
    public Inventory _inventory;
    bool _isGameCleared = false;

    void Start()
    {
        _menuPanel.SetActive(false);
        _craftPanel.SetActive(false);
        _gameClearPanel.SetActive(false);
        _upgradePanel.SetActive(false);
        _optionPanel.SetActive(false);
        _cinemachine = _virtualCamera.GetComponent<CinemachineVirtualCamera>(); 
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleMenu();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            ToggleCraftPanel();
        }

        if(Input.GetKeyDown(KeyCode.U)) 
        { 
            ToggleUpgradePanel();
        }

        if (_inventory.Rocket > 0)
        {
            GameClear();
        }
    }

    public void ToggleMenu()
    {
        if (_isGameCleared || _optionPanel.activeSelf) return;

        PlayerSoundManager.instance.PlayPressButtonSound();

        if(_menuPanel != null)
        {
            _menuPanel.SetActive(!_menuPanel.activeSelf);
        }
    }

    public void ToggleCraftPanel()
    {
        if(_isGameCleared) return;

        if (!_menuPanel.activeSelf)
        {
            ToggleMenu();
        }

        PlayerSoundManager.instance.PlayPressButtonSound();

        if (_craftPanel != null)
        {
            _craftPanel.SetActive(!_craftPanel.activeSelf);

            if (_upgradePanel.activeSelf == true)
            {
                _upgradePanel.SetActive(false);
            }
        }


    }

    public void ToggleUpgradePanel()
    {
        if (_isGameCleared) return;

        if (!_menuPanel.activeSelf)
        {
            ToggleMenu();
        }

        PlayerSoundManager.instance.PlayPressButtonSound();

        if (_upgradePanel != null)
        {
            _upgradePanel.SetActive(!_upgradePanel.activeSelf);

            if (_craftPanel.activeSelf == true)
            {
                _craftPanel.SetActive(false);
            }
        }
    }

    public void ToggleOptionPanel()
    {
        if (_isGameCleared) return;

        PlayerSoundManager.instance.PlayPressButtonSound();

        if (_optionPanel != null)
        {
            _optionPanel.SetActive(!_optionPanel.activeSelf);
        }
    }

    public void GameClear()
    {
        if (_isGameCleared) return;
        _isGameCleared = true;

        _menuPanel.SetActive(false);
        _optionPanel.SetActive(false);
        var tmp = Instantiate(_rocket);
        _anim = tmp.GetComponent<Animator>();
        _anim.SetBool("BlLaunch", true);

        _cinemachine.LookAt = tmp.transform;
        CameraShaker.instance.ShakeCamera(2f, 2f, 10f);
        PlayerSoundManager.instance.PlayRocketLaunchSound();
        Invoke("ShowClearPanel", 3f);
    }

    void ShowClearPanel()
    {
        _gameClearPanel.SetActive(true);
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}
