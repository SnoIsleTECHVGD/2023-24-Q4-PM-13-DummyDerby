using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarFollow : MonoBehaviour
{

    internal enum updateMethod
    {
        fixedUpdate,
        update,
        lateUptade
    }
    [SerializeField] private updateMethod updateDemo;

    private GameObject atachedVehicle;

    private GameObject cameraPositionFolder;
    private Transform[] camLocations;
    private CarController controllerReference;
    [Range(0, 20)] public float smothTime = 5;
    public int locationIndicator = 2;

    private void Start()
    {
        atachedVehicle = GameObject.FindGameObjectWithTag("Player");
        controllerReference = atachedVehicle.GetComponent<CarController>();
        cameraPositionFolder = atachedVehicle.transform.Find("CAMERA").gameObject;
        camLocations = cameraPositionFolder.GetComponentsInChildren<Transform>();

    }

    private void FixedUpdate()
    {
        if (updateDemo == updateMethod.fixedUpdate)
            cameraBehavior();
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            //change camLocation
            if (locationIndicator >= 4 || locationIndicator < 2) locationIndicator = 2;
            else locationIndicator++;

        }
    }

    private void Update()
    {
        if (updateDemo == updateMethod.update)
            cameraBehavior();
    }

    private void LateUpdate()
    {
        if (updateDemo == updateMethod.lateUptade)
            cameraBehavior();
    }

    private void cameraBehavior()
    {
        Vector3 velocity = Vector3.zero;
        transform.position = Vector3.SmoothDamp(transform.position, camLocations[locationIndicator].transform.position, ref velocity, smothTime * Time.deltaTime);
        transform.LookAt(camLocations[1].transform);
    }

}
