using UnityEngine;
using System;

public class Troop : MonoBehaviour
{
    private float movementSpeed = 5.0f;
    private float gatheringSpeed = 1.0f;
    private float rotationSpeed = 1f;
    private float baseSpeed = 50.0f;

    public float shootingRange = 8.0f;
    public float shootingInterval = 0.25f;
    private float shootingTimer;
    private bool isShooting;
    public float startShootingDelay = 1f;

    private bool targetIsOre;

    public TroopData troopData;

    private UnityEngine.AI.NavMeshAgent navMeshAgent;
    internal Vector3 targetPosition;

    public event Action onSelect;
    public event Action onUnselect;
    public event Action onShoot;


    void Awake()
    {
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    private void Start()
    {
        if (troopData != null)
        {
            movementSpeed = troopData.MovementSpeed;
            gatheringSpeed = troopData.GatheringSpeed;

        
            navMeshAgent.speed = movementSpeed*baseSpeed;
        }
        else
        {
            Debug.LogError("TroopData not assigned in " + gameObject.name);
        }

        navMeshAgent.updateRotation = false;
    }

    public void SelectTroop()
    {
        onSelect?.Invoke();
    }

    public void UnselectTroop()
    {
        onUnselect?.Invoke();
    }

    void StopMoving()
    {
        navMeshAgent.isStopped = true;
    }

   public void MoveTo(Vector3 target, GameObject targetObject)
    {
        targetIsOre = targetObject != null && targetObject.CompareTag("Ore");
        targetPosition = target;

        navMeshAgent.SetDestination(targetPosition);
        navMeshAgent.isStopped = false;
    }

    private bool IsInShootingRange()
    {
        return Vector3.Distance(transform.position, targetPosition) <= shootingRange;
    }

    void Shoot()
    {
        if (!isShooting)
        {
            isShooting = true;
            shootingTimer = -startShootingDelay;
        }

        shootingTimer += Time.deltaTime;
        if (shootingTimer >= shootingInterval / gatheringSpeed)
        {
            onShoot?.Invoke();
            shootingTimer = 0f;
        }
    }

    private void Update()
    {
        if (targetIsOre && IsInShootingRange())
        {
            StopMoving();
            Shoot();
        }

         RotateTowardsMovementDirection();
    }



    private void RotateTowardsMovementDirection()
    {
        Vector3 movementDirection = navMeshAgent.velocity.normalized;
        if (movementDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movementDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }
    }
}