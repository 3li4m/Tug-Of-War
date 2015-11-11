using UnityEngine;
using System.Collections;

public abstract class BaseUnit : MonoBehaviour // only ever have one of these on a game object
{
	public int team = -1;

	public bool checkTeam(BaseUnit other)
	{
		return(team == other.team);
	}

	
	protected virtual void die()// base death function
	{
		gameObject.SetActive (false);		
	}
}
