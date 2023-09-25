using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroopGraphics : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;

    private float bulletSpeed = 10f;

    public GameObject selection;

    void OnEnable()
    {
        Troop troop = gameObject.GetComponent<Troop>();

        if (troop)
        {
            troop.onSelect += SelectUnit;
            troop.onUnselect += UnselectUnit;

            troop.onShoot += Shoot;
        }
    }

    
    void OnDisable()
    {
        Troop troop = gameObject.GetComponent<Troop>();

        if (troop)
        {
            troop.onSelect -= SelectUnit;
            troop.onUnselect -= UnselectUnit;

            troop.onShoot -= Shoot;
        }
    }

    void Shoot()
    {
        Troop troop = gameObject.GetComponent<Troop>();
        if (!troop) return;

        Vector3 directionToTarget = troop.targetPosition - bulletSpawnPoint.position;
        
        directionToTarget.Normalize();

        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.LookRotation(directionToTarget));
        
        Bullet bulletScript = bullet.GetComponent<Bullet>();

        bullet.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;
    }
   

    void SelectUnit()
    {
        selection.SetActive(true);
    }

    void UnselectUnit()
    {
        selection.SetActive(false);
    }
}
