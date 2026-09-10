using UnityEngine;
using UnityEngine.InputSystem;

public abstract class Interaccion : MonoBehaviour
{
    [Header("Configuración")]
    [SerializeField] protected int puntosRequeridos;
    [SerializeField] protected bool usoUnico = false;
    protected InputAction interactAction;
    protected bool jugadorDentro = false;
    protected Player player;
    [SerializeField] protected GameObject textoInteraccion;

    protected virtual void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        interactAction = GameObject.FindWithTag("Player").GetComponent<PlayerInputs>().interactAction;
    }

    protected virtual void Update()
    {
        if (jugadorDentro)
        {
            if (interactAction.WasPressedThisFrame())
            {
                Interactuar();
            }
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
