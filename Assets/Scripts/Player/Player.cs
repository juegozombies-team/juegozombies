using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class Player : MonoBehaviour
{
    [SerializeField] private InputActionAsset inputActionsAsset;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float gravity = -9.8f;
    [SerializeField] private float friction = 5f;
    public int points = 0;
    public bool jugadorDentro = false;

    private float horizontalMovement;
    private float forwardMovement;

    private float verticalMovement = -2f;
    public Vector2 camDir = Vector2.zero;
    private CharacterController cc;

    [SerializeField] private PlayerInputs pi;

    private void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    private void Update()
    {
        bool isGrounded = cc.isGrounded;
        Vector3 playerMovement;

        
        
        if (isGrounded)
        {
            playerMovement = pi.moveAction.ReadValue<Vector2>();
            horizontalMovement = Mathf.MoveTowards(horizontalMovement, playerMovement.x * moveSpeed, friction * Time.deltaTime);
            forwardMovement = Mathf.MoveTowards(forwardMovement, playerMovement.y * moveSpeed, friction * Time.deltaTime);
            verticalMovement = -2f;
            playerMovement = new Vector3(horizontalMovement, verticalMovement, forwardMovement);
            camDir = pi.lookAction.ReadValue<Vector2>();
            
        } 
        else
        {
            verticalMovement += gravity * Time.deltaTime;
            playerMovement = new Vector3(0, verticalMovement, 0);
        }

        cc.Move(playerMovement * Time.deltaTime);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Interaction"))
        {
            jugadorDentro = true;
        }
    }

    public void AwardPoints(int pts)
    {
        points += pts;
    }

}
