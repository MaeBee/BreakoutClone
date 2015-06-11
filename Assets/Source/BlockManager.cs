using UnityEngine;
using System.Collections.Generic;

public class BlockManager : MonoBehaviour {

	public GameObject BlockPrefab, temp;

	public int levelWidth, levelHeight, blockWidth, blockHeight;

	public List<GameObject> BlockList = new List<GameObject>();
	public List<Sprite> BlockSprites = new List<Sprite>();

	// Use this for initialization
	void Start () {		
		//blocks are 149 x 63

		blockWidth = 149;
		blockHeight = 63;

		levelWidth = Screen.width / 149;
		levelHeight = 5;

		generateBlocks ();
	}

	private void generateBlocks(){
		for (int height = 1; height <= levelHeight; height++) {
			for(int width = 1; width <= levelWidth; width++){

				float xPos = ((float)width +1.5f) / 100;
				float yPos = ((float)height -14.8f)/ 100;


				temp = Instantiate(BlockPrefab, Camera.main.ViewportToWorldPoint(new Vector3( xPos * 9, -yPos * 7, 10)),Quaternion.identity) as GameObject;
				temp.transform.SetParent(gameObject.transform);
				
				SpriteRenderer tempRenderer = temp.GetComponent<SpriteRenderer>();
				tempRenderer.sprite = BlockSprites[Random.Range(0,5)];
			}
		}
	}
}