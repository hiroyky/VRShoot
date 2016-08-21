using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public class InputManager : MonoBehaviour {

    public GameObject Bullet;
    public Transform Spawn;
    public float Power;

    private GUIStyle style;

    private IInput input;
    System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
    double freq = (double)System.Diagnostics.Stopwatch.Frequency;
    double time = 0;

    void Start() {
        style = new GUIStyle();
        style.fontSize = Screen.height / 4;
        style.normal.textColor = Color.white;

        if (Application.platform == RuntimePlatform.Android) {
            Debug.Log("Listen: InputManager Start");
            WiimoteInput wiimote;
            IBluetoothComn comn = AndroidBluetoothComn.Instance;
            string address = comn.GetBoundedDevices().Keys.ToList()[0];
            string name = comn.GetBoundedDevices().Values.ToList()[0];            
            Debug.Log("Listen: name: " + name + " address: " + address);
            wiimote = new WiimoteInput(comn);
            wiimote.Connect(address);
            this.input = wiimote;
        } else {
            this.input = gameObject.AddComponent<MouseInput>();
        }
    }

    void Update() {
#if false
        if (input.GetType() == typeof(WiimoteInput)) {
            WiimoteInput wiimote = input as WiimoteInput;
            sw.Start();
            wiimote.Update();
            sw.Stop();
            time = (double)sw.ElapsedTicks / freq;
            sw.Reset();
        }
#endif
#if true
        if (input.GetType() == typeof(WiimoteInput)) {
            WiimoteInput wiimote = input as WiimoteInput;
            sw.Start();
            wiimote.Update();
            sw.Stop();
            time = (double)sw.ElapsedTicks / freq;
            sw.Reset();
            WiimoteStatus status = wiimote.WiimoteStatus;
            if (status.B == Button.JustPressed) {
                loadBullet();
            }
            Vector3 rotation = new Vector3(
                (float)Math.Round(status.Orientation.Pitch, 2),
                transform.root.rotation.y,
                (float)Math.Round(-status.Orientation.Roll, 2));
            Quaternion q = Quaternion.Euler(rotation);
            transform.localRotation = q;
        } else {
            if (input.IsTrigger) {
                loadBullet();
            }
        }
#endif
    }

#if false
    void OnGUI() {
        if (input.GetType() == typeof(WiimoteInput)) {
            WiimoteInput wiimote = input as WiimoteInput;
            string str1 = "pitch: " + wiimote.WiimoteStatus.Orientation.Pitch;
            GUI.Label(new Rect(10, 10, 100, 50), str1, style);
            GUI.Label(new Rect(10, Screen.height / 4, 100, 50), time.ToString(), style);
        }
    }
#endif
    private GameObject loadBullet() {
        var bullet = GameObject.Instantiate(Bullet, Spawn.position, transform.rotation) as GameObject;
        bullet.GetComponent<Bullet>().Direction = transform.forward.normalized;
        return bullet;
    }

    void OnApplicationQuit() {
    }
}
