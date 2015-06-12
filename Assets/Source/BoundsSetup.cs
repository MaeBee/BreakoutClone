using UnityEngine;
using System.Collections;

public class BoundsSetup : MonoBehaviour {
	public enum BoundType { LeftWall, RightWall, Roof, Floor }
	public BoundType boundType;

	private Vector2 pos;
	
	// Use this for initialization
	void Start () {
		switch (boundType) {
			case BoundType.LeftWall:
				pos = new Vector2(Camera.main.ViewportToWorldPoint(Vector3.zero).x, transform.position.y);
				transform.position = pos;
				break;
			case BoundType.RightWall:
				pos = new Vector2(Camera.main.ViewportToWorldPoint(Vector3.right).x, transform.position.y);
				transform.position = pos;
				break;
			case BoundType.Roof:
				pos = new Vector2(transform.position.x, Camera.main.ViewportToWorldPoint(Vector3.up).y * 2 - 10);
				print(Camera.main.ViewportToWorldPoint(Vector3.up).y);
				transform.position = pos;
				break;
			case BoundType.Floor:
				pos = new Vector2(transform.position.x, Camera.main.ViewportToWorldPoint(Vector3.zero).y);
				transform.position = pos;
				break;
			default:
				break;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
