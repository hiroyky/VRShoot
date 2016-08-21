using UnityEngine;
using System.Collections;
using System.Runtime.Serialization;
using System;
using System.Threading;

public class WiimoteInput : IInput {
    private IBluetoothComn comn;
    private WiimoteStatus status;
    private bool isTrigger = false;
    System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
    public double time;

    public WiimoteInput(IBluetoothComn _comn) {
        this.comn = _comn;
    }

    ~WiimoteInput() {
        comn.Close();
    }

    public void Connect(string address) {
        Debug.Log("Listen: Opening..");
        try {
            comn.Open(address);
        } catch (Exception e) {
            Debug.Log("Listen: exception " + e.Message);
        }
        Debug.Log("Listen: Opened!");
    }

    public void Update() {
        if (comn.ReadAvailable() > 0) {
            string data = comn.Read();
            string[] list = data.Split(',');
            status.B = (Button)int.Parse(list[0]);
            status.Orientation.Pitch = float.Parse(list[1]);
            status.Orientation.Roll = float.Parse(list[2]);
        }
        
    }

    public WiimoteStatus WiimoteStatus {
        get {
            return status;
        }
    }

    public bool IsTrigger {
        get {
            return WiimoteStatus.B == Button.JustPressed;
        }
    }
}
