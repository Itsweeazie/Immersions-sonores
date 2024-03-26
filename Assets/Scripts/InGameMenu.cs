using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class InGameMenu : MonoBehaviour
{
    public animationBehaviour animationBehaviour_script;
    // L'index de l'animation selectionnée sur le dropdown

    [Header("UI Pages")]
    public GameObject mainMenu;

    [Header("Main Menu Buttons")]
    public Button applyButton;
    public Button closeButton;

    public List<Button> returnButtons;

    public int animationDropdownValue;
    public int sceneDropdownValue;
    public int musiqueDropdownValue;

    public void animationHandleInputData(int val)
    {
        if (val == 0)
        {
            animationBehaviour_script.animationIndex = 1;
            Debug.Log("anim1");
        }
        if (val == 1)
        {
            animationBehaviour_script.animationIndex = 2;
            Debug.Log("anim2");
        }
        if (val == 2)
        {
            animationBehaviour_script.animationIndex = 3;
            Debug.Log("anim3");
        }
        if (val == 3)
        {
            animationBehaviour_script.animationIndex = 4;
            Debug.Log("anim3");
        }
    }

    public void sceneHandleInputData(int val)
    {
        if (val == 0)
        {
            sceneDropdownValue = 0;
            //animationBehaviour_script.animationIndex = 1;
        }
        if (val == 1)
        {
            sceneDropdownValue = 1;
            //animationBehaviour_script.animationIndex = 2;
        }
        if (val == 2)
        {
            sceneDropdownValue = 2;
            //animationBehaviour_script.animationIndex = 3;
        }
    }

    public void musiqueHandleInputData(int val)
    {
        if (val == 0)
        {
            musiqueDropdownValue = 0;
            Debug.Log("musique 0");
        }
        if (val == 1)
        {
            musiqueDropdownValue = 1;
            Debug.Log("musique 1");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //Hook events
        applyButton.onClick.AddListener(ApplyChanges);
        closeButton.onClick.AddListener(DisableInGameMenu);

        foreach (var item in returnButtons)
        {
            item.onClick.AddListener(EnableInGameMenu);
        }

        DisableInGameMenu();
    }
    public void ApplyChanges()
    {
        //applying scene change
        if (sceneDropdownValue == 0)
        {
            SceneManager.LoadScene("Oihan_Lobby");
        }
        else if (sceneDropdownValue == 1)
        {
            SceneManager.LoadScene("Oihan_Boxe");
        }
        else if (sceneDropdownValue == 2)
        {
            SceneManager.LoadScene("Oihan_Danse");
        }
        //applying animations
        //animationBehaviour_script.animator.SetInteger("animationIndex", animationBehaviour_script.animationIndex);
        //closing in game menu
        DisableInGameMenu();
    }
    public void EnableInGameMenu()
    {
        mainMenu.SetActive(true);
    }

    public void DisableInGameMenu()
    {
        mainMenu.SetActive(false);
    }

    private void Update()
    {
        
    }
}
