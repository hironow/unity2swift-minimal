using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour {
    public PlaceList placeList;
    public Text message;

    public void OnOpen() {
        Debug.Log("Open click");

        var json = JsonUtility.ToJson(placeList);

        SampleBridge.ShowMap(0f, 0f, 300f, 300f, json);
    }

    public void OnClose() {
        Debug.Log("Close click");

        SampleBridge.CloseMap();
    }

    public void OnMessage() {
        Debug.Log("Message click");

        string response = SampleBridge.GetMessage();
        message.text = response;

        bool result = SampleBridge.HasMap();
        Debug.Log("HasMap: " + result);

        message.text += "\nHasMap: " + result;
    }
}
