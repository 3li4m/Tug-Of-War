using UnityEngine;
using System.Collections;

public class DamagableEntity : MonoBehaviour
{
	public int maxHealth = 10;
	protected int health = 0;
	public delegate void OnUnitDeath();
	protected OnUnitDeath onDie;//if other unit attack causes a particle effect ect make public so they may add their own efects
								//we can use this to play an animation
								//we can even use it to play the fracture effect
	
	private void Start()
	{
		health = maxHealth;//all units will start with max hp 
	}
	public virtual void takeDmg(int dmg)// what things will call to damage this unit
	{
		health -= dmg;
		if (health <= 0)
		{
			die();
		}
	}

	
	protected void die()// base death function
	{
		onDie += deactivateMe;//for now we pass the function with the disable effect
		onDie();
			
	}

	void deactivateMe()
	{
		gameObject.SetActive (false);	
	}


}
