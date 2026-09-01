using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerHealth : MonoBehaviour
{
    
    [SerializeField] private int healthMax = 6;

    [SerializeField] private TextMeshProUGUI healthText;

    private int health = 6;
    private string healthTextStart;
    
    private void Awake()
    {
        health = healthMax;
        healthTextStart = healthText.text;
        healthText.text = healthText.text + " " + health;
    }

    /* private void Update()
    {
        //testeo de los metodos y ver si el hud cambia
       
        if (Input.GetKeyDown(KeyCode.Z))
        {
            loseHealth(1);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            gainHealth(1);
        }
        
    } */
    public void gainHealth(int bonusHealth)
    {
        health += bonusHealth;
        if (health > healthMax) {
            health = healthMax;
        }
        healthText.text = healthTextStart + " " + health;
    }
    public void loseHealth(int damage)
    {
        health -= damage;

        if (health < 0)
        {
            health = 0;
        }
        healthText.text = healthTextStart + " " + health;
    }
}
