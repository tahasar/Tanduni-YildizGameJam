using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterMovement : MonoBehaviour
{
    Vector3 moveVector;
    CharacterController characterController;
    public float Speed = 5f;

    [SerializeField] GameObject enemy;

    [Header("Ray")]
    [SerializeField] Transform rayPoint;
    RaycastHit hit;
    [SerializeField] GameObject imageUI;

    [Header("Pref")]
    [SerializeField] GameObject button;
    [SerializeField] GameObject key;
    [SerializeField] int buttonAmount = 0;
    [SerializeField] GameObject ExitDoor;

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

        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();

        startPos = transform.position;
       
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
        
        //TEXTURESUZ SAHNEDEYSE
        /* if (velocity.y < -10f)
         {
             gameObject.transform.position = startPos;
         }*/
        if (enemy != null)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);

            if (distance < 5f)
            {
                enemy.GetComponent<Animator>().SetBool("EnemyAttack", true);
            }
        }

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 25f))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (hit.collider.CompareTag("Button"))
                {
                    hit.collider.gameObject.SetActive(false);
                    imageUI.SetActive(true);
                    buttonAmount++;
                }
                if (hit.collider.CompareTag("Key"))
                {
                    key.SetActive(false);
                    ExitDoor.SetActive(true);
                }
                else
                {
                    imageUI.SetActive(false);
                }
            }

        }

        if (buttonAmount >3)
        {
            key.SetActive(true);
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


        if (Input.GetButtonDown("Jump") && isGrounded)
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
        if (col.gameObject.CompareTag("ExitDoor"))
        {
            //Sherlock Sahnesi
        }

    }



}
