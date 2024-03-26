using UnityEngine;
using System.Collections;

public class ReceiveAlice : MonoBehaviour
{
    public OSC osc;
    public Vector3 position;

    // Use this for initialization
    void Start()
    {
        osc.SetAddressHandler("/xyz", OnReceiveXYZ);
        //osc.SetAddressHandler("/level1", Level);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Level(OscMessage message)
    {
        Debug.Log(message.ToString());
    }
    void OnReceiveXYZ(OscMessage message)
    {
        Debug.Log(message);
    }
        

        
       // position.transform.position = position;


   }

