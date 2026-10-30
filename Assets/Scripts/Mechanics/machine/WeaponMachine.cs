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
        if (inventory.CheckFull()){
            if (inventory.HasItem(Inventory.itemType.Ammo, Inventory.GetAmmoFor(givenWeapon)))
            {
                if (inventory.FindAndFillFirst(Inventory.GetAmmoFor(givenWeapon)))
                {
                    player.AwardPoints(PuntosRequeridos/2);
                    SFX_Comprar.Play();
                }
                else
                {
                    player.AwardPoints(PuntosRequeridos);
                    StartCoroutine(VisualPurchase("Inventory is Full"));
                }
            }
            else
            {
                player.AwardPoints(PuntosRequeridos);
                StartCoroutine(VisualPurchase("Inventory is Full"));
            }
            return;
        }
        if (inventory.GetAmount(givenWeapon) > 0)
        {
            StartCoroutine(VisualPurchase("Bought ammo"));
            EntregarBalas();
            player.AwardPoints(PuntosRequeridos/2);
        }
        else
        {
            EntregarArma();
            StartCoroutine(VisualPurchase("You got: " + givenWeapon));
        }
        SFX_Comprar.Play();
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