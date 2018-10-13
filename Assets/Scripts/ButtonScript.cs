using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour {
    public void OnClick() {
        Debug.Log("Close click");

        SampleBridge.CloseMap();
    }
}
