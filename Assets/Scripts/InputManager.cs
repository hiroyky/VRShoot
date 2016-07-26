using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InputManager : MonoBehaviour {

    WiimoteInput wiimote;

	void Start () {
        Debug.Log("Listen: InputManager Start");
        wiimote = new WiimoteInput(null);
        wiimote.Run("B8:09:8A:D7:53:6C");        
    }
	
	void Update () {
        wiimote.process();
        WiimoteStatus status = wiimote.WiimoteStatus;
        if (status.B == Button.JustPressed) {
            Debug.Log("Listen: Fire!");
        }
	}

    void OnApplicationQuit() {
        AndroidBluetoothComn.Instance.Close();
    }
}
