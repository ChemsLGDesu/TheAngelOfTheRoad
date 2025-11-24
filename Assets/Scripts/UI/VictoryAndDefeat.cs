using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class VictoryAndDefeat : MonoBehaviour
{
    public GameObject VictoryPanel;
    public GameObject DefeatPanel;

    public void MostrarVictory()
    {
        VictoryPanel.SetActive(true);
    }

    public void MostrarDefeat()
    {
        DefeatPanel.SetActive(true);
    }

    public void ReiniciarNivel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void IrAlMenuPrincipal()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }
}
