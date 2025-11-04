using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed;
    public static Action OnPlayerWakeup;
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
       
    }
    public void PlayerWakeup()
    {
        OnPlayerWakeup?.Invoke();
    }
}
