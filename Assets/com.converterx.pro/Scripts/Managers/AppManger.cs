using UnityEngine;

public class AppManger : MonoBehaviour
{
    public static AppManger Instance { get => FindObjectOfType<AppManger>(); }

    private const string languageSaveKey = "languageSaveKey";
    [SerializeField] TranslateMe[] translateMes;

    public float GetResult(Format input, Format output, float value)
    {
        float result = 0;

        if(input == Format.RUB && output == Format.USD)
        {
            result = value * 0.016f;
        }
        else if (input == Format.RUB && output == Format.EUR)
        {
            result = value * 0.015f;
        }
        else if (input == Format.USD && output == Format.EUR)
        {
            result = value * 0.96f;
        }
        else if (input == Format.EUR && output == Format.USD)
        {
            result = value * 1.04f;
        }
        else if (input == Format.USD && output == Format.RUB)
        {
            result = value * 61.45f;
        }
        else if (input == Format.EUR && output == Format.RUB)
        {
            result = value * 64.11f;
        }

        return result;
    }

    public void SetLanguage(int languageId)
    {
        PlayerPrefs.SetInt(languageSaveKey, languageId);
        PlayerPrefs.Save();

        FindObjectOfType<UIManager>().TranslateInputs();

        foreach(TranslateMe translateMe in translateMes)
        {
            translateMe.Translate();
        }
    }

    public int GetLanguage()
    {
        return PlayerPrefs.HasKey(languageSaveKey) ? PlayerPrefs.GetInt(languageSaveKey) : 0;
    }
}