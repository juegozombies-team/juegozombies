using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private Player player;
    public Player.PlayerBonus pu;
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        pu = (Player.PlayerBonus)Random.Range(0, 6);
    }

    void Update()
    {
        
    }
}
