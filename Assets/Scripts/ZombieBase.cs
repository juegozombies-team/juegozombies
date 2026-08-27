using System.Threading;
using UnityEngine;

public class ZombieBase : MonoBehaviour
{
    private float health;
    public bool Active = true;
    private RoundManager rm;
    private Player player;
    [SerializeField] private float speed = 5f; 
    private float timerPos = 0f;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        SetHealthBasedOnRound(rm.currentRound);
    }
    // Update is called once per frame
    void Update()
    {
        if (Active){
            if (TimedCheck())
            {
                
            }
            if (health <= 0)
            {
                Despawn();
            }
        }
    }
    private void PlayerPosCheck()
    {
        
    }
    private bool TimedCheck()
    {
        if (timerPos < 0.2f)
        {
            timerPos += Time.deltaTime;
        }
        return true;
    }
    private void SetHealthBasedOnRound(int roundNumber)
    {
        health = 10f + 2 * roundNumber + roundNumber - 1;
    }
    private void Despawn()
    {
        Active = false;

    }
    private void Respawn()
    {
        SetHealthBasedOnRound(rm.currentRound);

    }
}
