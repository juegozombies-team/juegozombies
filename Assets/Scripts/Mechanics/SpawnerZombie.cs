using UnityEngine;

public class SpawnerZombie : MonoBehaviour
{

    [SerializeField] GameObject zombie;
    [SerializeField] float zombieSpawnCooldown = 5f;
    [SerializeField] Transform nearestBarricadePos;
    private RoundManager rm;

    public float zombieSpawnTimer;

    void Start()
    {
        SetSpawnTimer();
        rm = GameObject.FindWithTag("RoundManager").GetComponent<RoundManager>();
    }

    void Update()
    {
        zombieSpawnTimer += Time.deltaTime;
        if (zombieSpawnTimer > zombieSpawnCooldown)
        {
            SpawnZombie();
        }
    }

    void SpawnZombie()
    {
        rm.AddZombie(this,transform,nearestBarricadePos.position,zombie);
    }
    public void SetSpawnTimer()
    {
        zombieSpawnTimer = zombieSpawnTimer-(Random.Range(0f,0.2f)*16);
    }
}
