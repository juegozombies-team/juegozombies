using UnityEngine;

public abstract class BaseMachine : Interaction
{
    protected Inventory inventory;
    protected AudioSource SFX_FaltaPlata;
    protected int cost;

    protected abstract void Buy();
    protected override void Start()
    {
        base.Start();
        SFX_FaltaPlata = GetComponent<AudioSource>();
    }

    protected override void Update()
    {
        base.Update();
    }
    protected override void Interactuar()
    {
        if (player.points > cost)
        {
            Buy();
        }
        else
        {
            SFX_FaltaPlata.Play();
        }
    }
}
