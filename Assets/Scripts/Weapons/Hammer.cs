using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Hammer : MonoBehaviour
{
    [SerializeField] private float HammerRadius;
    [SerializeField] private float StunDuration;
    [SerializeField] private float CoolDown;
    [SerializeField] private bool IsStunned;
    



    void Start()
    {
        
    }


    void Update()
    {
        if (Input.GetKeyUp(KeyCode.X))
        {
            
        }
        
        

    }
}
