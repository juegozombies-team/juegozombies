using System;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.Rendering;

public class Hammer : MonoBehaviour
{
    [SerializeField] private float hammerRadius = 5.5f;
    [SerializeField] private float coolDown = 15.0f;
    [SerializeField] private bool isOnCooldown = true;
    [SerializeField] private TextMeshProUGUI HammerText;

    private float cooldownTimer;
    private int timeLeft;
    private int lastTimeLeft;
    void Awake()
    {
        cooldownTimer = coolDown;
        cooldownTimer = 0;
        lastTimeLeft = -1;
    }


    void Update()
    {
        cooldownTimer += Time.deltaTime;
        timeLeft = Mathf.CeilToInt(coolDown - cooldownTimer);

        if (timeLeft <= 0)
        {
            isOnCooldown = false;
            HammerText.text = "Hammer: Ready";

        }
        else
        {
            if (timeLeft != lastTimeLeft)
            {
                HammerText.text = "Hammer: " + timeLeft + "s";
                lastTimeLeft = timeLeft;
            }
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
                //acá va el reproducir sonido de fallo
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
