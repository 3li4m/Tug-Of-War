using UnityEngine;
using System.Collections;

public class Melee : BaseUnit
{

	public void Start()
	{
		
	}
	protected override void attack (BaseUnit enemy)
	{
		enemy.takeDmg(attackDmg);
	}
	
	private void attackOnCollision(Collision other)
	{
		BaseUnit otherUnit = other.gameObject.GetComponent<BaseUnit>();// stores the base unit of what ever you hit
		if (otherUnit != null)// if the unit stored exists
		{
			if (!checkTeam (otherUnit))//checks if its not on your team
			{
				attack (otherUnit);//passes it to the attack function
			}
		}
	}
	
	private void OnCollisionEnter(Collision other)
	{
		attackOnCollision(other);
	}
	private void OnCollisionStay(Collision other)
	{
		attackOnCollision(other);
	}
}
