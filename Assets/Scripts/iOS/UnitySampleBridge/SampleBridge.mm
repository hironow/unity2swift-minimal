// 必ずimportする
#import "unityswift-Swift.h"
 
extern "C" {
    // メソッド名、引数の型・引数の個数は、C#のインタフェース(後述)と合わせる
    void _showMap(float x, float y, float width, float height, char *placeJson) {
        // ここではSwiftのメソッドを呼ぶだけ
        [SampleBridge showMapWithFrame:CGRectMake(x, y, width, height) placeJson:[NSString stringWithUTF8String:placeJson]];
    }

    void _closeMap() {
        [SampleBridge closeMap];
    }
}