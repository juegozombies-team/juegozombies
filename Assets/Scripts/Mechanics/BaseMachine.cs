using Unity.VisualScripting;
using UnityEngine;

public abstract class BaseMachine : Interaccion
{
    protected Inventory inventory;
    protected AudioSource SFX_FaltaPlata;
    protected int cost;
    protected enum item
    {
        M1911,
        M93R,
        M4,
        AK47,
        AWP,
        MAC10,
        Micro_Uzi,
        MP5,
        RPG,
        Remington,
        Granada,
        Espray_curativo
    }

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
