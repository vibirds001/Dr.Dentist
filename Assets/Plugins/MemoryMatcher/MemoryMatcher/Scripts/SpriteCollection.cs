using UnityEngine;


/* Sprites Collection
 *  Manages sprite card faces.
 *  To add more sprites,  simply append them to the FaceSprites
 *  array in the editor. Script is located on the __GameLogic scene object.
 * 
 *  Make sure your sprites fit on the cards!
 * 
 */ 


public class SpriteCollection : MonoBehaviour 
{

	public Sprite[] FaceSprites; // Setup in the editor; collection of sprites to grab from and apply to the face of a card



	public int count
	{
		get
		{
			return FaceSprites.Length;
		}
	}


	// Fetch an array of random sprites of count size; does not allow dupes
	// Count may be a value from 1 to the number of sprites in the FaceSprites array
	public Sprite[] GetRandomSprites(int count)
	{
		if(count < 1 || count > FaceSprites.Length) return null; // Requesting out of bounds counts results in no array returned


		Sprite[] selections = FaceSprites.Clone() as Sprite[]; // We don't want to modify the original array at all, so clone it

		if(count == FaceSprites.Length) return selections; // All the sprites were requested. 

		Sprite[] returnSprites = new Sprite[count]; // Array to hold the randomly selected sprites

		int maxCount = selections.Length-1; // maxCount will be used to indicate the last element of our selectable range
											// once we get a sprite, we move the one at max count into the location of random
											// selected index, and reduce by maxCount by 1. No need to remove array elements or
											// create a new array

		while(count > 0)
		{
			int ndx = Random.Range(0, maxCount);

			returnSprites[count-1] = selections[ndx];
			selections[ndx] = selections[maxCount];
			selections[maxCount] = null;

			maxCount -= 1;
			count -=1;
		}

		return returnSprites;


	}


	// Use this for initialization
	void Start () {
	
	}
	
}
