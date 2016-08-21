using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using System;
using System.Collections.Generic;

public class WiimoteInputTest {

    public class BluetoothComnMock : IBluetoothComn {
        public int ReadAvailableValue = 1;
        public string ReadValue = "";

        public void Close() {
            throw new NotImplementedException();
        }

        public Dictionary<string, string> GetBoundedDevices() {
            throw new NotImplementedException();
        }

        public string GetData() {
            throw new NotImplementedException();
        }

        public void Open(string deviceAddress) {
        }

        public string Read() {
            return ReadValue;
        }

        public int ReadAvailable() {
            return ReadAvailableValue;
        }

        public void Start() {
            throw new NotImplementedException();
        }

        public void Stop() {
            throw new NotImplementedException();
        }

        public void Write(string data) {
        }
    }

    [Test]
	public void WiimoteStatusのテスト() {
        var mock = new BluetoothComnMock();
        mock.ReadValue = @"{
""A"": 1, ""B"": 1, ""One"": 1, ""Two"": 1, ""Plus"": 1, ""Minus"": 1, 
""Home"": 1, ""Up"": 1, ""Down"": 1, ""Right"": 1, ""Left"": 1, 
""Orientation"": {
    ""Roll"": -10.0, ""Pitch"": -11, ""Yaw"": 12,
    ""AbsoluteRoll"": 10, ""AbsolutePitch"": 11
    }
}";
        mock.ReadValue = mock.ReadValue.Replace("\r\n", "");

        var wiimoteInput = new WiimoteInput(mock);
        var actual = wiimoteInput.WiimoteStatus;
        var expected = new WiimoteStatus();
        expected.A = Button.Pressed;
        expected.B = Button.Pressed;
        expected.Plus = Button.Pressed;
        expected.Minus = Button.Pressed;
        expected.One = Button.Pressed;
        expected.Two = Button.Pressed;
        expected.Up = Button.Pressed;
        expected.Down = Button.Pressed;
        expected.Right = Button.Pressed;
        expected.Left = Button.Pressed;
        expected.Home = Button.Pressed;
        expected.Orientation.Roll = -10;
        expected.Orientation.Pitch = -11;
        expected.Orientation.Yaw = 12;
        expected.Orientation.AbsoluteRoll = 10;
        expected.Orientation.AbsolutePitch = 11;
        Assert.AreEqual(expected, actual);
    }
}
