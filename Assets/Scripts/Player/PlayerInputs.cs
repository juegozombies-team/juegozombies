using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputs : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public InputActionAsset inputActionsAsset;
    public InputActionMap playerMap;
    public InputAction moveAction;
    public InputAction lookAction;
    public InputAction interactAction;
    public InputAction nextAction;
    public InputAction prevAction;
    public InputAction sprintAction;
    public InputAction aimAction;
    public InputAction shootAction;
    public InputAction skillAction;
    private void Awake()
    {

        playerMap = inputActionsAsset.FindActionMap("Player");

        moveAction = playerMap.FindAction("Move");
        lookAction = playerMap.FindAction("Look");
        interactAction = playerMap.FindAction("Interact");
        nextAction = playerMap.FindAction("Next");
        prevAction = playerMap.FindAction("Previous");
        sprintAction = playerMap.FindAction("Sprint");
        aimAction = playerMap.FindAction("Aim");
        shootAction = playerMap.FindAction("Shoot");
        skillAction = playerMap.FindAction("Skill");
    }

    private void OnEnable()
    {
        playerMap.Enable();
    }

    private void OnDisable()
    {
        playerMap.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
