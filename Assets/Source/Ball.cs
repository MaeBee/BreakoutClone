using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	public GameObject Paddle;
	
	private bool stuckToPaddle;
	private bool colliding;
	private float speed;

	// Use this for initialization
	void Start () {
		stuckToPaddle = true;
		Vector2 pos = new Vector2(Paddle.transform.position.x, Paddle.transform.position.y + 0.33f);
		transform.position = pos;
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
			if (Input.GetButton("Fire1"))
			{
				GetComponent<Rigidbody2D>().velocity = new Vector2(0, 5);
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
		if (!colliding) {
			speed = Mathf.Clamp(GetComponent<Rigidbody2D>().velocity.magnitude, 3, 10);
		}
	}
	
	void OnCollisionEnter2D(Collision2D col) {
		colliding = true;
		// print (speed);
		if ((col.gameObject == Paddle) && (transform.position.y > col.transform.position.y)) {
			float hitFactor = (transform.position.x - col.transform.position.x) / col.gameObject.GetComponent<Renderer>().bounds.size.x;
			Vector2 dir = new Vector2(hitFactor * 5, 1).normalized;
			GetComponent<Rigidbody2D>().velocity = dir * speed;
		}
	}
	
	void OnCollisionExit2D() {
		colliding = false;
	}
}