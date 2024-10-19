using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public float acceleration;
    public float maxSteerAngle;
    public Wheel[] frontwheels;
    public Wheel[] backwheels;

    [Range(-1, 1)]
    public float forward;
    [Range(-1, 1)]
    public float turn;


    // Update is called once per frame
    void FixedUpdate()
    {
        foreach (var wheel in frontwheels)
        {
            wheel.collider.motorTorque = forward * acceleration;
            wheel.collider.steerAngle = Mathf.Lerp(wheel.collider.steerAngle, turn * maxSteerAngle, 0.5f);
        }
    }
}