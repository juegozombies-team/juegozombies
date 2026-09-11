using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraPosition : MonoBehaviour
{
    [SerializeField] private Camera camara;
    [SerializeField] private float camSpeed = 1;
    [SerializeField] private float sensibility = 1;
    [SerializeField] private float smoothing = 1;
    private InputAction mousePos;
    private Vector3 newDirX = new Vector3(1,0,0);
    private Vector3 newDirY = new Vector3(0,1,0);
    private GameObject player;


    void Start()
    {
        camara.transform.position = transform.position;
        camara.transform.rotation = transform.rotation;
        player = transform.parent.gameObject;
        if (player != null) mousePos = player.GetComponent<PlayerInputs>().lookAction;
    }

    
    void Update()
    {
        camara.transform.position = Vector3.Lerp(camara.transform.position, transform.position, Time.deltaTime * camSpeed);
        
        Vector2 lookAround = mousePos.ReadValue<Vector2>();
        Debug.Log(lookAround);

        Vector3 newDesiredAngleX = player.transform.eulerAngles + Vector3.right * lookAround.x * sensibility * Time.deltaTime;
        player.transform.eulerAngles =  Vector3.Slerp(player.transform.eulerAngles,newDesiredAngleX,smoothing);

        float newDesiredAngleY = camara.transform.eulerAngles.y + lookAround.y * sensibility * Time.deltaTime;
        newDesiredAngleY = Mathf.Lerp(camara.transform.eulerAngles.y, newDesiredAngleY, smoothing);
        newDesiredAngleY = Mathf.Clamp(newDesiredAngleY,-60f,60f);

        Vector3 camRot = new Vector3(transform.eulerAngles.x, newDesiredAngleY, camara.transform.eulerAngles.z);
        camara.transform.eulerAngles = camRot;
    }
}
