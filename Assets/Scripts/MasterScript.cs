using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterScript : MonoBehaviour {
    public PlaceList placeList;

    public void OnClick() {
        Debug.Log("Open click");

        var json = JsonUtility.ToJson(placeList);

        SampleBridge.ShowMap(0f, 0f, 300f, 300f, json);
    }
}
