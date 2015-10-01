using UnityEngine;
using System.Collections;

public class Base : MonoBehaviour 
{

	void Start() //will add this bases spawn wave so it will be called every time the game manager deems necicary
	{
		GameManager.findGameManager ().spawnUnits += spawnWave;
	}
	void spawnWave()
	{
		//spawn all the grid units
	}
}
