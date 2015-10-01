using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour //ALL static events will be contained within this script aditonaly the win codions should be handled here
{
	public delegate void GameManagerEventVoid();
	public GameManagerEventVoid spawnUnits;

	private bool gameRunning = true;//when this is turned off the bases will stop spawning

	public float unitSpawnRate;//inspector variable
	private float unitSpawnRateLocal;//real variable

	private void Start()
	{
		unitSpawnRateLocal = unitSpawnRate;//so the rate is a constant
		StartCoroutine (spawnWaves());
	}

	private IEnumerator spawnWaves()
	{
		while (gameRunning == true) 
		{
			spawnUnits();
			yield return new WaitForSeconds(unitSpawnRateLocal);
		}
	}

	public static GameManager findGameManager()//so we can acces the game manager
	{
		return GameObject.FindObjectOfType<GameManager> ();
	}
}
