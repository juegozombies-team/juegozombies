using TMPro;
using UnityEngine;

public class playerAmmunition : MonoBehaviour
{
    [Header("Disparo")]

    [SerializeField] private float raycastDistance = 100f;

    [SerializeField] private Camera cameraPos;

    [SerializeField] private float gunDamage = 1f;

    [Header("Municion")]
    [SerializeField] private int ammoMax = 10;
    [SerializeField] private int ammoQuantity = 50;
    [SerializeField] private TextMeshProUGUI ammoText;
    private PlayerInputs pi;
    [SerializeField] private LayerMask coll;

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
        if (pi.shootAction.WasPressedThisFrame())
        {
            if(ammoCurrent > 0)
            {
                Shoot();
            }
            fireAmmo();
        }

        if (pi.reloadAction.WasPressedThisFrame())
        {
            rechargeAmmo();
        }
    }

    private void Shoot()
    {
        RaycastHit hit;
        Vector3 origin = cameraPos.transform.position;
        Vector3 direction = cameraPos.transform.forward;

        if (Physics.Raycast(origin, direction, out hit, raycastDistance, coll))
        {
            if (hit.collider.CompareTag("ZombieBody"))
            {
                
                ZombieBase zombie = hit.collider.GetComponent<ZombieBase>();

                zombie.ReceiveDamage(false, gunDamage);

            }

            if(hit.collider.CompareTag("ZombieHead"))
            {

                ZombieBase zombie = hit.collider.GetComponentInParent<ZombieBase>();

                zombie.ReceiveDamage(true, gunDamage);

            }

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

    public void GainAmmo(int gainedAmmo)
    {
        ammoQuantity += gainedAmmo;
        ammoText.text = ammoTextStart + " " + ammoCurrent + " / " + ammoQuantity;
    }
}
