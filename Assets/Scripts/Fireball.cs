using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour {
    public Vector3 Direction { get; set; }
    public float Range { get; set; }
    public int Damage { get; set; }

    Vector3 SpawnPosition;

    private void Start()
    {
        Range = 20f;
        Damage = 4;
        SpawnPosition = transform.position;
        GetComponent<Rigidbody>().AddForce(Direction * 50f);
    }

    private void Update()
    {
        if (Vector3.Distance(SpawnPosition, transform.position) >= Range)
        {
            Extinguish();
        }
    }

    void Extinguish()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            collision.transform.GetComponent<IEnemy>().TakeDamage(Damage);
        }
        Extinguish();
    }
}
