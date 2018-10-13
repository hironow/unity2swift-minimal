using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class SampleBridge : MonoBehaviour {
    #region Declare external C interface
#if UNITY_IOS && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void _showMap(float x, float y, float width, float height, string placeJson);

    [DllImport("__Internal")]
    private static extern void _closeMap();
#endif
    #endregion

    #region Wrapped methods and properties
    public static void ShowMap(float x, float y, float width, float height, string placeJson) {
#if UNITY_IOS && !UNITY_EDITOR
        _showMap(x, y, width, height, placeJson);
#else
        Debug.Log("ShowMap only work on iOS");
#endif
    }

    public static void CloseMap() {
#if UNITY_IOS && !UNITY_EDITOR
        _closeMap();
#else
        Debug.Log("CloseMap only work on iOS");
#endif
    }
    #endregion

    #region Singleton implementation
    private static SampleBridge _instance;
    public static SampleBridge Instance {
        get {
            if (_instance == null) {
                var obj = new GameObject("SampleBridge");
                _instance = obj.AddComponent<SampleBridge>();
            }
            return _instance;
        }
    }

    void Awake() {
        if (_instance != null) {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }
    #endregion
}