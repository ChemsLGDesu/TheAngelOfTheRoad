using UnityEngine;

[CreateAssetMenu(fileName = "DragObjects", menuName = "Scriptable Objects/DragObjects")]
public class DragObjects : ScriptableObject
{    
    public string ObjectName;
    public GameObject Prefab;
    public Sprite SpriteRenderer;

}
