using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public bool Player1Touched;
    public bool Player2Touched;
    private void OnTriggerEnter(Collider collider)
    {
            Color color = Color.white;
            Player1Touched = true;
        
    }
    void Update()
    {
        
    }
}
