using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private Player player;
    public Player.PlayerBonus pu;
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        pu = Player.PlayerBonus.HeadShots;
    }

    void Update()
    {
        
    }
}
