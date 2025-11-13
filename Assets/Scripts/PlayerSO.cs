using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSO", menuName = "Scriptable Objects/PlayerSO")]
public class PlayerSO : ScriptableObject
{
    public string Name;
    public float DetectSize = 20f;
    public float Distance = 0.1f;
}
