using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{    
    public static GameManager Instance;
    [SerializeField] private GameObject TablasPrefab;
    public InputSystem_Actions inputs;
    public PlayerMovement PlayerMovement;
    public float currenTime;  
    public float TimeSpawnTabla = 2f;

    private void Awake()
    {
        if (Instance == null) 
        Instance = this;
        inputs = new();
    }
    void Start()
    {
        
    }
    private void OnEnable()
    {
        inputs.Enable();
        inputs.Player.Attack.started += OnSpawnTable;
        inputs.Player.Attack.performed += OnSpawnTable;
        inputs.Player.Attack.canceled += OnSpawnTable;

        inputs.Player.Interact.started += OnDragObj;
        inputs.Player.Interact.performed += OnDragObj;
        inputs.Player.Interact.canceled += OnDragObj;
    }

    

    private void OnDisable()
    {
        
        inputs.Player.Attack.started -= OnSpawnTable;
        inputs.Player.Attack.performed -= OnSpawnTable;
        inputs.Player.Attack.canceled -= OnSpawnTable;

        inputs.Player.Interact.started -= OnDragObj;
        inputs.Player.Interact.performed -= OnDragObj;
        inputs.Player.Interact.canceled -= OnDragObj;
        inputs.Disable();   
    }

    void Update()
    {
        
        currenTime += Time.deltaTime;     
    }   
    public bool IsAbleToSpawn()
    {
        if(currenTime <= TimeSpawnTabla)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    private void OnSpawnTable(InputAction.CallbackContext context)
    {
        Vector2 MousePos = Input.mousePosition;
        Vector3 Gamepos = Camera.main.ScreenToWorldPoint(MousePos);
        if (context.performed && currenTime >= TimeSpawnTabla)
        {
            // asi se spawnean objetos desde el mismo mouse
            Gamepos.z = 0;
            SoundManager.PlaySound(SoundType.NUBE);
            GameObject TablaPrefab = Instantiate(TablasPrefab, Input.mousePosition, Quaternion.identity);
            TablaPrefab.transform.position = Gamepos;
            currenTime = 0;
        }
    }
    private void OnDragObj(InputAction.CallbackContext context)
    {
        DragableObjects.Instance.VerificateDrag();
    }
}
