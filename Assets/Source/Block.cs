using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {

	public int _hitsRemaining, _baseHits;
	
	public int hitsRemaining {
		get { return _hitsRemaining; }
		set { _hitsRemaining = value; }
	}
	
	public int baseHits {
		get { return _baseHits; }
	}
	
	
	public void BlockInit(int value) {
		_baseHits = value;
		_hitsRemaining = value;
	}
	
	public int modifyHits(int value) {
		_hitsRemaining += value;
		
		if (_hitsRemaining <= 0) {
			_hitsRemaining = 0; // keep from going negative
		}
		
		return _hitsRemaining;
	}

	public void updatePosition(Vector2 value){
		//TODO: add code in to allow for block position to update
	}
	
	public void destroyBlock() {
		SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

		spriteRenderer.enabled = false;
	}
}