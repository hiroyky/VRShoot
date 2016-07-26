using System.Collections;
using System.Collections.Generic;

public interface IBluetoothComn {
    Dictionary<string, string> GetBoundedDevices();
    void Open(string deviceAddress);
    void Close();
    void Write(string data);
    string Read();
}
