using UnityEngine;
using UnityEngine.SceneManagement;


public class Replay : MonoBehaviour
{

    private PlayerInputs pi;
    void Start()
    {
        pi = GetComponentInParent<PlayerInputs>();
    }


    void Update()
    {
        if (pi.reloadAction.WasPressedThisFrame())
        {
            SceneManager.LoadScene("mainGameLoop");
        }
      
    }
}
