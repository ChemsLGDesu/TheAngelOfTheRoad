using System;
using UnityEngine;

public class Player : MonoBehaviour,IDamageOdurability
{
    [SerializeField]private Rigidbody2D rb;
    [SerializeField] private float jumpForce;
    public PlayerSO data;
    public float Speed ;
    public int barraDespertar = 100;
    public static Action OnPlayerWakeup;
    public Transform DetectionArmReference;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        Walk();
        CheckTable();
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
    public bool CheckTable()
    {
        Vector2 size = new Vector2(data.DetectSize,data.DetectSize);
        RaycastHit2D[] hitInfos = Physics2D.BoxCastAll(DetectionArmReference.transform.position, size, 0, Vector2.right, data.Distance);
        foreach (var coll in hitInfos) 
        { 
            GameObject go = coll.collider.gameObject;
            if (go.tag == "Tabla")
            {
                Speed = 0;
                print("Collision" + go.name);
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                return true;
            }
            else 
            {
                Speed = 3.5f;
            
            }

        }
        return false;
    }
}
