using UnityEngine;
public class AimToMousePosition : MonoBehaviour 
{
	[SerializeField] Transform controlTransform;
	Camera _cacheMainCamera;
	void Update() {
		if(_cacheMainCamera == null) {
			_cacheMainCamera = Camera.main;
		}
		var mousePos = _cacheMainCamera.ScreenToWorldPoint(Input.mousePosition);
		mousePos.z = controlTransform.position.z;
		var direction = mousePos - controlTransform.position;
		controlTransform.up = direction;
	}
}
