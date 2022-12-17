using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharacter : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public float Speed = 30f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    float Gravity = 9.5f;
    bool Fly;
    Vector3 velocity;
    private Animator mAnimator;
    
    
    void Start()
    
    {
        Fly = false;
        mAnimator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        
        
      
        float horizontal = Input.GetAxisRaw("horizontal");
        float vertical = Input.GetAxisRaw("vertical");
        Vector3 direction = new Vector3 (horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            mAnimator.SetBool("Walk", true);
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle,ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * Speed * Time.deltaTime);
        }

        else
        {
            mAnimator.SetBool("Walk", false);
        }
        if(!controller.isGrounded)
        {
            velocity.y -= Gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Fly = true;
            transform.position += new Vector3 (0f, 10f, 0f); 
            print("Q Has Press!");  
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Fly = false;
            print("E Has Press!");
        }

        if (Fly == true)
        {
            Gravity = -20.5f;
            Speed = 50f;
        }

         if (Fly == false)
        {
            Gravity = 9.0f;
            Speed = 30f;
        }
    }
}
