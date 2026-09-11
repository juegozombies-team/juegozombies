using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraPosition : MonoBehaviour
{
    [SerializeField] private Camera camara;
    [SerializeField] private float camSpeed = 1;
    [SerializeField] private float sensibility = 1;
    [SerializeField] private float smoothing = 1;
    private PlayerInputs pi;
    private Vector3 newDirX = new Vector3(1,0,0);
    private Vector3 newDirY = new Vector3(0,1,0);
    private GameObject player;


    void Start()
    {
        camara.transform.position = transform.position;
        camara.transform.rotation = transform.rotation;
        player = transform.parent.gameObject;
        if (player != null) pi = player.GetComponent<PlayerInputs>();
    }

    
    void Update()
    {
        camara.transform.position = Vector3.Lerp(camara.transform.position, transform.position, Time.deltaTime * camSpeed);
        
        Vector2 lookAround = pi.lookAction.ReadValue<Vector2>();
        Debug.Log(lookAround);

        Vector3 newDesiredAngleX = player.transform.eulerAngles + Vector3.up * lookAround.x * sensibility * Time.deltaTime;
        player.transform.eulerAngles =  Vector3.Slerp(player.transform.eulerAngles,newDesiredAngleX,smoothing);

        float newDesiredAngleY = camara.transform.eulerAngles.x - lookAround.y * sensibility * Time.deltaTime;
        newDesiredAngleY = Mathf.Lerp(camara.transform.eulerAngles.z, newDesiredAngleY, smoothing);
        newDesiredAngleY = Mathf.Clamp(Normalize(newDesiredAngleY),-60f,60f);

        Vector3 camRot = new Vector3(newDesiredAngleY, player.transform.eulerAngles.y, 0);
        camara.transform.eulerAngles = camRot;
    }

    private float Normalize(float angle)
    {
        angle %= 360f;
        if (angle > 180f)
        {
            angle -= 360f;
        }
        return angle;
    }
}
