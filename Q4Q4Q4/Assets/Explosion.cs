using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Explosion : MonoBehaviour
{
    [SerializeField] private float _triggerForce = 0.5f;
    [SerializeField] private float _explosionRadius = 5;
    [SerializeField] private float _explosionForce = 500;
    [SerializeField] private GameObject _particles;

    public bool exploaded = false;
    public bool player1IsClose;
    public bool player2IsClose;

    public GameObject Wheels1;
    public GameObject Wheels2;
    public AudioSource audioSource;
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

            if (collision.gameObject.tag == "Player")
            {
                player1IsClose = true;
            }

            if (collision.gameObject.tag == "Player2")
            {
                player2IsClose = true;
            }
            

            exploaded = true;
          // Destroy(gameObject);
        }
    }
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }


    private void Update()
    {
      if (exploaded == true && player1IsClose)
        {
            Wheels1.SetActive(false);
            StartCoroutine(WheelPop());
          //  audioSource.time = 2.0f;
          //  audioSource.Play();
        }  
      
      if (exploaded == true && player2IsClose)
        {
            Wheels2.SetActive(false);
            StartCoroutine(WheelPop());
           // audioSource.time = 2.0f;
            //audioSource.Play();
        }
      if (exploaded == true)
        {
            audioSource.Play();
         //   audioSource.time = 2.0f;
          //  Debug.Log("boom");
        }
    }

    IEnumerator WheelPop()
    {
        
        yield return new WaitForSeconds(5);

        Wheels1.SetActive(true);
        player1IsClose = false;
        Wheels2.SetActive(true);
        player2IsClose = false;
       // Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }
}
