using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject TablasPrefab;
    [SerializeField] private Tabla refTabla;
    [SerializeField] private float currenTime_1;
    
    [SerializeField] private float TimeSpawnTabla = 1.5f;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        DetectMouse();
        currenTime_1 += Time.deltaTime;
        
        
    }
    public void DetectMouse()
    {
        Vector2 MousePos = Input.mousePosition;
        Vector3 Gamepos =Camera.main.ScreenToWorldPoint(MousePos);
        if (Input.GetMouseButton(1) && currenTime_1 >= TimeSpawnTabla)
        {
            
            // asi se spawnean objetos desde el mismo mouse
            Gamepos.z = 0;
            Debug.Log("Se spawneo tabla");
            GameObject TablaPrefab = Instantiate(TablasPrefab, Input.mousePosition, Quaternion.identity);
            TablaPrefab.transform.position = Gamepos;
            currenTime_1 = 0;
        }
              
    }

    
}
