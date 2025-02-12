using UnityEngine.UI;
using UnityEngine;

public class TitleManager : MonoBehaviour
{
    [SerializeField] Text _verText;

    void Start()
    {
        _verText.text = $"Ver.{Application.version}";
    }
}
