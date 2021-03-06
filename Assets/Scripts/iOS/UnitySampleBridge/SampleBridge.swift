import Foundation
import MapKit

// ピン情報のリスト (UnityのJsonUtilityが配列がルートのJSONに対応していないため
struct PlaceList: Codable {
    let places: [Place]
}
 
// ピン情報のモデル
struct Place: Codable {
    let id: Int
    let title: String
    let latitude: Double
    let longitude: Double
}

class SampleBridge : NSObject {
    // @objcをつけて置かないと、Objective-C++から呼び出せないので、必ずつけておく。
    @objc static func showMap(frame: CGRect, placeJson: String) {
        // UnityGetGLView()でUnityで使用しているUIViewを取得できるので、そこにaddSubViewできる。
        guard let view = UnityGetGLView() else {
            return
        }
        let mapView = MKMapView(frame: frame)
        
        // Unityから送られてくるピン情報はJSONなので、パースする。
        let jsonData = placeJson.data(using: .utf8)!
        let decoder = JSONDecoder()
        let placeList = try! decoder.decode(PlaceList.self, from: jsonData)
        
        placeList.places.forEach { // ピンを配置する
            let annotation = MKPointAnnotation()
            annotation.coordinate = CLLocationCoordinate2DMake($0.latitude, $0.longitude)
            annotation.title = $0.title
            mapView.addAnnotation(annotation)
        }

        print("View:\(mapView.description)")
        view.addSubview(mapView)   
    }

    @objc static func closeMap() {
        guard let view = UnityGetGLView() else {
            return
        }

        // remove subview
        for subview in view.subviews {
            print("View:\(subview.description)")
            if subview.isKind(of: MKMapView.self) { 
                subview.removeFromSuperview()
            }
        }
    }

    @objc static func getMessage() -> String {
        guard let view = UnityGetGLView() else {
            return ""
        }
        
        var description = "nothing..."
        
        // get subview description
        for subview in view.subviews {
            if subview.isKind(of: MKMapView.self) {
                description = subview.description
                break
            }
        }
        
        return description
    }

    @objc static func hasMap() -> Bool {
        guard let view = UnityGetGLView() else {
            return false
        }
        
        var b = false
        
        // check subview
        for subview in view.subviews {
            if subview.isKind(of: MKMapView.self) {
                b = true
                break
            }
        }

        return b
    }
}