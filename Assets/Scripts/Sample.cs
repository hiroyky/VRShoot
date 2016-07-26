using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Sample : MonoBehaviour {

    AndroidBluetoothComn comn;
	// Use this for initialization
	void Start () {
        this.comn = AndroidBluetoothComn.Instance;
        Dictionary<string, string> dict = comn.GetBoundedDevices();
        string key = new List<string>(dict.Keys)[0];
        Debug.Log("Listen: device: " + key + " " + dict[key]);
        try {
            comn.Open(key);
        } catch (Exception e) {
            Debug.Log("Listen Exception" + e.Message);
        }
        Debug.Log("Listen: Opened");
    }
	
	// Update is called once per frame
	void Update () {
        string data = comn.Read();
        data = data.Replace("\n", "");
        Debug.Log("Listen: " + data);
    }

    void OnApplicationQuit() {
        comn.Close();
    }
}
