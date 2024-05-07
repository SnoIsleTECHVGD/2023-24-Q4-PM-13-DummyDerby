using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    public enum ControlType { HumanInput, AI }
    public ControlType controlType = ControlType.HumanInput;

    public float BestLapTime {  get; private set; } = Mathf.Infinity;
    public float LastLapTime { get; private set; } = 0;
    public float CurrentLapTime { get; private set; } = 0;
    public int CurrentLap {  get; private set; } = 0;

    private float lapTimerTimestamp;
    public int lastCheckpointPassed = 0;

    private Transform checkpointsParent;
    public int checkpointCount;
    private int checkpointLayer;
    private CarController carController;

    public GameObject Racecar;

    public GameObject Player2Win;



    //test
    //public WaypointContainer waypointContainer;
    //public List<Transform> waypoints;
    //public int currentWaypoint;
    //public float waypointRange;

    void Awake()  
    {
       checkpointsParent = GameObject.Find("Checkpoints").transform;
       checkpointCount = checkpointsParent.childCount;
       checkpointLayer = LayerMask.NameToLayer("Checkpoint");
       carController = GetComponent<CarController>();
    }

    void StartLap()
    {
        Debug.Log("StartLap!");
        CurrentLap++;
        lastCheckpointPassed = 1;
        lapTimerTimestamp = Time.time;
    }

    void EndLap()
    {
        LastLapTime = Time.time - lapTimerTimestamp;
        BestLapTime = Mathf.Min(LastLapTime, BestLapTime);
        Debug.Log("EndLap - LapTime was " + LastLapTime + "seconds");
    }
    
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.layer != checkpointLayer)
        {
            return;
        }

        if ( collider.gameObject.name == "1")
        {
            if ( lastCheckpointPassed == checkpointCount)
            {
                EndLap();
            }

            if (CurrentLap == 0 || lastCheckpointPassed == checkpointCount)
            {
                StartLap();
            }
            return;
        }

        if ( collider.gameObject.name == (lastCheckpointPassed+1).ToString())
        {
            lastCheckpointPassed++;
        }
    }
    void Start()
    {
       // carController = GetComponent<Car>();
        //waypoints = waypointContainer.waypoints;
        //currentWaypoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        CurrentLapTime = lapTimerTimestamp > 0 ? Time.time - lapTimerTimestamp : 0; 
        if  (controlType == ControlType.HumanInput)
        {
            carController.Steer = GameManager.Instance.InputController2.SteerInput2;
            carController.Throttle = GameManager.Instance.InputController2.ThrottleInput2;
        }
        if (controlType == ControlType.AI)
        {

            //transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypoint].position, targetmoveSpeed * Time.deltaTime);

            // if (Vector3.Distance(waypoints[currentWaypoint].position, transform.position) < waypointRange)
            // {
            //     currentWaypoint++;
            //     if (currentWaypoint == waypoints.Count) currentWaypoint = 0;
            // }
            //Debug.DrawRay(transform.position, waypoints[currentWaypoint].position - transform.position, Color.yellow);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Racecar.transform.position = checkpointsParent.transform.position;
            Debug.Log("Test..");
        }

        if (CurrentLap == 3)
        {
            Player2Win.SetActive(true);
        }
    }
}
