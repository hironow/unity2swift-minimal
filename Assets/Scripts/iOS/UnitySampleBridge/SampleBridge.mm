// 必ずimportする
#import "unityswift-Swift.h"
 
extern "C" {
    // メソッド名、引数の型・引数の個数は、C#のインタフェース(後述)と合わせる
    void _showMap(float x, float y, float width, float height, const char *placeJson) {
        // ここではSwiftのメソッドを呼ぶだけ
        [SampleBridge showMapWithFrame:CGRectMake(x, y, width, height) placeJson:[NSString stringWithUTF8String:placeJson]];
    }

    void _closeMap() {
        [SampleBridge closeMap];
    }

    const char* _getMessage() {
        // 文字列はC側でmallocして返却する必要があるので注意
        const char *str = [SampleBridge getMessage].UTF8String;
        char* retStr = (char*)malloc(strlen(str) + 1);
        strcpy(retStr, str);
        retStr[strlen(str)] = '\0';
        return retStr;
    }

    bool _hasMap() {
        return [SampleBridge hasMap];
    }
}