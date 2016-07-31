using UnityEngine;
using System.Collections;

public class EnemyCreator : MonoBehaviour {

    public GameObject EnemyObj;
    public float Interval = 3;

    private float time;
	
	void Update () {
        time += Time.deltaTime;
        if (time >= Interval) {
            time = 0;
            GameObject enemy = Instantiate<GameObject>(EnemyObj);
            enemy.transform.localPosition = new Vector3(
                Random.Range(-20, 20), 0, Random.Range(-20, 20));
        }
	}
}
