using UnityEditor;
using UnityEngine;

public class Door : Interaction
{

    protected override void Start()
    {
        base.Start();
        fullString = "Open";
    }
    protected override void Interactuar()
    {
        Destroy(gameObject);
        textoInteraccion.gameObject.SetActive(false);
    }

}