using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class Interaction : MonoBehaviour
{
    [Header("Configuración")]
    [SerializeField] protected int puntosRequeridos;
    [SerializeField] protected bool usoUnico = false;
    protected PlayerInputs pi;
    protected bool jugadorDentro = false;
    protected Player player;
    [SerializeField] protected TextMeshProUGUI textoInteraccion;
    protected String endOfString = " (E)";
    protected String fullString = "";


    protected virtual void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        pi = GameObject.FindWithTag("Player").GetComponent<PlayerInputs>();
    }

    protected virtual void Update()
    {
        if (jugadorDentro)
        {
            textoInteraccion.text = "la casa de mickey mouse";
            textoInteraccion.gameObject.SetActive(true);
            if (pi.interactAction.WasPressedThisFrame())
            {
                Interactuar();
            }
        }
        else
        {
            textoInteraccion.gameObject.SetActive(false);
        }
    }

    protected abstract void Interactuar();

    public virtual void PlayerEntered()
    {
        jugadorDentro = true;
    }
    public virtual void PlayerExit()
    {
        jugadorDentro = false;
    }
}
