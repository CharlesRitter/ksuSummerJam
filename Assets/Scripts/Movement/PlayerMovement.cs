using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public float speed = 3.0F;
    public float jumpSpeed = 4.0F;
    public float rotateSpeed = 3.0F;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();

        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        if(Input.GetButton("Jump"))
        {
            moveDirection.y = jumpSpeed;
        }

        moveDirection *= speed;
        controller.SimpleMove(moveDirection);


    }
}
