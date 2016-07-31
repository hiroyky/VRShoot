using UnityEngine;
using System.Collections;
using System;

public class MouseInput : MonoBehaviour, IInput {
    public bool IsTrigger {
        get {
            return Input.GetMouseButtonDown(1);
        }
    }
}
