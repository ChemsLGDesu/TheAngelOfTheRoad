using UnityEngine;
using UnityEngine.EventSystems;
public interface IDragHandler
{
    public void DragObject(PointerEventData eventData);
}