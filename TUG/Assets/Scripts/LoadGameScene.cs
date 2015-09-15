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
		Application.LoadLevel("Test Scene");
		unitTeam.team = 1;
	}
	
	public void LoadLevelAsTeam2()
	{
		Application.LoadLevel("Test Scene");
		unitTeam.team = 2;
	}
}
