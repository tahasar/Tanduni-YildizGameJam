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
    [SerializeField] ZombieMovement boss;


    [Header("Ray")]
    [SerializeField] Transform rayPoint;
    RaycastHit hit;
    [SerializeField] GameObject imageUI;

    [Header("Pref")]
    [SerializeField] GameObject button;
    [SerializeField] GameObject key;
    [SerializeField] int buttonAmount = 0;
    [SerializeField] GameObject ExitDoor;
    [SerializeField] NpcTalk npcTalk;

    [Header("Ground")]
    public Transform groundCheck;
    public float groundDistance = 5f;
    public LayerMask groundMask;
    public float gravity = -9.80f;
    public float jumpHeight = 3f;
    Vector3 velocity;
    public bool isGrounded;
    [HideInInspector] GameManager gameManager;
    public LoadManager loadManager;
    [SerializeField] GameObject zombieAmount;
    [HideInInspector] ZombieHealth enemyAxe;

    Vector3 startPos;
    Vector3 startRot;

    public void Start()
    {
        characterController = GetComponent<CharacterController>();

        if (SceneManager.GetActiveScene().name == "BaltaMap")
        {
            enemyAxe = GameObject.FindGameObjectWithTag("EnemyAxeMap").GetComponent<ZombieHealth>();
        }
       
        startPos = transform.position;
        startRot = transform.eulerAngles;

        if (boss != null)
            boss = GameObject.FindGameObjectWithTag("Boss").GetComponent<ZombieMovement>();
       

        if (npcTalk!=null)
            npcTalk = GameObject.FindGameObjectWithTag("NpcTalk").GetComponent<NpcTalk>();

        if (gameManager!=null)
            gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();

        startPos = transform.position;

    }

    public void Update()
    {
        if (SceneManager.GetActiveScene().name == "ZombieScene")
        {
            if (zombieAmount.transform.childCount == 0)
            {
                LoadManager.instance.LoadNextLevel("SpecularMap");
            }
        }

        if (SceneManager.GetActiveScene().name == "BaltaMap")
        {
            if (enemyAxe.gameObject.CompareTag("EnemyAxeMap"))
            {
                if (enemyAxe.zombieHealth <= 0)
                {
                    LoadManager.instance.LoadNextLevel("PixelScene");
                }
            }
        }
        
            Move();

        if (SceneManager.GetActiveScene().name == "SpecularMap" || SceneManager.GetActiveScene().name == "BaltaMap" || SceneManager.GetActiveScene().name == "ParkurMap")
        {
            if (transform.position.y < -2f)
            {
                transform.position = startPos;
                transform.rotation = Quaternion.Euler(startRot);
            }
        }
        {
            if (transform.position.y < -2f)
            {
                transform.position = startPos;
                transform.rotation = Quaternion.Euler(startRot);
            }
        }

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
                if (SceneManager.GetActiveScene().name == "PixelScene")
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
        }

        if (buttonAmount > 3)
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
        if (loadManager != null)
        {
            if (col.gameObject.CompareTag("NewArea") && gameManager != null)
            {
                gameManager.dotween = false;
            }
            if (col.gameObject.CompareTag("ExitDoor"))
            {
                loadManager.LoadNextLevel("SherlockMapFinish");
            }
            if (col.gameObject.CompareTag("SherlockExit"))
            {
                loadManager.LoadNextLevel("Masaustu");
            }
            if (col.gameObject.CompareTag("ParkurFinish"))
            {
                loadManager.LoadNextLevel("BaltaMap");
            }
            if (col.gameObject.CompareTag("StartDoor"))
            {
                loadManager.LoadNextLevel("ZombieScene");
            }
            if (col.gameObject.CompareTag("Cesme"))
            {
                loadManager.LoadNextLevel("RedScene");
            }
            if (col.gameObject.CompareTag("RedFinish"))
            {
                loadManager.LoadNextLevel("ParkurMap");
            }
        

            if (col.gameObject.CompareTag("EnemyCraw"))
            {
                boss.Craw();
            }
           
        }
    }
    
    
    public void OyundanCik1()
    {
        VoiceManager.instance.Play("sahne20");
        InvokeRepeating("OyundanCik2",45f,0f);
    }
    
    public void OyundanCik2()
    {
        Debug.Log("sssssss");
        Application.Quit();
    }
}
