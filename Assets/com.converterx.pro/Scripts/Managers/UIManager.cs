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
    [SerializeField] GameObject converter;

    public static Action OnMousePressed { get; set; } = delegate { };

    private void Awake()
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
        }

        navigation.SetActive(windowIndex > 0);
        _last.SetActive(true);
    }
}