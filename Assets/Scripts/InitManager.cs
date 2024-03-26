using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitManager : MonoBehaviour
{
    private GameObject startMenu;
    void Awake()
    {
        startMenu = GameObject.Find("StartMenu");
    }
    void Start()
    {
        startMenu.SetActive(true);
    }
}
