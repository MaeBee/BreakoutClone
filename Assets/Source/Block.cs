using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {
	public enum PickupTypes {
		WidePaddle, // Makes paddle wider
		StickyPaddle, // Allows a "restart" by keeping the ball stuck to the paddle on contact like on startup
		LaserPaddle, // Allows the player to shoot stuff to break blocks
		FireBall, // Burns through blocks without bounding back
		SplitBall // Clones all balls on the field
	}
	public PickupTypes EmbeddedPickup; // Allows BlockManager to hide a pickup in the block
	
	public int hitsRemaining;
	public int baseHits {
		get;
		private set;
	}
	
	public void BlockInit(int value) {
		baseHits = value;
		hitsRemaining = value;
	}
	
	public int modifyHits(int value) {
		hitsRemaining += value;
		
		if (hitsRemaining <= 0) {
			hitsRemaining = 0;
		}
		if (hitsRemaining == 0) {
			destroyBlock();
		}
		
		return hitsRemaining;
	}

	public void updatePosition(Vector2 value){
		//TODO: add code in to allow for block position to update
	}
	
	public void destroyBlock() {
		gameObject.SetActive(false);
	}
	
	void OnCollisionEnter2D(Collision2D col) {
		modifyHits(-1);
	}
}