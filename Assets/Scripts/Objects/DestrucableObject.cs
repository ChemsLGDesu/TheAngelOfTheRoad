using UnityEngine;

public class DestrucableObject : DragableObjects,IDamageOdurability ,IDestroyObjects
{
    [SerializeField] protected int durability = 40;
    void Start()
    {
        
    }

    
    void Update()
    {
        DamageOdurability(10);
    }
    public void DamageOdurability(int reduce)
    {
        reduce = 10;
        Vector2 MousePos = Input.mousePosition;
        Vector3 Gamepos = Camera.main.ScreenToWorldPoint(MousePos);
        Gamepos.z = 0;
        if (Vector3.Distance (Gamepos,transform.position) <= 1)
        {
            durability -=reduce;
            Destroy();
        }       
    }
    
    public void Destroy()
    {
        if(durability <= 0) 
        { 
            Destroy(gameObject);
        
        }
    }
}
