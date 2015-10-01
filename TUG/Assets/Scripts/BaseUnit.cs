using UnityEngine;
using System.Collections;

public abstract class BaseUnit : MonoBehaviour // only ever have one of these on a game object
{
	public int team = -1;
	//public int health = 10;
	public int attackDmg = 2;


	protected abstract void attack(DamagableEntity enemy);// all classes that inherit from this MUST IMPLEMENT THIS using overide
	
	public bool checkTeam(BaseUnit other)
	{
		return(team == other.team);
	}
	
	/*public virtual void takeDmg(int dmg)// what things will call to damage this unit
	{
		health -= dmg;
		if (health <= 0)
		{
			die();
		}
	}
	/*
	
	protected virtual void die()// base death function
	{
		gameObject.SetActive (false);		
	}
	*/
}
