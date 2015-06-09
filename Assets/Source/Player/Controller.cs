using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {
	public Component CollisionBox;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Plane targetPlane = new Plane (Vector3.forward, Vector3.zero);
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		float distance = 0;
		float buffer = GetComponent<Renderer>().bounds.size.x/2;
		if (targetPlane.Raycast (ray, out distance)) {
			Vector3 pos = new Vector3(Mathf.Clamp(ray.GetPoint(distance).x + buffer, Camera.main.ViewportToWorldPoint(Vector3.zero).x + 2*buffer, -Camera.main.ViewportToWorldPoint(Vector3.zero).x) - buffer, transform.position.y, 0);
			transform.position = pos;
		}
	}
}