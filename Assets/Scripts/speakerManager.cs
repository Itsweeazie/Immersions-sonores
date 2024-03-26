using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Progress;

public class speakerManager : MonoBehaviour
{
    public InputActionReference activateSound = null;
    public InputAction.CallbackContext context;

    [SerializeField]
    InputActionAsset playerControls;
    InputAction menuPress;

    public float x;
    public float z;
    public bool numsourceReceived = false;

    //public static float[] arr = {};
    public List<string> posSpeak = new List<string>();
    public ArrayList[,,] listeEnceinte;
    public GameObject SpeakerManager;
    public GameObject haut_parleur1;
    private GameObject sourceVirtuelle;

    public OSC osc;
    public OSC oscReference;

    void Awake()
    {
        var gameplayActionMap = playerControls.FindActionMap("XRI LeftHand");
        menuPress = gameplayActionMap.FindAction("Menu");
        menuPress.performed += OnMenuPress;
        menuPress.Enable();
    }

    // Start is called before the first frame update
    void Start()
    {
        //float index = posSpeak.FindIndex(System.Predicate<1>);
        sourceVirtuelle = GameObject.Find("BasePos");
        SpeakerManager = this.gameObject;
        osc.SetAllMessageHandler(OnReceive);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Demande d'initialisation
    void OnMenuPress(InputAction.CallbackContext context)
    {
        OscMessage message = new OscMessage();
        message.address = "/init";
        message.values.Add(1);
        oscReference.Send(message);
        Debug.Log(message);
    }

    // Envoyer la demande d'initialisation a chaque fois que la touche 'menu' est pressee




    public void OnReceive(OscMessage omg)
    {
        if (omg.address == "/xyz" || omg.address == "/numsources")
        {
                x = omg.GetFloat(1);
                z = omg.GetFloat(2);

                if (omg.address == "/xyz")
                {
                    float numero = omg.GetInt(0);

                    for (int i = 1; i < numero; i++)
                    {
                        if (GameObject.Find("sourceVirtuelle " + numero) == true)
                        {
                            Debug.Log("Source Virtuelle trouvee");
                            GameObject.Find("sourceVirtuelle " + numero).transform.position = new Vector3(x, 0, z);

                            /*if (GameObject.Find("haut_parleur " + numero) == false)
                            {
                                SpeakerManager = Instantiate(haut_parleur1, GameObject.Find("sourceVirtuelle " + numero).transform.position, osc.transform.rotation);
                                SpeakerManager.name = "haut_parleur " + numero;
                                Debug.Log("Sources sonores instanciees !");

                                Destroy(GameObject.Find("sourceVirtuelle " + numero));
                                Debug.Log("Sources virtuelles détruites !");
                            }*/
                        }
                    }
                }

                if (omg.address == "/numsources" && numsourceReceived == false)
                {
                    numsourceReceived = true;
                    Debug.Log("Numsources reçu");

                    float number = omg.GetFloat(0);

                    /*SourceSender sourceSender = GameObject.Find("Osc Spawn Source").GetComponent<SourceSender>();
                    sourceSender.number = i + 1;*/


                    for (float i = 0; i < number; i++)
                    {
                        SpeakerManager = Instantiate(sourceVirtuelle, osc.transform.position, osc.transform.rotation);
                        // Crée une nouvelle instance de enceintePrefab à chaque itération


                        // Modifie le nom de la nouvelle instance
                        SpeakerManager.name = "sourceVirtuelle " + (i + 1).ToString();

                        // On attribue un numéro à chaque source

                        if (GameObject.Find("sourceVirtuelle " + i) == true)
                        {

                            Debug.Log("Source Virtuelle trouvee");
                            GameObject.Find("sourceVirtuelle " + i).transform.position = new Vector3(x, 0, z);

                            if (GameObject.Find("haut_parleur " + i) == false)
                            {
                                SpeakerManager = Instantiate(haut_parleur1, GameObject.Find("sourceVirtuelle " + i).transform.position, osc.transform.rotation);
                                SpeakerManager.name = "haut_parleur " + i;
                                Debug.Log("Sources sonores instanciees !");

                                Destroy(GameObject.Find("sourceVirtuelle " + i));
                                Debug.Log("Sources virtuelles détruites !");
                            }

                        }

                        Debug.Log("Les enceintes devraient être instanciées");
                    }
                }
        }
  

        else
        {
            Debug.Log("Le script pour recevoir numsources et les positions ne s'exécute pas correctement");
            return;
        }
    }
}
 


 



        /*public void Receiver(OscMessage m)
        {
            if (m.address == "/aperture")
            {
                int number = m.GetInt(0);
                // Debug.Log("aperture");

                GameObject source = GameObject.Find("source" + number);
                GameObject sphere = source.transform.GetChild(0).gameObject;
                GameObject cone = sphere.transform.GetChild(0).gameObject;
                // Debug.Log(source.name);
                //Aperture aperture = cone.GetComponent<Aperture>();
                // Debug.Log(aperture.angle);
                int deg = m.GetInt(1);
                //aperture.angle = deg;
            }

            if (m.address == "/yaw")
            {
                ArrayList list = m.values;
                int number = m.GetInt(0);
                float rotY = m.GetFloat(1);
                // Debug.Log("yaw");

                GameObject source = GameObject.Find("source" + number);
                GameObject sphere = source.transform.GetChild(0).gameObject;
                GameObject cone = sphere.transform.GetChild(0).gameObject;
                // Seule la rotation sur l'axe Y définit la valeur de yaw
                sphere.transform.localRotation = Quaternion.Euler(0f, rotY, 0f);
                // Debug.Log(sphere.name);
            }

            // Activer/désactiver la source
            if (m.address == "/play")
            {
                ArrayList list = m.values;
                int number = m.GetInt(0);
                int state = m.GetInt(1);
                // Debug.Log("play");

                GameObject source = GameObject.Find("source" + number);
                GameObject sphere = source.transform.GetChild(0).gameObject;
                GameObject cone = sphere.transform.GetChild(0).gameObject;
                GameObject part = cone.transform.GetChild(0).gameObject;

                switch (state)
                {
                    case 0:
                        part.SetActive(false);
                        break;

                    case 1:
                        part.SetActive(true);
                        break;
                }
            }

            // Récupérer l'adresse IP de la machine avec laquelle on communique
            if (m.address == "/adress")
            {
                ArrayList list = m.values;
                //adresse = m.ToString();
                // L'adresse figure sur le script oscReference qui est placé sur l'objet OSC Spawn Source
                //oscReference.outIP = adresse;
                // Debug.Log("adress recieved");
            }
        }*/
    

