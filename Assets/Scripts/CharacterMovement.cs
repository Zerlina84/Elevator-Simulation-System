using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public CharacterController controller;
    float speed = 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        Vector3 move = new Vector3(moveX, 0, moveZ);
        controller.Move(move * speed * Time.deltaTime);

    }
}
