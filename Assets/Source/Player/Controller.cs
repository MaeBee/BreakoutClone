using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

	// Use this for initialization
	void Start () {
		EdgeCollider2D theEdge = GetComponent<EdgeCollider2D>();
		Vector2[] points = theEdge.points;
		
		Vector2[] newPoints = new Vector2[6];
		newPoints[0] = new Vector2(-2.6f, 0.2f);
		newPoints[1] = new Vector2(-2f, 0.5f);
		newPoints[2] = new Vector2(-1.4f, 0.7f);
		newPoints[3] = new Vector2(1.4f, 0.7f);
		newPoints[4] = new Vector2(2f, 0.5f);
		newPoints[5] = new Vector2(2.6f, 0.2f);
		
		for (int i = 0; i <= 5; i++) {
			points[i] = newPoints[i];
		}
		
		theEdge.points = points;
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