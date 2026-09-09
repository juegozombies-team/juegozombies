using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Hammer : MonoBehaviour
{
    [SerializeField] private float hammerRadius = 5.5f;
    [SerializeField] private float coolDown = 15.0f;
    [SerializeField] private bool isOnCooldown = true;

    private float cooldownTimer;

    void Start()
    {
        cooldownTimer = coolDown;
    }


    void Update()
    {
        cooldownTimer += Time.deltaTime;

        if (cooldownTimer > coolDown)
        {
            isOnCooldown = false;
        }

        if (Input.GetKeyUp(KeyCode.X))
        {
            if (!isOnCooldown)
            {
                HammerStun();
                isOnCooldown = true;
                cooldownTimer = 0;
            }
            else
            {
                //aca va el reproducir sonido de fallo
            }
        }



    }

    void HammerStun()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, hammerRadius);
        foreach (Collider collider in colliders)
        {

            ZombieBase zombie = collider.GetComponent<ZombieBase>();
            if (zombie != null)
            {
                zombie.Stun();
            }
        }

    }


    void SonidoCooldown()
    {
        
    }



}
