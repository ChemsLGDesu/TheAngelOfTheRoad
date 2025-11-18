using UnityEngine;

public class Tabla : MonoBehaviour
{
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
        hasTouchGround = true;
    }

}
