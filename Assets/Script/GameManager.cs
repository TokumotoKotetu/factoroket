using UnityEngine;
using Cinemachine;
public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject _menuPanel;
    [SerializeField] GameObject _craftPanel;
    [SerializeField] GameObject _rocket;
    [SerializeField] GameObject _virtualCamera;
    [SerializeField] GameObject _gameClearPanel;
    Animator _anim;
    CinemachineVirtualCamera _cinemachine;
    public Inventory _inventory;
    bool _isGameCleared = false;

    void Start()
    {
        _menuPanel.SetActive(false);
        _craftPanel.SetActive(false);
        _gameClearPanel.SetActive(false);
        _cinemachine = _virtualCamera.GetComponent<CinemachineVirtualCamera>(); 
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleMenu();
        }

        if (_inventory.Rocket > 0)
        {
            GameClear();
        }
    }

    void ToggleMenu()
    {
        if (_isGameCleared) return;

        if(_menuPanel != null)
        {
            _menuPanel.SetActive(!_menuPanel.activeSelf);
        }
    }

    public void ToggleCraftMenu()
    {
        if(_isGameCleared) return;

        if (_craftPanel != null)
        {
            _craftPanel.SetActive(!_craftPanel.activeSelf);
        }
    }

    public void GameClear()
    {
        if (_isGameCleared) return;
        _isGameCleared = true;

        _menuPanel.SetActive(false);
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
}
