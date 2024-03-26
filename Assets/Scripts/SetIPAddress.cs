using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class SetIPAddress : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetIPAddress();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void GetIPAddress()
    {
        string host = Dns.GetHostName();

        string ip = Dns.GetHostEntry(host).AddressList[1].ToString();
        Debug.Log(host + " : " + ip);

    }
}
