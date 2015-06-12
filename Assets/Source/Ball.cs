using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	public GameObject Paddle;
	
	private bool stuckToPaddle;

	// Use this for initialization
	void Start () {
		stuckToPaddle = true;
	}
	
	// Update is called once per frame
	void Update () {
		float buffer = GetComponent<Renderer>().bounds.size.x/2;
		if (stuckToPaddle) {
			Plane targetPlane = new Plane (Vector3.forward, Vector3.zero);
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			float distance = 0;
			float paddleBuffer = Paddle.GetComponent<Renderer>().bounds.size.x/2;
			if (targetPlane.Raycast (ray, out distance)) {
				Vector3 pos = new Vector3(Mathf.Clamp(ray.GetPoint(distance).x + paddleBuffer, Camera.main.ViewportToWorldPoint(Vector3.zero).x + 2*paddleBuffer, -Camera.main.ViewportToWorldPoint(Vector3.zero).x) - paddleBuffer, transform.position.y, 0);
				transform.position = pos;
			}
			if (Input.GetMouseButtonDown(0))
			{
				GetComponent<Rigidbody2D>().velocity = new Vector2(3, 3);
				stuckToPaddle = false;
			}
		}
		if (transform.position.x >= -Camera.main.ViewportToWorldPoint(Vector3.zero).x - buffer) {
			Vector2 vel = new Vector2(-GetComponent<Rigidbody2D>().velocity.x, GetComponent<Rigidbody2D>().velocity.y);
			GetComponent<Rigidbody2D>().velocity = vel;
		}
		if (transform.position.x <= Camera.main.ViewportToWorldPoint(Vector3.zero).x + 2*buffer) {
			Vector2 vel = new Vector2(-GetComponent<Rigidbody2D>().velocity.x, GetComponent<Rigidbody2D>().velocity.y);
			GetComponent<Rigidbody2D>().velocity = vel;
		}
	}
}