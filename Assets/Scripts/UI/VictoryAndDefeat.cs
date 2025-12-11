using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;
public class VictoryAndDefeat : MonoBehaviour
{
    public GameObject VictoryPanel;
    public GameObject DefeatPanel;
    public static Action OnVictoryOrDefeat;

    public void MostrarVictory()
    {
        VictoryPanel.SetActive(true);
    }

    public void MostrarDefeat()
    {
        DefeatPanel.SetActive(true);
        Time.timeScale = 0;
        OnVictoryOrDefeat?.Invoke();
    }

    public void ReiniciarNivel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void IrAlMenuPrincipal()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }
}
