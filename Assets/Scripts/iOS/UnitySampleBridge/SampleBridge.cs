using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class SampleBridge : MonoBehaviour
{
    public PlaceList placeList; // マップに表示するピンの情報

    // Objective-C++に記述した関数をC#クラスにも記載することで、C#から呼び出し可能になる。
    // 必ず[DllImport("__Internal")]を設定しておかないと、Objective-C++の関数と紐づかない
    // また、今回IOSのネイティブコードであるため、IOS以外(エディタ含む)はエラーとなってしまうため、#ifで実行させないようにする
#if UNITY_IOS && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void showMap(float x, float y, float width, float height, string placeJson);
#endif

    void Start()
    {
        // JsonUtilityを使ってピン情報をJSONに変換
        var json = JsonUtility.ToJson(placeList);

        // 上記のインタフェース経由でネイティブコードを呼び出すが、こちらもIOS専用としてある
#if UNITY_IOS && !UNITY_EDITOR
        showMap(0f, 0f, 500f, 500f, json);
#endif
    }
}