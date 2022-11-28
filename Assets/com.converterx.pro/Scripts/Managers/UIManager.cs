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

        TranslateInputs();
    }

    public void TranslateInputs()
    {
        inputCur.options[0].text = AppManger.Instance.GetLanguage() > 0 ? "Выберите валюту ввода" : "Choose input currency";
        outputCur.options[0].text = AppManger.Instance.GetLanguage() > 0 ? "Выберите выходную валюту" : "Choose output currency";

        inputCur.transform.GetChild(0).GetComponent<Text>().text = inputCur.options[inputCur.value].text;
        outputCur.transform.GetChild(0).GetComponent<Text>().text = outputCur.options[outputCur.value].text;
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
        if(windowIndex == 2)
        {
            inputCur.value = 0;
            outputCur.value = 0;
        }

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