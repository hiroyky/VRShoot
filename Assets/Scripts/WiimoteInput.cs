using UnityEngine;
using System.Collections;
using System.Runtime.Serialization;
using System;

public class WiimoteInput : IInput {
    private IBluetoothComn comn;
    private WiimoteStatus status;

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

    public WiimoteStatus WiimoteStatus {
        get {
            if (comn.ReadAvailable() > 0) {
                string data = comn.Read();
                status = JsonUtility.FromJson<WiimoteStatus>(data);
            }
            return status;
        }
    }

    public bool IsTrigger {
        get {
            return WiimoteStatus.B == Button.JustPressed;
        }
    }
}
