using System;
using UnityEngine;

public class Player : MonoBehaviour,IDamageOdurability
{
    public Rigidbody2D rb;   
    public PlayerSO data;
    public float Speed = 3.5f ;
    public int barraDespertar = 100;
    public static Action OnPlayerWakeup;
    public Transform DetectionArmReference;
    public Transform feets;

    public float JumpForce = 4f;
    public float JumpGravity = 0.8f;
    public float FallGravity = 1.2f;
    public bool isGrounded = false;

    void Start()
    {
        
    }

    
    void Update()
    {
        Walk();      
        DetectorCollitions();
        GravityEngine();
        CheckTable();
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
    
    public void Walk()
    { 
        transform.position += Vector3.right * Speed * Time.deltaTime;
    }   
    public void JumpAuto()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, JumpForce);
        
    }
    public void GravityEngine()
    {
        if (rb.linearVelocity.y > 0)
        {
            rb.gravityScale = JumpGravity;            
            return;
        }
        else
        {
            rb.gravityScale = FallGravity;           
        }
    }
    public void DetectorCollitions()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(feets.transform.position, 0.1f);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject.tag == "Ground")
            {
                isGrounded = true;
                return;
            }
            else
            {
                isGrounded = false;
            }
        }
    }
    public bool CheckTable()
    {
        Vector2 size = new Vector2(data.DetectSize,data.DetectSize);
        RaycastHit2D[] hitInfos = Physics2D.BoxCastAll(DetectionArmReference.transform.position, size, 0, Vector2.right, data.Distance);
        foreach (var coll in hitInfos) 
        { 
            GameObject go = coll.collider.gameObject;
            if (go.tag == "Tabla" )
            {
                JumpAuto();
                Speed = 0;
                print("Collision" + go.name);              
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
