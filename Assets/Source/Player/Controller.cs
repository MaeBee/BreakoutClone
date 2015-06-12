using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

	// Use this for initialization
	void Start () {
		float level = Camera.main.ViewportToWorldPoint(new Vector3(0, 0.1f, 0)).y;
		Vector2 pos = new Vector2(transform.position.x, level);
		transform.position = pos;
	}
	
	// Update is called once per frame
	void Update () {
		Plane targetPlane = new Plane (Vector3.forward, Vector3.zero);
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		float distance = 0;
		float buffer = GetComponent<Renderer>().bounds.size.x/2;
		if (targetPlane.Raycast (ray, out distance)) {
			Vector2 pos = new Vector2(Mathf.Clamp(ray.GetPoint(distance).x + buffer, Camera.main.ViewportToWorldPoint(Vector3.zero).x + 2*buffer, -Camera.main.ViewportToWorldPoint(Vector3.zero).x) - buffer, transform.position.y);
			transform.position = pos;
		}
	}
}