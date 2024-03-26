using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ActivateRayInteractor : MonoBehaviour
{
    public GameObject leftRay, rightRay;

    public InputActionProperty leftActivateRay, rightActivateRay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        leftRay.SetActive(leftActivateRay.action.ReadValue<float>() > 0.1f);
        rightRay.SetActive(rightActivateRay.action.ReadValue<float>() > 0.1f);
    }
}
