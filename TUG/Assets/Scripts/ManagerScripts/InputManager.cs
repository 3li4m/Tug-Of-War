using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour 
{
	public GridManager gManager;
	void Update()
	{
		if (Input.GetKeyDown (KeyCode.Mouse0)) 
		{
			gManager.checkCell();
		}
	}
	//tell grid manager when to check the mouse
}
