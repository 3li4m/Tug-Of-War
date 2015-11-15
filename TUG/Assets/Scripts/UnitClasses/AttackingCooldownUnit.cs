using UnityEngine;
using System.Collections;

public abstract class AttackingCooldownUnit : AttackingUnit
{
	public float weaponCooldown= 1;
	private bool canFire = true;

	protected abstract void fire(DamagableEntity target);

	public override void attack(DamagableEntity target) //clases underneath this can still impiment attack so be weary
	{
		if(canFire)
		{
			//print (this +"fired");
			fire(target);
			StartCoroutine(waitOnCooldown());
		}
	}


	private IEnumerator waitOnCooldown()
	{
		canFire = false;
		yield return new WaitForSeconds(weaponCooldown);
		canFire = true;
	}
}
