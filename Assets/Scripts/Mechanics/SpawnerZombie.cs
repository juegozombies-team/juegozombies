using UnityEngine;

public class SpawnerZombie : MonoBehaviour
{

    [SerializeField] GameObject zombie;
    [SerializeField] float zombieSpawnCooldown = 15f;
    [SerializeField] Vector3 nearestBarricadePos;

    private float zombieSpawnTimer;

    void Start()
    {
        zombieSpawnTimer = zombieSpawnCooldown;
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
        zombie.GetComponent<ZombieBase>().goTo(nearestBarricadePos);
    }
}
