using UnityEngine;
using System.Collections.Generic;

public class BlockManager : MonoBehaviour {

	public GameObject BlockPrefab;

	public int levelWidth, levelHeight;

	public List<GameObject> BlockList = new List<GameObject>();
	// Use this for initialization
	void Start () {
		//SpriteRenderer blockRenderer = BlockPrefab.GetComponent<SpriteRenderer> ();
		
		levelWidth = Screen.width / (64);
		levelHeight = Screen.height / (64);
		generateBlocks ();
	}
	
	// Update is called once per frame
		void Update () {
	}


	private void generateBlocks() {
		for(int height = 1; height <= levelHeight; height++){
			for(int width = 1; width <= levelWidth; width++){
				Instantiate(BlockPrefab,Camera.main.ScreenToWorldPoint(new Vector3(((int)(Screen.width / 1.1)) - (width * 50),(Screen.height - (height * 50)),10)),Quaternion.identity);
			}
		}
	}
}