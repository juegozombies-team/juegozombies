using System.Collections;
using UnityEngine;


public class Barricade : Interaction
{
    [Header("Arrastra las barricadas en orden de aparición:")]
    [SerializeField] private GameObject[] barricades;
    public bool isOpen { get; private set; } = false;
    private bool cycle = false;
    [SerializeField] private float delayBarricada = 0.5f;

    protected override void Start()
    {
        base.Start();

        for (int i = 0; i < transform.childCount - 1; i++)
        {
            barricades[i] = transform.GetChild(i).gameObject;
        }

    }
    // Update is called once per frame
    protected override void Update()
    {
        if (jugadorDentro && interactAction.IsPressed())
        {
            Interactuar();
        }
    }
    protected override void Interactuar()
    {
        StartCoroutine(BarricadeCorrutine());
    }
    IEnumerator BarricadeCorrutine()
    {
        if (cycle)
        {
            cycle = false;
            for (int i = 0; i < barricades.Length; i++)
            {
                if (barricades[i].activeSelf)
                {
                    barricades[i].SetActive(true);
                    break;
                }
            }
            yield return new WaitForSeconds(delayBarricada);
            cycle = true;
        }
    }
}
