using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public Transform centorOfMass;
    public float motorToque = 1500f;
    public float maxSteer = 20f;

    public float Steer {  get; set; }
    public float Throttle {  get; set; }

    private Rigidbody _rigidbody;
    private Wheel[] wheels;

    private void Start()
    {
        wheels = GetComponentsInChildren<Wheel>();
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.centerOfMass = centorOfMass.localPosition;
    }

    private void Update()
    {
        Steer = GameManager.Instance.InputController.SteerInput;
        Throttle = GameManager.Instance.InputController.ThrottleInput;

        foreach (var wheel in wheels)
        {
            wheel.SteerAngle = Steer * maxSteer;
            wheel.Torque = Throttle * motorToque;
        }
    }
}