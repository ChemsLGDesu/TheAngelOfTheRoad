using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject TablasPrefab;
    [SerializeField] private float currenTime;
    [SerializeField] private float TimeSpawnTabla = 10;
    void Start()
    {
        
    }

    
    void Update()
    {
        DetectMouse();
        currenTime += Time.deltaTime;
    }
    private void DetectMouse()
    {
        Vector2 MousePos = Input.mousePosition;
        Vector3 Gamepos =Camera.main.ScreenToWorldPoint(MousePos);       
        if (Input.GetMouseButtonDown(0) && currenTime>=TimeSpawnTabla)
        {
        
           // asi se spawnean objetos desde el mismo mouse
            Gamepos.z = 0;
            Debug.Log("Se spawneo tabla");
            GameObject TablaPrefab = Instantiate(TablasPrefab , Input.mousePosition,Quaternion.identity);
            TablaPrefab.transform.position = Gamepos; 
            currenTime = 0;
        }
    }
}
