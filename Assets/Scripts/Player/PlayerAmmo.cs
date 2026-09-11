using TMPro;
using UnityEngine;

public class playerAmmunition : MonoBehaviour
{
    [SerializeField] private int ammoMax = 10;
    [SerializeField] private int ammoQuantity = 50;
    [SerializeField] private TextMeshProUGUI ammoText;
    private PlayerInputs pi;

    private int ammoUsed;
    private int ammoCurrent;
    private string ammoTextStart;
    private void Awake()
    {
        ammoCurrent = ammoMax;
        ammoTextStart = ammoText.text;
        ammoText.text = ammoText.text + " " + ammoMax + " / " + ammoQuantity;
    }
    private void Start()
    {
        pi = gameObject.GetComponent<PlayerInputs>();
    }

    private void Update()
    {
        //testeo para ver si funciona
        if (pi.shootAction.WasPressedThisFrame())
        {
            fireAmmo();
        }

        if (pi.reloadAction.WasPressedThisFrame())
        {
            rechargeAmmo();
        }
    }
    public void fireAmmo()
    {
        ammoCurrent--;
        if (ammoCurrent < 0)
        {
            ammoCurrent = 0;
        }
        ammoText.text = ammoTextStart + " " + ammoCurrent + " / " + ammoQuantity;
    }
    public void rechargeAmmo()
    {
        
        ammoUsed = ammoMax - ammoCurrent;
        if (ammoQuantity < ammoUsed)
        {
            ammoUsed = ammoQuantity;
        }
        ammoCurrent += ammoUsed;

        ammoQuantity -= ammoUsed;
        if (ammoQuantity < 0)
        {
            ammoQuantity = 0;
        }
        ammoText.text = ammoTextStart + " " + ammoCurrent + " / " + ammoQuantity;
    }
}
