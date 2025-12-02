using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour,IDamageOdurability
{
    public int barraDespertar = 100;
    public static Action OnPlayerWakeup;
    public Rigidbody2D rb;   
    public float JumpForce = 4f;
    public float JumpGravity = 0.8f;
    public float FallGravity = 1.2f;
    public bool isGrounded = false;
    public bool isAbleToJump = true;
    public Transform DetectionArmReference;
    public Transform feets;
    public float Speed ;
    public float DetectSize;
    public float Distance;
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
    public void Walk()
    {
        rb.linearVelocity = new Vector2(Speed, rb.linearVelocity.y);                              //
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
    public void JumpAuto()
    {
        
        if (isAbleToJump)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, JumpForce);           
            print("Jump");
            isAbleToJump = false;
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
                isAbleToJump = true;
                return;
            }
            else if (colliders[i].gameObject.tag == "Tabla") 
            {
                isGrounded = true;
                isAbleToJump = true;
            }
            else
            {
                isGrounded = false;
                isAbleToJump = false;
            }
            
        }
    }
    public bool CheckTable()
    {
        Vector2 size = new Vector2(DetectSize,DetectSize);
        RaycastHit2D[] hitInfos = Physics2D.BoxCastAll(DetectionArmReference.transform.position, size, 0, Vector2.right, Distance);
        foreach (var coll in hitInfos) 
        { 
            GameObject go = coll.collider.gameObject;
            if (go.tag == "Tabla"  && isGrounded)
            {
                JumpAuto();
              
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
    
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("CamaVictory"))
        {
            FindAnyObjectByType<VictoryAndDefeat>().MostrarVictory();
        }

        if (collision.gameObject.CompareTag("Objetos"))
        {
            FindAnyObjectByType<VictoryAndDefeat>().MostrarDefeat();
        }

        if (collision.gameObject.CompareTag("RestardBlock"))
        {
            Debug.Log("Se despierta");
            
        }
    }
   
}
