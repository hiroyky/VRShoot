using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AndroidBluetoothComn : IBluetoothComn {
    private static readonly string JAVA_CLASS_NAME = "com.hiroyky.bluetoothcomn.BluetoothComn";
    private AndroidJavaObject plugin;

    private static AndroidBluetoothComn instance = null;

    public static AndroidBluetoothComn Instance {
        get {
            if (instance == null) {
                instance = new AndroidBluetoothComn();
            }
            return instance;
        }
    }

    private AndroidBluetoothComn() {
        plugin = new AndroidJavaClass(JAVA_CLASS_NAME).CallStatic<AndroidJavaObject>("getInstance");
    }

    public Dictionary<string, string> GetBoundedDevices() {
        AndroidJavaObject deviceJavaList = plugin.Call<AndroidJavaObject>("getBoundedDevices");
        int size = deviceJavaList.Call<int>("size");
        if (size == 0) {
            return new Dictionary<string, string>();
        }
        Dictionary<string, string> deviceDict = new Dictionary<string, string>();
        for (int i = 0; i < size; ++i) {
            AndroidJavaObject device = deviceJavaList.Call<AndroidJavaObject>("get", i);
            string deviceName = device.Call<string>("getName");
            string deviceAddress = device.Call<string>("getAddress");
            deviceDict.Add(deviceAddress, deviceName);
        }
        return deviceDict;
    }

    public void Open(string deviceAddress) {
        plugin.Call("connect", deviceAddress);
    }

    public void Close() {
        plugin.Call("close");
    }

    public void Write(string data) {
        plugin.Call("write", data);
    }

    public string Read() {
        return plugin.Call<string>("read");
    }

    public int ReadAvailable() {
        return plugin.Call<int>("readAvailable");
    }
}
