using UnityEngine;
using System.Collections.Generic;

public class BlockManager : MonoBehaviour {

	public GameObject BlockPrefab;
	private GameObject temp;

	private int levelWidth, levelHeight;
	private float blockViewportWidth, blockViewportHeight, blockWidth, blockHeight;

	public List<GameObject> BlockList = new List<GameObject>();
	public List<Color> BlockColors = new List<Color>();

	// Use this for initialization
	void Start () {		
		// Block spacing
		// blockWidth = 94;
		// blockHeight = 44;
		
		temp = Instantiate(BlockPrefab, Camera.main.ViewportToWorldPoint(new Vector3( 0, 0, 1)),Quaternion.identity) as GameObject;
		blockWidth = temp.GetComponent<Renderer>().bounds.size.x;
		blockHeight = temp.GetComponent<Renderer>().bounds.size.y;
		temp.transform.position = new Vector3(blockWidth, blockHeight, 1);
		Destroy(temp);
		
		// Turn pixels into viewport floats
		blockViewportWidth = Camera.main.WorldToViewportPoint(new Vector3(blockWidth, 0, 0)).x;
		blockViewportHeight = Camera.main.WorldToViewportPoint(new Vector3(0, blockHeight, 0)).y;
		
		// Calculate number of rows that can fit onto the screen and set amount of columns to generate
		levelWidth = (int)Mathf.Floor(Camera.main.ViewportToWorldPoint(Vector3.one).x / blockWidth) - 2;
		levelHeight = 5;
		
		print(levelWidth);
		print(blockWidth);
		print(blockHeight);
		
		// Additional (basic) colours to the custom ones set in the component
		BlockColors.Add(Color.blue);
		BlockColors.Add(Color.cyan);
		BlockColors.Add(Color.green);
		BlockColors.Add(Color.red);
		BlockColors.Add(Color.magenta);
		BlockColors.Add(Color.yellow);
		
		// Go time.
		generateBlocks ();
	}

	private void generateBlocks(){
		for (int row = 1; row <= levelHeight; row++) {
			for (int column = 1; column <= levelWidth; column++){
				
				// Calculate position for right block
				float posX = 0.5f + (2 * column * blockViewportWidth) - 2 * blockViewportWidth;
				float posY = 4 - (row * blockViewportHeight);
				
				//Create right block and set parent
				temp = Instantiate(BlockPrefab, Camera.main.ViewportToWorldPoint(new Vector3(posX, posY, 1)),Quaternion.identity) as GameObject;
				temp.transform.SetParent(gameObject.transform);
				temp.transform.position = new Vector3(posX, posY, 1);
				
				// Set sprite colour
				temp.GetComponent<SpriteRenderer>().color = BlockColors[Random.Range(0, BlockColors.Count - 1)];
				
				// Set hit points & add to list
				temp.GetComponent<Block>().BlockInit(1);
				BlockList.Add(temp);
				
				// Calculate position for left block
				posX = 0.5f - (2 * column * blockViewportWidth);
				
				// Create left block and set parent
				temp = Instantiate(BlockPrefab, Camera.main.ViewportToWorldPoint(new Vector3( posX, posY, 1)),Quaternion.identity) as GameObject;
				temp.transform.SetParent(gameObject.transform);
				temp.transform.position = new Vector3(posX, posY, 1);
				
				// Set sprite colour
				temp.GetComponent<SpriteRenderer>().color = BlockColors[Random.Range(0, BlockColors.Count - 1)];
				
				// Set hit points & add to list
				temp.GetComponent<Block>().BlockInit(1);
				BlockList.Add(temp);
			}
		}
	}
}