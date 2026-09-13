using UnityEngine;

public class SpawnerZombie : MonoBehaviour
{

    [SerializeField] GameObject zombie;
    [SerializeField] float zombieSpawnCooldown = 15f;
    [SerializeField] Transform nearestBarricadePos;

    private float zombieSpawnTimer;

    void Start()
    {
        zombieSpawnTimer = zombieSpawnCooldown - Random.Range(0f,5f);

    }

    void Update()
    {
        zombieSpawnTimer += Time.deltaTime;
        if (zombieSpawnTimer > zombieSpawnCooldown)
        {
            SpawnZombie();
            zombieSpawnTimer = 0;
        }
    }

    void SpawnZombie()
    {
        Instantiate(zombie, transform.position, zombie.transform.rotation);
        zombie.GetComponent<ZombieBase>().goTo(nearestBarricadePos.position);
    }
}
