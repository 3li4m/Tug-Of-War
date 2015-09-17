using UnityEngine;
using System.Collections;

public class LoadGameScene : MonoBehaviour 
{
	public GameObject button1;
	public GameObject button2;
	public BaseUnit unitTeam;

	void Start () 
	{
	
	}
	
	
	public void LoadLevelAsTeam1() 
	{
		// sets players team to 1 if button one is pressed
		Application.LoadLevel("Test Scene");
		unitTeam.team = 1;
	}
	
	public void LoadLevelAsTeam2()
	{
		// sets players team to 2 if button is pressed
		Application.LoadLevel("Test Scene");
		unitTeam.team = 2;
	}
}
