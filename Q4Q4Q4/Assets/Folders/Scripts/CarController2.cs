using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController2 : MonoBehaviour
{
    public Transform centerOfMass;
    public float motorTorque = 100f;
    public float maxSteer = 20f;

    public float Steer2 {  get; set; }
    public float Throttle2 {  get; set; }

    private Rigidbody _rigidbody;
    private Wheel[] wheels;

    private void Start()
    {
        wheels = GetComponentsInChildren<Wheel>();
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.centerOfMass = centerOfMass.localPosition;
    }

     void Update()
    {
        //Steer = GameManager.Instance.InputController.SteerInput;
        //Throttle = GameManager.Instance.InputController.ThrottleInput;

        foreach (var wheel in wheels)
        {
            wheel.SteerAngle = Steer2 * maxSteer;
            wheel.Torque = Throttle2 * motorTorque;
        }
    }
}