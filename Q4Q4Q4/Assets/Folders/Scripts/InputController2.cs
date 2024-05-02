using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController2 : MonoBehaviour
{
    public string inputSteerAxis2 = "Horizontal2";
    public string inputThrottleAxis2 = "Vertical2";

    public float ThrottleInput2 {  get; private set; }
    public float SteerInput2 { get; private set; }

    

    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        SteerInput2 = Input.GetAxis(inputSteerAxis2);
        ThrottleInput2 = Input.GetAxis(inputThrottleAxis2);
    }
}
