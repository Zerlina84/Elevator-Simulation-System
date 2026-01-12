using UnityEngine;
using UnityEngine.UIElements;

public class ElevatorController : MonoBehaviour
{
    ElevatorMovement elevatorMovement;
    DoorController doorController;
    public Animator[] doorGroups;

    public enum ElevatorState
    {
        Idle,
        MovingUp,
        MovingDown,
        DoorOpen,
        DoorClose
    }

    public ElevatorState currentState;
    public int currentFloor = 0;
    public int targetFloor = 0;

    int moveSpeed, doorOpenTime, doorTimer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        elevatorMovement = GameObject.Find("Cabin").GetComponent<ElevatorMovement>();
        doorController = GetComponent<DoorController>();
        currentState = ElevatorState.Idle;
    }

    public void RequestFloor(int requestedFloor)
    {
        if (currentState != ElevatorState.Idle)
            return; // ignore or queue (simple version: ignore)

        if (currentState == ElevatorState.DoorOpen)
            return; // ignore or queue (simple version: ignore)

        if (requestedFloor == currentFloor)
        {
            return;
            //currentState = ElevatorState.Idle;
            // already here, do nothing
        }

        targetFloor = requestedFloor;

        if (targetFloor > currentFloor)
        {
            currentState = ElevatorState.MovingUp;
            //elevatorMovement.SetTargetYPosition(targetFloor);
            //Debug.Log("Moving Up");
        }
        else
        {
            currentState = ElevatorState.MovingDown;
            //Debug.Log("Moving Down");

        }
    }

    public void OnReachedFloor()
    {
        currentFloor = targetFloor;
        currentState = ElevatorState.DoorOpen;
    }
}
