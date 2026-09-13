using UnityEditor;
using UnityEngine;

public class Door : Interaction
{

    protected override void Start()
    {
        base.Start();
        fullString = "Abrir Puerta (" + puntosRequeridos + ") (E)";
    }
    protected override void Interactuar()
    {
        if (player.points >= puntosRequeridos)
        {
            player.RemovePoints(puntosRequeridos);
            Destroy(gameObject);
            textoInteraccion.gameObject.SetActive(false);
        }
        else
        {
            //SFX_FaltaPlata.Play();
        }
    }

}