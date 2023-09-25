using UnityEngine;

[CreateAssetMenu(fileName = "New Troop Data", menuName = "TroopData")]
public class TroopData : ScriptableObject
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float gatheringSpeed;

    public float MovementSpeed { get { return movementSpeed; } }
    public float GatheringSpeed { get { return gatheringSpeed; } }
}
