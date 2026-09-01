using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class Player : MonoBehaviour
{
    [SerializeField] private InputActionAsset inputActionsAsset;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float fallSpeed = -9.8f;

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
            verticalMovement= -2f;
            playerMovement = new Vector3(playerMovement.x, verticalMovement, playerMovement.y);
            
        } 
        else
        {
            verticalMovement += fallSpeed * Time.deltaTime;
            playerMovement = new Vector3(0, verticalMovement, 0);
        }

        cc.Move(playerMovement * moveSpeed * Time.deltaTime);
        
    }

}
