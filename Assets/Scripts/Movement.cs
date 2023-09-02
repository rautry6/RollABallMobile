using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float maxSpeed = 6f;
    PlayerMovement playerMovment;
    InputAction move;

    Rigidbody rb;

    Vector3 moveDirection;
    private void Awake()
    {
        playerMovment = new PlayerMovement();
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        move = playerMovment.Player.Move;
        move.Enable();
    }

    private void OnDisable()
    {
        move.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         moveDirection = move.ReadValue<Vector3>();
    }

    private void FixedUpdate()
    {

        rb.AddForce(new Vector3(moveDirection.x, 0, moveDirection.y) * moveSpeed * Time.deltaTime, ForceMode.Impulse);
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
    }
}
