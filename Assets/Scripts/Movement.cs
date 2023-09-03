using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
 private float moveSpeed = 3f;
   private float maxSpeed = 1f;

    [SerializeField] private GameObject[] movementUis;
    [SerializeField] private GameObject[] buttons;
    [SerializeField] private GameObject gameOverUi;

    [SerializeField] private GameObject optionsUI;
    PlayerMovement playerMovment;
    InputAction move;
    InputAction touchMovement;

    Rigidbody rb;

    Vector3 moveDirection;

    bool moveOption3Selected = false;

    private void Awake()
    {
        playerMovment = new PlayerMovement();
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        move = playerMovment.Player.Move;
        touchMovement = playerMovment.Touch.Move;
        move.Enable();
    }

    private void OnDisable()
    {
        touchMovement.Disable();
        move.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (moveOption3Selected)
        {
            moveDirection = touchMovement.ReadValue<Vector3>();
        }
        else
        {
            moveDirection = move.ReadValue<Vector3>();
        }
    }

    private void FixedUpdate()
    {

        rb.AddForce(new Vector3(moveDirection.x, 0, moveDirection.y) * moveSpeed * Time.deltaTime, ForceMode.Impulse);
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
    }

    public void Movement1()
    {
        movementUis[0].SetActive(true);
        movementUis[1].SetActive(false);
        movementUis[2].SetActive(false);

        touchMovement.Disable();
        move.Enable();
        moveOption3Selected = false;

        moveSpeed = 3;
        maxSpeed = 1;
    }

    public void Movement2()
    {
        movementUis[0].SetActive(false);
        movementUis[1].SetActive(true);
        movementUis[2].SetActive(false);

        touchMovement.Disable();
        move.Enable();
        moveOption3Selected = false;

        moveSpeed = 3;
        maxSpeed = 1;
    }

    public void Movement3()
    {
        movementUis[0].SetActive(false);
        movementUis[1].SetActive(false);
        movementUis[2].SetActive(true);

        touchMovement.Enable();
        move.Disable();
        moveOption3Selected = true;

        moveSpeed = 1;
        maxSpeed = 1;
    }

    void DisableUI()
    {
        movementUis[0].SetActive(false);
        movementUis[1].SetActive(false);
        movementUis[2].SetActive(false);

        foreach(GameObject button in buttons)
        {
            button.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Goal"))
        {
            GameOver();
        }
    }

    void GameOver()
    {
        //Disable inputs
        touchMovement.Disable();
        move.Disable();

        gameOverUi.SetActive(true);
        DisableUI();

    }

    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
