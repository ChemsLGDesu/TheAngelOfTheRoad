using UnityEngine;
using UnityEngine.UI;
public class FillVetaDeSilencio : MonoBehaviour
{
    public Image RellenoVeta;
    private PlayerMovement playerMovement;
    private float BarraVetaMaxima;
    void Start()
    {
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
        BarraVetaMaxima = playerMovement.barraDespertar;
    }

    void Update()
    {
        Formula();
    }

    public void Formula()
    {
        RellenoVeta.fillAmount = playerMovement.barraDespertar / BarraVetaMaxima;
    }
}
