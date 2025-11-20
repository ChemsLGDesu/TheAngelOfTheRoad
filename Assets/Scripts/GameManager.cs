using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{    
    public static GameManager Instance;
    [SerializeField] private GameObject TablasPrefab;

    public PlayerMovement PlayerMovement;
    [SerializeField] private float currenTime;
    
    [SerializeField] private float TimeSpawnTabla = 1.5f;

    
    void Start()
    {
        
    }

    
    void Update()
    {
        DetectMouse();
        currenTime += Time.deltaTime;
        
        
    }
    public void DetectMouse() // hacerlo con Input System
    {
        Vector2 MousePos = Input.mousePosition;
        Vector3 Gamepos =Camera.main.ScreenToWorldPoint(MousePos);
        if (Input.GetMouseButton(1) && currenTime >= TimeSpawnTabla)// implementar impjut system
        {
            
            // asi se spawnean objetos desde el mismo mouse
            Gamepos.z = 0;
            Debug.Log("Se spawneo tabla");
            GameObject TablaPrefab = Instantiate(TablasPrefab, Input.mousePosition, Quaternion.identity);
            TablaPrefab.transform.position = Gamepos;
            currenTime = 0;
        }
              
    }
    public bool IsAbleToSpawn()
    {
        if(currenTime <= TimeSpawnTabla)
        {
            currenTime += Time.deltaTime;
            return false;
        }
        else
        {
            return true;
        }
    }

    
}
