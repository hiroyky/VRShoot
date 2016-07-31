using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public float Speed = 5.0f;

    private GameObject target;
    private Rigidbody rb;

    void Start () {
        target = GameObject.FindGameObjectWithTag("MainCamera");
        rb = GetComponent<Rigidbody>();
	}
	
	void Update () {
        Vector3 direction = (target.transform.position - transform.position).normalized;
        rb.AddForce(direction * Speed);
        transform.LookAt(direction);
	}

    void die() {
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Bullet")) {
            die();
        }
    }
}
