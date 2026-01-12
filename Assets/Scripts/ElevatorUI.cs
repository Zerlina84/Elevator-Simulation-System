using UnityEngine;
using UnityEngine.UI;

public class ElevatorUI : MonoBehaviour
{
    ElevatorController controller;
    Text buttonPressed;
    string requestedFloorStr;
    int requestedFloorInt;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //controller = GetComponent<ElevatorController>();
        controller = GameObject.Find("ElevatorController").GetComponent<ElevatorController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GetFloorRequest(int floorNumber)
    {
        //requestedFloorStr = floorNumber;
       // Debug.Log("Elevator UI - Floor Request" + floorNumber);
       // Debug.Log("Elevator UI - Controller Current State: " + controller.currentState);
        controller.RequestFloor(floorNumber);
    }
}
