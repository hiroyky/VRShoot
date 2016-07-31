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
        if (transform.position.x < -25 || transform.position.x > 25) {
            return true;
        }
        if (transform.position.y < -25 || transform.position.y > 25) {
            return true;
        }
        if (transform.position.z < -25 || transform.position.z > 25) {
            return true;
        }
        return false;
    }

    void OnCollisionEnter(Collision other) {
        Destroy(gameObject);
    }
}
