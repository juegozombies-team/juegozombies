using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraPosition : MonoBehaviour
{
    [SerializeField] private Camera camara;
    [SerializeField] private float camSpeed = 1;
    [SerializeField] private float sensibility = 1;
    [SerializeField] private float smoothing = 1;
    [SerializeField] private LayerMask coll;
    private PlayerInputs pi;
    [SerializeField] private Vector3 camPosOffset = new Vector3(0.471f,0.7f,-1.8f);
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
        Vector2 lookAround = pi.lookAction.ReadValue<Vector2>();
        

        Vector3 newDesiredAngleX = player.transform.eulerAngles + Vector3.up * lookAround.x * sensibility * Time.deltaTime;
        player.transform.eulerAngles =  Vector3.Slerp(player.transform.eulerAngles,newDesiredAngleX,smoothing);

        float newDesiredAngleY = camara.transform.eulerAngles.x - lookAround.y * sensibility * Time.deltaTime;
        newDesiredAngleY = Mathf.Lerp(camara.transform.eulerAngles.z, newDesiredAngleY, smoothing);
        newDesiredAngleY = Mathf.Clamp(Normalize(newDesiredAngleY),-80f,80f);

        Vector3 camRot = new Vector3(newDesiredAngleY, player.transform.eulerAngles.y, 0);
        camara.transform.eulerAngles = camRot;

        Quaternion rotar_newPos = Quaternion.Euler(camara.transform.eulerAngles.x,player.transform.eulerAngles.y,0);

        Vector3 new_camPosOffset = new Vector3(camPosOffset.x,camPosOffset.y,-1.8f / Mathf.Max(1,Mathf.Abs(newDesiredAngleY/20)));
        transform.position = player.transform.position + rotar_newPos*new_camPosOffset;
        camara.transform.position = Vector3.Lerp(camara.transform.position, transform.position, Time.deltaTime * camSpeed);
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
