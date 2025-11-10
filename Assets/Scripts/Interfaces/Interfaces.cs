using UnityEngine;
using UnityEngine.EventSystems;
public interface IDragHandler
{
    public void DragObjects();    
}
public interface IDamageOdurability
{
    public void DamageOdurability(int reduce);
}