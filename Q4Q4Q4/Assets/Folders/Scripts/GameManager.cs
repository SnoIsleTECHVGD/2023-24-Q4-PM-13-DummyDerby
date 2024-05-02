using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {  get; private set; }

    public static GameManager Instance2 { get; private set; }
    public InputController InputController { get; private set; }
    public InputController2 InputController2 { get; private set; }


    void Awake()
    {
        Instance = this;
        Instance2 = this;
        InputController = GetComponentInChildren<InputController>();
        InputController2 = GetComponentInChildren<InputController2>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
