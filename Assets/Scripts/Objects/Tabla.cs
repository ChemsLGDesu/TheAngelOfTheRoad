using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class Tabla : MonoBehaviour
{
    public static Tabla Instance;
    public BoxCollider2D boxCollider2D;
    bool hasTouchGround =  false;
    void Start()
    {
        
    }

    
    void Update()
    {
        if (hasTouchGround)
            Destroy(gameObject,10);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            boxCollider2D.isTrigger = true;
        }
        else
        {
            boxCollider2D.isTrigger = false;
        }
        hasTouchGround = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            boxCollider2D.isTrigger = false;
        }
        if(collision.tag == "Tabla")
        {
            boxCollider2D.isTrigger = false;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            boxCollider2D.isTrigger = false;
        }
        if (collision.tag == "Tabla")
        {
            boxCollider2D.isTrigger = false;
        }
    }

}
