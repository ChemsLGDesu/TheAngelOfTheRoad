using UnityEngine;
using UnityEngine.EventSystems;


public class DragableObjects : MonoBehaviour,IPointerDownHandler,IPointerUpHandler,IDragHandler
{
    [SerializeField] private bool isDragging =false;
  
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        isDragging = true;
    }

    public void DragObject(PointerEventData eventData)
    {
        if (isDragging)
        {
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(eventData.position);
            worldPos.z = 0;
            transform.position = worldPos;  
        }
        
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        isDragging=false;
    }
    
    
}
