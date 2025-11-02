using UnityEngine;
using UnityEngine.EventSystems;


public class DragableObjects : MonoBehaviour,IDragHandler//,IPointerDownHandler,IPointerUpHandler
{
    [SerializeField] private bool isDragging =false;
  
    
    void Start()
    {
        
    }

    
    void Update()
    {
        DragObject();
    }
    
    public void DragObject()
    {
        Vector2 MousePos = Input.mousePosition;
        if (Input.GetMouseButton(0)) 
        {
            isDragging = true;
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(MousePos);
            worldPos.z = 0;
            transform.position = worldPos;
            
            //transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);           
        }
        else
        {
            isDragging = false;
        }      
    }
    /*
public void OnPointerDown(PointerEventData eventData)
{
   isDragging = true;
}

public void DragObject(PointerEventData eventData)
{
   if (isDragging)
   {

   }

}
public void OnPointerUp(PointerEventData eventData)
{
   isDragging=false;
}
*/


}
