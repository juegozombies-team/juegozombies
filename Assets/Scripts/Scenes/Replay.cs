using UnityEngine;
using UnityEngine.SceneManagement;


public class Replay : MonoBehaviour
{


    void Start()
    {

    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene("mainGameLoop");
        }
      
    }
}
