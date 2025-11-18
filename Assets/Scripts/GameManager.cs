using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private GameObject TablasPrefab;

    public Player player;
    
    [SerializeField] private float currenTime_1;
    
    [SerializeField] private float TimeSpawnTabla = 1.5f;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
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
        if (Input.GetMouseButton(1) && currenTime_1 >= TimeSpawnTabla)// implementar impjut system
        {
            
            // asi se spawnean objetos desde el mismo mouse
            Gamepos.z = 0;
            Debug.Log("Se spawneo tabla");
            GameObject TablaPrefab = Instantiate(TablasPrefab, Input.mousePosition, Quaternion.identity);
            TablaPrefab.transform.position = Gamepos;
            currenTime_1 = 0;
        }
              
    }
    public bool IsAbleToSpawn()
    {
        if(currenTime_1 <= TimeSpawnTabla)
        {
            currenTime_1 += Time.deltaTime;
            return false;
        }
        else
        {
            return true;
        }
    }

    
}
