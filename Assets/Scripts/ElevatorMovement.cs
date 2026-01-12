using System;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering.Universal;

public class ElevatorMovement : MonoBehaviour
{
    ElevatorController controller;
    DoorController doorController;
    Vector3 NewCabinPos;
    float moveSpeed = 2f;
    int? targetY;
    float[] floorPositions = {0f,3f,6f,9f};
    float newFloorNumber;
    int yPos;
    //float step = 0.001f;
    public TMP_Text floorDisplay;

    //int targetFloor = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GameObject.Find("ElevatorController").GetComponent<ElevatorController>();
        doorController = GameObject.Find("DoorGroup").GetComponent<DoorController>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (controller.currentState)
        {
            case ElevatorController.ElevatorState.Idle:
                break;
            case ElevatorController.ElevatorState.MovingUp:
            case ElevatorController.ElevatorState.MovingDown:
                MoveElevator(controller.targetFloor);
                break;
            case ElevatorController.ElevatorState.DoorOpen:
               
              // Debug.Log("Within Elevator Movement Switch case: " + controller.currentState);
                doorController.OpenDoor(controller.currentFloor);
                //Debug.Log("Open Door called");
                break;
        }
    }

    public void MoveElevator(int targetFloor)
    {
        NewCabinPos = new Vector3(0, floorPositions[targetFloor], 0);
        Debug.Log(NewCabinPos);
        //transform.position = Vector3.MoveTowards(transform.position, NewCabinPos, step);
        //step = Time.deltaTime * 2f;
        transform.position = Vector3.MoveTowards(transform.position, NewCabinPos, moveSpeed * Time.deltaTime);
        Debug.Log(transform.position);
        //yPos = Mathf.RoundToInt(transform.position.y);

        //newFloorNumber = Array.IndexOf(floorPositions, transform.position.y);
        //Debug.Log("New Floor Number: " + newFloorNumber);
        //controller.currentFloor = (int)newFloorNumber;
        //if (controller.currentFloor == controller.targetFloor)
        //{
        //    //Open Door
        //    //doorController.OpenDoor(controller.currentFloor);
        //    //Close Door
        //    controller.currentState = ElevatorController.ElevatorState.DoorOpen;
        //}

        if (Mathf.Abs(transform.position.y - NewCabinPos.y) < 0.01f)
        {
            transform.position = NewCabinPos; // snap exactly
            //controller.currentFloor = targetFloor;
            //controller.currentState = ElevatorController.ElevatorState.DoorOpen;
            controller.OnReachedFloor();
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        Debug.Log("On trigger called");
        switch (other.name)
        {
            case "0":
                Debug.Log(other.name);
                break;
            case "1":
                Debug.Log(other.name);
                break;
            case "2":
                Debug.Log(other.name);
                break;
            case "3":
                Debug.Log(other.name);
                break;
        }

        displayFloor(other.name);
    }

    void displayFloor(string floor)
    {
        floorDisplay.text = floor;
    }
}
