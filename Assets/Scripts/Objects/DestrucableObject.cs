using UnityEngine;

public class DestrucableObject : DragableObjects
{   
    [SerializeField] protected bool hasTouched = false;
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();

        if (animator == null)
        {
            Debug.LogError("El componente Animator no se encontro en " + gameObject.name);
        }
    }

    
    void Update()
    {
        TouchToDestroy();
    }
    public void TouchToDestroy()
    {
        if (hasTouched) return;
        Vector2 MousePos = Input.mousePosition;
        Vector3 Gamepos = Camera.main.ScreenToWorldPoint(MousePos);
        Gamepos.z = 0;
        if (Vector3.Distance (Gamepos,transform.position) <= 2f)
        {            
            hasTouched = true;
            animator.SetTrigger("StartDestroy");
            Destroy(gameObject, 1);
        }
    }   
}
