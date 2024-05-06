using UnityEngine;
public class Explosion : MonoBehaviour
{
    [SerializeField] private float _triggerForce = 0.5f;
    [SerializeField] private float _explosionRadius = 5;
    [SerializeField] private float _explosionForce = 500;
    [SerializeField] private GameObject _particles;

    public bool exploaded = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude >= _triggerForce)
        {
            var surroundingObjects = Physics.OverlapSphere(transform.position, _explosionRadius);

            foreach (var obj in surroundingObjects)
            {
                var rb = obj.GetComponent<Rigidbody>();
                if (rb == null) continue;

                rb.AddExplosionForce(_explosionForce, transform.position, _explosionRadius, 19);
            }

            Instantiate(_particles, transform.position, Quaternion.identity);

            //Destroy(gameObject);

            exploaded = true;
           
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (exploaded == true )
        {

            Debug.Log("playertouch");
        }
    }
}
