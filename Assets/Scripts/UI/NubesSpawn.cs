using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class NubesSpawn : MonoBehaviour
{
    public Image RellenoSpawn;
    private float rellenoMaximo;
    void Start()
    {
        if (GameManager.Instance != null)
        {
            
            rellenoMaximo = GameManager.Instance.TimeSpawnTabla;
        }
        else
        {
            Debug.LogError("GameManager.Instance no está disponible.");
        }
    }

    void Update()
    {
        ProgressCouldDown();
    }

    public void ProgressCouldDown()
    {
        if (GameManager.Instance != null && rellenoMaximo > 0)
        {
            float tiempoActual = Mathf.Clamp(GameManager.Instance.currenTime, 0, rellenoMaximo);
            RellenoSpawn.fillAmount = tiempoActual / rellenoMaximo;
        }
    }
}
