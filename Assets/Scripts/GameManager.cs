using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem.XR;

public class GameManager : MonoBehaviour
{
    public GameObject startMenu;
    public GameObject inGameMenu;
    private GameStartMenu scriptStartMenu;
    private InGameMenu scriptInGameMenu;

    //INPUTS
    public ActionBasedController controller = null; // glisser le controler ici

    private string sceneName;

    void Awake()
    {
        startMenu = GameObject.Find("StartMenu");
        inGameMenu = GameObject.Find("InGameMenu");
        scriptStartMenu = GameObject.Find("StartMenu").GetComponent<GameStartMenu>();
        scriptInGameMenu = GameObject.Find("InGameMenu").GetComponent<InGameMenu>();
    }
        // Start is called before the first frame update
        void Start()
    {
        // Create a temporary reference to the current scene.
        Scene currentScene = SceneManager.GetActiveScene();

        // Retrieve the name of this scene.
        sceneName = currentScene.name;
    }

    // Update is called once per frame
    void Update()
    {
        // Detects "A" input of rightcontroller
        float triggerValue = controller.selectAction.action.ReadValue<float>();

        if (triggerValue != 0 && sceneName != "Oihan_Lobby")
        {
            scriptInGameMenu.EnableInGameMenu();
            startMenu.SetActive(false);
        }

        // Disables start menu if not in lobby
        if (sceneName == "Oihan_Boxe" || sceneName == "Oihan_Danse")
        {
            startMenu.SetActive(false);
        }
    }

    public void StartGame()
    {
        Debug.Log("Start");
        //gameStartMenu.StartGame();
        
        if (startMenu.activeSelf == true)
        {
            if (scriptStartMenu.dropdownValue == 0 && sceneName != "Oihan_Boxe")
            {
                SceneManager.LoadScene("Oihan_Boxe");
                startMenu.SetActive(false);
                scriptInGameMenu.DisableInGameMenu();
                //startMenu.SetActive(false);
                //Debug.Log("in game menu should be disabled");
                //gameStartMenu.StartGame();
            }
            if (scriptStartMenu.dropdownValue == 1 && sceneName != "Oihan_Danse")
            {
                SceneManager.LoadScene("Oihan_Danse");
                startMenu.SetActive(false);
                scriptInGameMenu.DisableInGameMenu();
                //startMenu.SetActive(false);
                //Debug.Log("in game menu should be disabled");
                //gameStartMenu.StartGame();
            }
        }

        //if (inGameMenu.activeSelf == true)
        //{
        //    if (scriptInGameMenu.sceneDropdownValue == 0 && sceneName != "Oihan_Lobby")
        //    {
        //        //SceneManager.LoadScene("Oihan_Lobby");
        //        Debug.Log("should have switched to lobby");
        //        inGameMenu.SetActive(false);
        //        scriptInGameMenu.DisableInGameMenu();
        //        //startMenu.SetActive(false);
        //        //Debug.Log("in game menu should be disabled");
        //        //gameStartMenu.StartGame();
        //    }
        //    if (scriptInGameMenu.sceneDropdownValue == 1 && sceneName != "Oihan_Boxe")
        //    {
        //        //SceneManager.LoadScene("Oihan_Boxe");
        //        Debug.Log("should have switched to boxe");
        //        inGameMenu.SetActive(false);
        //        scriptInGameMenu.DisableInGameMenu();
        //        //startMenu.SetActive(false);
        //        //Debug.Log("in game menu should be disabled");
        //        //gameStartMenu.StartGame();
        //    }
        //    if (scriptInGameMenu.sceneDropdownValue == 2 && sceneName != "Oihan_Danse")
        //    {
        //        //SceneManager.LoadScene("Oihan_Danse");
        //        Debug.Log("should have switched to danse");
        //        inGameMenu.SetActive(false);
        //        scriptInGameMenu.DisableInGameMenu();
        //        //startMenu.SetActive(false);
        //        //Debug.Log("in game menu should be disabled");
        //        //gameStartMenu.StartGame();
        //    }
        //}
    }
    public void StartMenu()
    {
        startMenu.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
