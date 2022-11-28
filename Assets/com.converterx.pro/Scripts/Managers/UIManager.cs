using System;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private GameObject _last = null;

    [SerializeField] GameObject navigation;

    [Space(10)]
    [SerializeField] GameObject getStarted;
    [SerializeField] GameObject menu;
    [SerializeField] GameObject settings;
    [SerializeField] GameObject converter;

    [Space(10)]
    [SerializeField] Dropdown inputCur;
    [SerializeField] InputField enter;
    [SerializeField] Dropdown outputCur;

    [Space(10)]
    [SerializeField] Text resultText;

    public static Action OnMousePressed { get; set; } = delegate { };

    private void Awake()
    {
        resultText.text = string.Empty;
    }

    private void Start()
    {
        navigation.SetActive(false);
        OpenWindow(0);
    }

    public void OpenWindow(int windowIndex)
    {
        if(_last)
        {
            _last.SetActive(false);
        }

        switch(windowIndex)
        {
            case 0: _last = getStarted; break;
            case 1: _last = menu; break;
            case 2: _last = converter; break;
            case 3: _last = settings; break;
        }

        navigation.SetActive(windowIndex > 0);
        _last.SetActive(true);
    }

    public void Convert()
    {
        if (enter.text == string.Empty || inputCur.options[inputCur.value].text == "Choose input currency" || outputCur.options[outputCur.value].text == "Choose output currency")
        {
            return;
        }

        Format inputFormat = GetFormat(inputCur.options[inputCur.value].text);
        Format outputFormat = GetFormat(outputCur.options[outputCur.value].text);

        int value = int.Parse(enter.text);

        resultText.text = $"RESULT:\n{value} {inputFormat}\n=\n{AppManger.Instance.GetResult(inputFormat, outputFormat, value)} {outputFormat}";
    }

    private Format GetFormat(string stringFormat) => stringFormat switch
    {
        "Русский Рубль(RUB)" => Format.RUB,
        "US Dollar (USD)" => Format.USD,
        "Euro (EUR)" => Format.EUR,
    };
}