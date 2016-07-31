using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InputManager : MonoBehaviour {

    public GameObject Bullet;
    public Transform Spawn;
    public float Power;

    private IInput input;

	void Start () {
        if (Application.platform == RuntimePlatform.Android) {
            Debug.Log("Listen: InputManager Start");
            WiimoteInput wiimote;
            wiimote = new WiimoteInput(AndroidBluetoothComn.Instance);
            wiimote.Connect("B8:09:8A:D7:53:6C");
            this.input = wiimote;
        } else {
            this.input = new MouseInput();
        }
    }
	
	void Update () {
        if (input.IsTrigger) {
            loadBullet();
        }

        // TODO: 銃の向きをWiiリモコンの角度にする。
        if (input.GetType() == typeof(WiimoteInput)) {
            WiimoteInput wiimote = input as WiimoteInput;
            Vector3 rotation = new Vector3(
                wiimote.WiimoteStatus.Orientation.Pitch,                
                transform.root.rotation.y,
                -wiimote.WiimoteStatus.Orientation.Roll);
            transform.localRotation = Quaternion.Euler(rotation);
        } 
    }

    private GameObject loadBullet() {
        var bullet = GameObject.Instantiate(Bullet, Spawn.position, transform.rotation) as GameObject;
        bullet.GetComponent<Bullet>().Direction = transform.forward.normalized;
        Debug.Log(transform.forward.x + ", " + transform.forward.y + ", " + transform.forward.z);
        return bullet;
    }

    void OnApplicationQuit() {
    }
}
