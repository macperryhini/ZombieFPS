using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public CharacterController controller;
    public float speed = 12f;
    Vector3 velocity;
    public float gravity = -9.81f;
    public bool isGrounded;

    public Transform groundcheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float jumpeHeight = 2f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (isGrounded && velocity.y < 0)
        {
                velocity.y = -2f;
        }




        float  x = Input.GetAxis("Horizontal") ;

        float  z = Input.GetAxis("Vertical") ;

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

         controller.Move(velocity * Time.deltaTime);

       if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpeHeight * -2 * gravity);
        }
    }
}
