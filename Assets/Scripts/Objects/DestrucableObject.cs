using UnityEngine;

public class DestrucableObject : DragableObjects,IDestroyObjects
{   
    [SerializeField] protected bool hasTouched = false;
    Animator animator;
    void Start()
    {
        
    }

    
    void Update()
    {
        TouchToDestroy();
    }
    public void TouchToDestroy()
    {      
        Vector2 MousePos = Input.mousePosition;
        Vector3 Gamepos = Camera.main.ScreenToWorldPoint(MousePos);
        Gamepos.z = 0;
        if (Vector3.Distance (Gamepos,transform.position) <= 2f)
        {
            Debug.Log("Touched");
            hasTouched = true;
            animator.Play("DestroyAnim");
            DestroyObject();
        }
        else
        {
            hasTouched = false;
        }
    }
    
    public void DestroyObject()
    {
            Destroy(gameObject,3);       
    }
}
