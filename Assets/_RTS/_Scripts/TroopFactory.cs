using UnityEngine;

public class TroopFactory : MonoBehaviour
{
    public GameObject troopType1Prefab;
    public GameObject troopType2Prefab;
    public int troopCost = 10;
    public float spawnRadius = 5.0f;
    public Transform spawnTroopPosition;

    public void BuyTroopType1()
    {
        Instantiate(troopType1Prefab, GetSpawnPosition(), Quaternion.identity);
    }

    public void BuyTroopType2()
    {
        Instantiate(troopType2Prefab, GetSpawnPosition(), Quaternion.identity);
    }

    private Vector3 GetSpawnPosition()
    {
        return spawnTroopPosition.position +Random.insideUnitSphere * spawnRadius;
    }
}
