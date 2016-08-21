using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public Vector3 Direction;
    public float Speed = 50;

    private Rigidbody rigidBody;

    void Start() {
        rigidBody = GetComponent<Rigidbody>();
    }

    void Update() {
        rigidBody.velocity = Direction * Speed;
        if (isOutOfArea()) {
            Destroy(this.gameObject);
        }
    }

    bool isOutOfArea() {
        if (transform.position.x < -35 || transform.position.x > 45) {
            return true;
        }
        if (transform.position.y < -35 || transform.position.y > 45) {
            return true;
        }
        if (transform.position.z < -35 || transform.position.z > 45) {
            return true;
        }
        return false;
    }

    void OnCollisionEnter(Collision other) {
        if (!other.gameObject.CompareTag("Player")) {
            Debug.Log("collision " + other.gameObject.name);
            Destroy(gameObject);
        }        
    }
}
