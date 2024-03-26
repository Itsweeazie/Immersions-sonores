using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSpeakerPosition : MonoBehaviour
{
    private ReceivePosition receivePosition;
    public string mString;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveSpeakers(OscMessage m)
    {
        if (m.address == "/numsources")
        {
            Debug.Log("Numsources reçu");
            ArrayList list = m.values;
            int number = m.GetInt(0);

            // Debug.Log("numsources");

            for (int i = 0; i < number; i++)
            {
                
            }
        }

        if (this.gameObject.CompareTag("1")) {
            this.transform.position = receivePosition.Enceinte1.transform.position;
        }
   
        else
        {
            Debug.Log("Aucun tag ne correspond");
        }
    }
}
