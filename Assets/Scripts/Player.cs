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

    private float horizontalMovement;
    private float forwardMovement;

    private float verticalMovement = -2f;
    private InputActionMap playerMap;
    private InputAction moveAction;
    private CharacterController cc;

    private void Awake()
    {

        playerMap = inputActionsAsset.FindActionMap("Player");

        moveAction = playerMap.FindAction("Move");
    }
    private void OnEnable()
    {
        playerMap.Enable();
    }

    private void OnDisable()
    {
        playerMap.Disable();
    }

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
            playerMovement = moveAction.ReadValue<Vector2>();
            horizontalMovement = Mathf.MoveTowards(horizontalMovement, playerMovement.x * moveSpeed, friction * Time.deltaTime);
            forwardMovement = Mathf.MoveTowards(forwardMovement, playerMovement.y * moveSpeed, friction * Time.deltaTime);
            verticalMovement = -2f;
            playerMovement = new Vector3(horizontalMovement, verticalMovement, forwardMovement);
            
        } 
        else
        {
            verticalMovement += gravity * Time.deltaTime;
            playerMovement = new Vector3(0, verticalMovement, 0);
        }

        cc.Move(playerMovement * Time.deltaTime);
        
    }

}
