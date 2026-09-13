using UnityEngine;

public class PistolBulletMachine : BaseMachine
{
    protected override void Start()
    {
        base.Start();
        fullString = "Comprar Balas " + puntosRequeridos + " (E)";
    }
        protected override void Buy()
    {
        player.GetComponent<playerAmmunition>().GainAmmo(20);
    }
}
