using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverScript : MonoBehaviour
{
    [SerializeField] private PlayerHealth ph;

    void Update()
    {
        if (ph.health <= 0)
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }
    
}