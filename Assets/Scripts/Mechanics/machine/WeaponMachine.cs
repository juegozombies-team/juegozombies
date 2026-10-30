using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class WeaponMachine : BaseMachine
{
    [SerializeField] private Inventory.itemIndex givenWeapon;

    protected override void Start()
    {
        base.Start();
        fullString = "Buy " + givenWeapon + " (" + PuntosRequeridos + ") (E)";
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
                    StartCoroutine(VisualPurchase("Inventory is full"));
                }
            }
            else
            {
                player.AwardPoints(PuntosRequeridos);
                StartCoroutine(VisualPurchase("Inventory is full"));
            }
            return;
        }
        if (inventory.GetAmount(givenWeapon) > 0)
        {
            StartCoroutine(VisualPurchase("Bought ammo"));
            EntregarBalas();
            player.AwardPoints(PuntosRequeridos / 2);
        }
        else
        {
            EntregarArma();
            StartCoroutine(VisualPurchase("You got: " + givenWeapon));
        }
        SFX_Comprar.Play();
    }

    public override void PlayerStay()
    {
        if (inventory.CheckFull())
        {
            fullString = "Your inventory is full";
            textoInteraccion.text = fullString;
            return;
        }
        if (inventory.GetAmount(givenWeapon) > 0)
        {
            fullString = "Buy ammo for " + givenWeapon + " (" + PuntosRequeridos / 2 + ") (E)";
            textoInteraccion.text = fullString;
        }
        else
        {
            fullString = "Buy " + givenWeapon + " (" + PuntosRequeridos + ") (E)";
            textoInteraccion.text = fullString;
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