using System;
using UnityEngine;

public class AppManger : MonoBehaviour
{
    public static AppManger Instance { get => FindObjectOfType<AppManger>(); }
}