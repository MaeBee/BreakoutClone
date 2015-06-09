using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//Vector3 pos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		/*if (hit.collider != null) {
			if (hit.collider.gameObject == Background)
			{
				transform.position = hit.point;
			}
		}*/
		Plane targetPlane = new Plane (Vector3.forward, Vector3.zero);
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		float distance = 0;
		if (targetPlane.Raycast (ray, out distance)) {
			Vector3 pos = new Vector3(ray.GetPoint(distance).x, transform.position.y, 0);
			transform.position = pos;
		}
	}
}
