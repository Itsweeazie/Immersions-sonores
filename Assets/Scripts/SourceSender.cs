using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SourceSender : MonoBehaviour
{
    public int count = 0;
    [SerializeField]

    public string numeroEnceinte;
    public string nomSource;

    public OSC osc;

    public int number;

    [SerializeField]
    private GameObject sphere;

    [SerializeField]
    private GameObject cone;

    //[SerializeField]
    //private Aperture aperture;

    [SerializeField]
    private Transform origin;

    void Start()
    {
        // OSC
        
        // Source
        //sphere = gameObject.transform.GetChild(0).gameObject;
        //cone = gameObject.transform.GetChild(0).GetChild(0).gameObject;
        
        //aperture = cone.GetComponent<Aperture>();

        origin = GameObject.FindGameObjectWithTag("BasePos").transform;


    }

    void Update()
    {
        // Fr�quence d'envoi (l'envoi ne doit pas se faire en continu, il faut laisser une petite marge de temps)
        count++;
        if (count % 10 == 0)
        {
            Sender();
        }
    }

    /* Envoyer un message avec OSC :
    OscMessage message = new OscMessage(); -> cr�ation du message "message"
    message.adress = "/adress"; -> l'adresse du message est /adress
    message.values.Add(1234); -> la donn�e � communiquer est 1234
    (On peut ajouter autant de valeur que l'on souhaite, il faut simplement r�p�ter la ligne suivante en fonction du nombre de valeur en question)
    osc.Send(message) -> On envoie le message
    */

    public void Sender()
    {
            for (int j = 0; j < number; j++)
            {
                numeroEnceinte = (j + 1).ToString();
                nomSource = "haut_parleur " + numeroEnceinte;

                Debug.Log(nomSource);

                if (this.gameObject.name == nomSource)
                {
                    OscMessage messageXYZ = new OscMessage();

                    string adresseOSC = "/xyz " + numeroEnceinte;
                    Debug.Log("nom de l'adresse " + adresseOSC);
                    messageXYZ.address = adresseOSC;
                    messageXYZ.values.Add(gameObject.transform.position.x);
                    messageXYZ.values.Add(gameObject.transform.position.z);
                    // La hauteur de la source ne change pas mais elle est � 1.5 (~= taille humaine). Elle doit �tre consid�r�e comme �tant � 0.
                    messageXYZ.values.Add(0);
                    osc.Send(messageXYZ);
                    Debug.Log("Le message envoyé est " + messageXYZ);

                    OscMessage messageAperture = new OscMessage();
                    string apertureOSC = "/aperture " + numeroEnceinte;
                    messageAperture.address = apertureOSC;
                    messageAperture.values.Add(number);
                    /* ATTENTION
                    Pour former le c�ne, le script Aperture doit cr�er deux m�mes c�nes coll�s entre eux (un du c�t� droit de la source, un autre du c�t� gauche).
                    Ainsi, un c�ne de 90� est compos� de deux c�nes de 45�.
                    La valeur de apreture.angle �tant la valeur de l'angle d'un seul c�ne, on doit la multiplier par deux pour obtenir la valeur de l'angle du c�ne repr�sent� visuellement. */

                    //messageAperture.values.Add(aperture.angle * 2);
                    osc.Send(messageAperture);

                    OscMessage messageYaw = new OscMessage();
                    // On calcule l'angle de rotation de la source par rapport au centre 

                    /*float angle = Quaternion.Angle(sphere.transform.localRotation, origin.rotation);
                    if (angle >= 90f)
                    {
                        angle = angle * 2;
                    }
                    messageYaw.address = "/yaw";
                    messageYaw.values.Add(number);
                    messageYaw.values.Add(sphere.transform.localEulerAngles.y);
                    osc.Send(messageYaw);
                    */
                }

            }

    }
}