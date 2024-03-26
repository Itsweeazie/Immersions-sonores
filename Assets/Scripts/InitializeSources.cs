using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class InitializeSources : MonoBehaviour
{
    public OSC osc;
    public InputActionReference activateSound = null;
    public InputAction.CallbackContext context;

    [SerializeField]
    InputActionAsset playerControls;
    InputAction menuPress;

    public GameObject enceintePrefab;
    [SerializeField]
    private OSC oscReference;
    [SerializeField]
    private OscMessage m;

    public int number;

    private InputData _inputData;

    private GameObject basePos;


    /* On peut retrouver la touche assign�e � l'action InitSource dans InputActions > InitSources
    private void Awake()
    {
        activateSound.action.started += InitSource;
    }

    private void OnDestroy()
    {
        activateSound.action.started -= InitSource;
    }
    */

    void Awake()
    {
        var gameplayActionMap = playerControls.FindActionMap("XRI LeftHand");
        menuPress = gameplayActionMap.FindAction("Menu");
        menuPress.performed += OnMenuPress;
        menuPress.Enable();
        //osc.SetAllMessageHandler(ReceiveSources);
    }

    public void Start()
    {

        _inputData = GetComponent<InputData>();

        basePos = GameObject.Find("BasePos");

        //osc.SetAddressHandler("/numsources", ReceiveSources);
        
    }

    public void Update()
    {
        
    }


    void OnMenuPress(InputAction.CallbackContext context)
    {
        Send();
    }

    // Envoyer la demande d'initialisation � chaque fois que la touche 'menu' est press�e

    // Demande d'initialisation
    void Send()
    {
        OscMessage message = new OscMessage();
        message.address = "/init";
        message.values.Add(1);
        oscReference.Send(message);
        Debug.Log(message);
        Debug.Log("init");
    }

    public void ReceiveSources(OscMessage m)
    {
       /* if (m.address == "/xyz")
        {
            float x = m.GetFloat(1);
            float y = 1.5f;
            float z = m.GetFloat(3);
            basePos.transform.position = new Vector3(x, y, z);
            Debug.Log(basePos.transform.position);

        }*/

        if (m.address == "/numsources")
        {
            Debug.Log("Numsources reçu");
            int number = m.GetInt(0);

            /*SourceSender sourceSender = GameObject.Find("Osc Spawn Source").GetComponent<SourceSender>();
            sourceSender.number = i + 1;*/


            for (int i = 0; i < number; i++)
            {

                basePos = Instantiate(enceintePrefab, osc.transform.position, osc.transform.rotation);
                // Crée une nouvelle instance de enceintePrefab à chaque itération


                // Modifie le nom de la nouvelle instance
                basePos.name = "haut_parleur " + (i + 1).ToString();

                // On attribue un numéro à chaque source


                Debug.Log("La valeur de i est : " + i);

                // Autres opérations si nécessaire...

                // Vous pouvez également ajouter basePos à une liste ou à un tableau si vous avez besoin de les référencer plus tard.
            }

            Debug.Log("Les enceintes devraient être instanciées");
        }
    }



    public void Receiver(OscMessage m)
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
    }
}