using UnityEngine;
using System.Collections;

public class BoundsSetup : MonoBehaviour {
	public enum BoundType : int { LeftWall, RightWall, Roof, Floor }
	public BoundType boundType;

	private Vector2 pos;
	
	// Use this for initialization
	void Start () {
		// int boundToMove = boundType
		switch (boundType) {
			case BoundType.LeftWall:
				pos = new Vector2(Camera.main.ViewportToWorldPoint(Vector3.zero).x, transform.position.y);
				transform.position = pos;
				break;
			case BoundType.RightWall:
				pos = new Vector2(-Camera.main.ViewportToWorldPoint(Vector3.zero).x, transform.position.y);
				transform.position = pos;
				break;
			case BoundType.Roof:
				pos = new Vector2(transform.position.x, -Camera.main.ViewportToWorldPoint(Vector3.zero).y);
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
