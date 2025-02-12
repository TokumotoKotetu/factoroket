using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class AutoMiner : MonoBehaviour
{
    public Inventory _inventory;
    [SerializeField] float _interval = 5f;
    Coroutine _miningCoroutine;
    public Slider _intervalSlider;
    bool _isAutoMining = false;
    [SerializeField] GameObject _intervalSliderObj;
    private void Start()
    {
        _intervalSlider.minValue = 0f;
        _intervalSlider.maxValue = 5f;
        _intervalSlider.value = _intervalSlider.maxValue;
        _intervalSliderObj.SetActive(false);
        _isAutoMining = false;

    }
    void Update()
    {
        if(_inventory.AutoMiner > 0)
        {
            if (_miningCoroutine == null)//ÌŒ@‚³‚ê‚Ä‚¢‚È‚¢ê‡‚Ì‚ÝŠJŽn
            {
                _miningCoroutine = StartCoroutine(Mining());
                _intervalSliderObj.SetActive(true);
            }
        }

        
    }

    IEnumerator Mining()
    {
        _isAutoMining = true;
        while (_isAutoMining)
        {


            float timeLeft = _interval;
            _intervalSlider.value = _interval;

            while (timeLeft > 0f)
            {
                timeLeft -= Time.deltaTime;
                _intervalSlider.value = timeLeft;
                yield return null;
            }

            _inventory.AddItem("Iron", _inventory.AutoMiner);
            _inventory.AddItem("Iron", _inventory.AutoMiner);
        }
    }
}
