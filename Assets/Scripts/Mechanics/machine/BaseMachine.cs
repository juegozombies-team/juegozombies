using UnityEngine;

public abstract class BaseMachine : Interaction
{
    protected Inventory inventory;
    protected AudioSource SFX_FaltaPlata;

    protected abstract void Buy();
    protected override void Start()
    {
        base.Start();
        //SFX_FaltaPlata = GetComponent<AudioSource>();
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void Interactuar()
    {
        if (player.points >= puntosRequeridos)
        {
            Buy();
            player.RemovePoints(puntosRequeridos);
        }
        else
        {
            //SFX_FaltaPlata.Play();
        }
    }
}
