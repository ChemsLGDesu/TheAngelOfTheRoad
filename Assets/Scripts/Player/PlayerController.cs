using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;
    public PlayerMovement playerMovement;    
    public PlayerSO data;
    

    private void Awake()
    {
        
        if (Instance == null)
            Instance = this;
    }
    void Start()
    {
        playerMovement.DetectSize = data.DetectSize;
        playerMovement.Distance = data.Distance;
    }
    void Update()
    {
        
    }
}
