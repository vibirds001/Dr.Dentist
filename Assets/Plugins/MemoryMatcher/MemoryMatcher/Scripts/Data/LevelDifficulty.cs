using UnityEngine;
using System;

// Class to represent the basic difficulties in the game
[Serializable]
public class LevelDifficulty
{

	public string LevelName;
	public int Width;
	public int Height;
	public Vector3 CardScale = Vector3.one;
	public float PadTop = 0;

	public LevelDifficulty () {	}
	

}
