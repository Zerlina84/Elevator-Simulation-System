using System.Collections;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private Animator m_Animator;
    ElevatorController controller;
    float openDuration = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        Debug.Log("Animator: " + m_Animator);
        controller = GameObject.Find("ElevatorController").GetComponent<ElevatorController>();
    }

    // Update is called once per frame
    void Update()
    {
        //if(controller.currentState == ElevatorController.ElevatorState.DoorOpen)
        //{
        //    OpenDoor(controller.currentFloor);
        //}
    }

    public void OpenDoor(int floor)
    {
        //Debug.Log("Within Open Door");
        //Debug.Log("Floor Number: " +  floor);
        //Debug.Log("Current State: " + controller.currentState);

        controller.currentState = ElevatorController.ElevatorState.Idle;
        controller.doorGroups[controller.targetFloor].SetTrigger("Open");
        controller.currentState = ElevatorController.ElevatorState.DoorClose;

        //controller.currentState = ElevatorController.ElevatorState.Idle;
        StartCoroutine(CloseDoor(openDuration, floor));
    }

    public IEnumerator CloseDoor(float delay, int floor)
    {
        yield return new WaitForSeconds(delay);
        controller.currentState = ElevatorController.ElevatorState.Idle;
        controller.doorGroups[floor].SetTrigger("Close");
        controller.currentState = ElevatorController.ElevatorState.DoorClose;
        StartCoroutine (SetIdle());
    }

    IEnumerator SetIdle()
    {
        yield return new WaitForSeconds(2f);
        controller.currentState = ElevatorController.ElevatorState.Idle;
    }
}
