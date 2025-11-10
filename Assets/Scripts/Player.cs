using System;
using UnityEngine;

public class Player : MonoBehaviour,IDamageOdurability
{
    public float Speed;
    public static Action OnPlayerWakeup;
    public int barraDespertar = 100;
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
     
    public void DamageOdurability(int reduce)
    {
        reduce = 20;
        barraDespertar -= reduce;
        if (barraDespertar <=0)
        {
            OnPlayerWakeup?.Invoke();
            Debug.Log("Luna a despertado");
        }
    }
}
