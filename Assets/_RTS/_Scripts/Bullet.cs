using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float bulletSpeed = 10f;
    public float lifespan = 3f;

    private void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;
    }

    void Update()
    {
        lifespan -= Time.deltaTime;

        if (lifespan <=0)
            Destroy(gameObject);
    }


    private void OnTriggerEnter(Collider other)
    {
        OreSphere oreSphere = other.GetComponent<OreSphere>();
        if (oreSphere != null)
        {
            int gathered = oreSphere.GatherResource();
            GameManager.Instance.GatherResource(gathered);
            Destroy(gameObject);
        }
    }
}
