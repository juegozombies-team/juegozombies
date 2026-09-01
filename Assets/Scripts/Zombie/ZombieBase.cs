using System.Threading;
using UnityEngine;

public class ZombieBase : MonoBehaviour
{
    private float health;
    public bool Active = true;
    private bool isStunned = false;
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
            return false;
        }
        timerPos = 0f;
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
    public async void Stun()
    {
        isStunned = true;
        await Awaitable.WaitForSecondsAsync(2f);
        if (this != null)
        {
            isStunned = false;
        }
    }
    public void ReceiveDamage(bool isHeadshot, float damage)
    {
        if (isHeadshot)
        {
            health -= damage * 5;
        }
        health -= damage;
        if (health <= 0)
        {
            Despawn();
        }
    }
}
