using UnityEngine.UI;
using UnityEngine;

public class TranslateMe : MonoBehaviour
{
    [SerializeField, TextArea] string ru;
    [SerializeField, TextArea] string en;

    private void OnEnable()
    {
        Translate();
    }

    public void Translate()
    {
        GetComponent<Text>().text = AppManger.Instance.GetLanguage() > 0 ? ru : en;
    }
}
