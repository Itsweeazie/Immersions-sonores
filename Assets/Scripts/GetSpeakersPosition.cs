using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetSpeakersPosition : MonoBehaviour
{
    public OSC osc;
    private Vector3 speakers;
    private Vector3 newPosition;

    public string messageAddress;
    public int count;



    // Start is called before the first frame update
    public void Start()
    {
        //InitializeSources initializeSources = GameObject.Find("Osc Spawn Source").GetComponent<InitializeSources>();
        speakers = this.transform.position;
        //osc.SetAllMessageHandler(CallInitSources);
        //osc.SetAllMessageHandler(MoveSpeakers);
        //osc.SetAllMessageHandler(initializeSources.ReceiveSources);
    }

    // Update is called once per frame
    void Update()
    {
        
        newPosition = this.transform.position;
        
        count++;
        if (count % 10 == 0)
        {
            getPosition();
        }
    }

    public void MoveSpeakers(OscMessage m)
    {
        string message = m.ToString();
        string empty = string.Empty;
        
        if(message != empty && m.address =="/xyz")
        {
            float x = m.GetFloat(0);
            float y = 1.5f;
            float z = m.GetFloat(2);

            this.transform.position = new Vector3(x, y, z);
        }
        
        else if(message == empty)
        {
            Debug.Log("Le message n'a aucune valeur");
        }   
    }


    public void CallInitSources(OscMessage m)
    {
        InitializeSources initializeSources = GameObject.Find("Osc Spawn Source").GetComponent<InitializeSources>();
        initializeSources.ReceiveSources(m);
    }

    public void getPosition()
    {
        if(newPosition != speakers)
        {
            Debug.Log(this.transform.position);
            SendXYZ();
            //SendX();
            //SendY();
            //SendZ();
            speakers = newPosition;
        }
    }

    public void SendXYZ(){
        OscMessage message = new OscMessage();
        /*SourceSender sourceSender = GameObject.Find("Osc Spawn Source").GetComponent<SourceSender>();
        string addressXYZ = "/xyz " + sourceSender.numeroEnceinte;
        message.address = addressXYZ;*/

        string chaine = this.gameObject.name;
        string nombre = string.Empty;
        messageAddress = string.Empty;

        for (int i = 0; i < chaine.Length; i++)
        {
            nombre = string.Empty;

            if (char.IsNumber(chaine[i]))
            {
                nombre += chaine[i];
                Debug.Log(nombre); break;

            }

            else if (!string.IsNullOrEmpty(nombre))
            {
                Debug.Log(string.Empty);
            }
        }

            messageAddress = "/xyz " + nombre;
            message.address = messageAddress;
            message.values.Add(this.transform.position.x);
            message.values.Add(1.5f);
            message.values.Add(this.transform.position.z);
            osc.Send(message);


        }

            //message.values.Add(number);

    }

   /* public void SendX(){
        OscMessage message = new OscMessage();
        message.address = "/CubeX";
        message.values.Add(this.transform.position.x);
        osc.Send(message);
    }

    public void SendY(){
        OscMessage message = new OscMessage();
        message.address = "/CubeY";
        message.values.Add(this.transform.position.y);
        osc.Send(message);
    }

    public void SendZ(){
        OscMessage message = new OscMessage();
        message.address = "/CubeZ";
        message.values.Add(0);
        osc.Send(message);
    }*/

