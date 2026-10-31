public abstract class BaseMachine : Interaction
{
    protected Inventory inventory;
    protected override int PuntosRequeridos { get => base.PuntosRequeridos; set => base.PuntosRequeridos = value; }

    protected abstract void Buy();

    //----- NUEVO CODIGO ----- Precio real de la compra (por defecto el normal) y marca para no cobrar si Buy() no entregó nada
    protected virtual int CostoActual => PuntosRequeridos;
    protected bool compraFallida = false;
    //----- NUEVO CODIGO -----

    protected override void Start()
    {
        base.Start();
        if (player != null)
        {
            inventory = player.GetComponent<Inventory>();
        }

    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void Interactuar()
    {
        //----- NUEVO CODIGO ----- El precio se calcula antes de Buy(), porque Buy() cambia el inventario
        int costo = CostoActual;
        if (player.points >= costo)
        {
            compraFallida = false;
            Buy();
            if (!compraFallida) player.RemovePoints(costo);
        }
        //----- NUEVO CODIGO -----
        else
        {
            SFX_FaltaPlata.Play();
            StartCoroutine(VisualPurchase("Not enough money"));
        }
    }
}
