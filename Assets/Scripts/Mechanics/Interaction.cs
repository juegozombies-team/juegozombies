using UnityEngine;
using UnityEngine.InputSystem;

public abstract class Interaccion : MonoBehaviour
{
    [Header("Configuración")]
    [SerializeField] private int puntosRequeridos;
    [SerializeField] private bool usoUnico = false;
    private InputAction interactAction;
    private Player player;
    [SerializeField] private GameObject textoInteraccion;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        interactAction = GameObject.FindWithTag("Player").GetComponent<PlayerInputs>().interactAction;
    }

    private void Update()
    {
        if (player.jugadorDentro)
        {
            if (interactAction.WasPressedThisFrame())
            {
                Interactuar();
            }
        }
    }

    protected abstract void Interactuar();
}
