using UnityEngine;
using System.Collections;
using System.Threading;
using System.Runtime.Serialization;
using System;

public class WiimoteInput {
    private Thread thread;
    private AndroidBluetoothComn comn;

    public WiimoteInput(AndroidBluetoothComn _comn) {
        this.comn = AndroidBluetoothComn.Instance;
    }

    public WiimoteStatus WiimoteStatus { get; private set; }

    public void Run(string address) {
        Debug.Log("Listen: Opening..");
        try {
            comn.Open(address);
        } catch (Exception e) {
            Debug.Log("Listen: exception " + e.Message);
        }
        Debug.Log("Listen: Opened!");
    }

    public void process() {
        if (comn.ReadAvailable() <= 0) {
            return;
        }
        Debug.Log("Listen: READING");
        string data = "";
        try {
            data = comn.Read();
        } catch (Exception e) {
            Debug.Log("Listen: exception " + e.Message);
        }
        Debug.Log("Listen: READ");
        Debug.Log("Listen: " + data.Replace("\n", ""));
        this.WiimoteStatus = JsonUtility.FromJson<WiimoteStatus>(data);
        Debug.Log("Listen: B" + this.WiimoteStatus.B);
    }
}
