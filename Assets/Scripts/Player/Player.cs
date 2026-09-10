using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private InputActionAsset inputActionsAsset;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float gravity = -9.8f;
    [SerializeField] private float friction = 5f;
    public int points = 0;
    public enum PlayerBonus
    {
        None,
        DoublePoints,
        HeadShots,
        Discount,
        Wings,
        MaxAmmo
    }

    private float horizontalMovement;
    private float forwardMovement;
    private PlayerBonus currentPowerUp = PlayerBonus.None;

    private float verticalMovement = -2f;
    public Vector2 camDir = Vector2.zero;
    private CharacterController cc;

    [SerializeField] private PlayerInputs pi;
    [SerializeField] private Inventory inv;

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
            other.GetComponent<Interaccion>().PlayerEntered();
        }
        if (other.CompareTag("PowerUp"))
        {
            PowerUp pu = other.GetComponent<PowerUp>();
            currentPowerUp = pu.pu;
            asyncRemovePowerUp();
            Destroy(other);
        }
    }
    private async void asyncRemovePowerUp(){
        await Awaitable.WaitForSecondsAsync(20);
        if (this == null) return;
        currentPowerUp = PlayerBonus.None;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Interaction"))
        {
            other.GetComponent<Interaccion>().PlayerExit();
        }
    }

    public void AwardPoints(int pts)
    {
        points += pts;
    }

}
