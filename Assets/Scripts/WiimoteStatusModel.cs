using System;
using System.Collections;

public enum Button {
    Released, Pressed, JustPressed
}

[Serializable]
public struct WiimoteOrientation {
    public float Roll;
    public float Pitch;
    public float Yaw;
    public float AbsoluteRoll;
    public float AbsolutePitch;
}

[Serializable]
public struct WiimoteStatus {    
    public Button A;
    public Button B;
    public Button One;
    public Button Two;
    public Button Plus;
    public Button Minus;
    public Button Home;
    public Button Up;
    public Button Down;
    public Button Right;
    public Button Left;
    public WiimoteOrientation Orientation;
}
