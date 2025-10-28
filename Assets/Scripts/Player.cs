using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed;
    void Start()
    {
        
    }

    
    void Update()
    {
        Walk();
    }
    public void Walk()
    {
       transform.position += Vector3.right*Speed*Time.deltaTime;
        //if(transform.position.x>=)
    }
}
