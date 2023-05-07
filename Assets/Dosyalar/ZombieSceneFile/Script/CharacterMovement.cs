using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterMovement : MonoBehaviour
{
    Vector3 moveVector;
    CharacterController characterController;
    public float Speed = 5f;

    [Header("Ground")]
    public Transform groundCheck;
    public float groundDistance = 5f;
    public LayerMask groundMask;
    public float gravity = -9.80f;
    public float jumpHeight = 3f;
    Vector3 velocity;
    public bool isGrounded;
    [HideInInspector] GameManager gameManager;

    Vector3 startPos;
    Vector3 startRot;

    public void Start()
    {
        characterController = GetComponent<CharacterController>();
        //gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();

        startPos = transform.position;
        startRot = transform.eulerAngles;
    }

    public void Update()
    {
        Move();

        if (SceneManager.GetActiveScene().name == "SpecularMap")
        {
            if (transform.position.y < -2f)
            {
                transform.position = startPos;
                transform.rotation = Quaternion.Euler(startRot);
            }
        }
        
    }

    public void Move()
    {
        moveVector = (Input.GetAxis("Horizontal") * transform.right + Input.GetAxis("Vertical") * transform.forward);
        characterController.Move(moveVector * Speed * Time.deltaTime);

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        velocity.y += gravity * Time.deltaTime;

        characterController.Move(velocity * Time.deltaTime);

      
        if (Input.GetButtonDown("Jump") && isGrounded )
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }
    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("NewArea"))
        {
            gameManager.dotween = false;
        }
    }

}
