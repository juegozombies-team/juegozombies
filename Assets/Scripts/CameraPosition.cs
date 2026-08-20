using System.Runtime.CompilerServices;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    [SerializeField] private Camera camara;
    [SerializeField] private float camSpeed = 1;


    void Start()
    {
        
    }

    
    void Update()
    {
        camara.transform.position = Vector3.Lerp(camara.transform.position, transform.position, Time.deltaTime * camSpeed);

        Vector3 camRot = new Vector3(camara.transform.eulerAngles.x, camara.transform.eulerAngles.y, camara.transform.eulerAngles.z);
        camRot.y = transform.eulerAngles.y;
        camara.transform.eulerAngles = camRot;
    }
}
