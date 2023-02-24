using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    Vector3 velocity;
    public Transform feet;
    public float dist = 0.4f;
    bool onGround;
    float jump = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        onGround = controller.isGrounded;
        
        if (onGround && velocity.y < 0) {
            velocity.y = -2f;
        }

        float forwardBack = Input.GetAxis("Horizontal");
        float leftRight = Input.GetAxis("Vertical");

        Vector3 moveDir = transform.right * forwardBack + transform.forward * leftRight;

        controller.Move(moveDir * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && onGround)
        {
            velocity.y = Mathf.Sqrt(jump * -2f * -20f);
        }

        velocity.y += -20f * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
