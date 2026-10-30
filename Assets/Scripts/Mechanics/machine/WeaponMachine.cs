using UnityEngine;

public class WeaponMachine : BaseMachine
{
    [SerializeField] private Inventory.itemIndex givenWeapon;

    protected override void Start()
    {
        base.Start();
        fullString = "Buy gun (" + PuntosRequeridos + ") (E)";
    }

    protected override void Buy()
    {
        if (inventory.GetAmount(givenWeapon) > 0)
        {
            StartCoroutine(VisualPurchase("Bought ammo"));
            EntregarBalas();
            player.AwardPoints(PuntosRequeridos/2);
            SFX_Comprar.Play();
        }
        else
        {
            EntregarArma();
            StartCoroutine(VisualPurchase("You got: " + givenWeapon));
            SFX_Comprar.Play();
        }
    }

    private void EntregarArma()
    {
        Inventory.Item nuevaArma = Inventory.CreateItem(givenWeapon);
        inventory.AddItem(nuevaArma);
        Inventory.itemIndex tipoDeBalas = Inventory.GetAmmoFor(givenWeapon);
        Inventory.Item nuevasBalas = Inventory.CreateItem(tipoDeBalas, Inventory.GetLimit(tipoDeBalas)/2);
        inventory.AddItem(nuevasBalas);
    }
    private void EntregarBalas()
    {
        Inventory.itemIndex tipoDeBalas = Inventory.GetAmmoFor(givenWeapon);
        Inventory.Item nuevasBalas = Inventory.CreateItem(tipoDeBalas, Inventory.GetLimit(tipoDeBalas)/2);
        inventory.AddItem(nuevasBalas);
    }
}