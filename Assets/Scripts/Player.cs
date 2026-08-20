using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private InputActionAsset inputActionsAsset;
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
            playerMovement = new Vector3(playerMovement.x, 0, playerMovement.y);
        } 
        else
        {
            playerMovement = new Vector3(0, -9.8f * Time.deltaTime, 0);
        }

        cc.Move(playerMovement);
        
    }

}
