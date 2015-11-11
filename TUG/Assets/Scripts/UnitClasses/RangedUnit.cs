using UnityEngine;
using System.Collections;

public class RangedUnit : AttackingCooldownUnit
{
	public GameObject projectile;
	public Transform spawnLocation;
	protected override void fire (DamagableEntity target) //is not fired we need an event to fire this
	{
		GameObject _projectile = Instantiate(projectile,spawnLocation.position,spawnLocation.rotation)as GameObject;
		TargetedProjectile projectileScript = _projectile.GetComponent<TargetedProjectile>();
		projectileScript.target = target;
		projectileScript.myDamage = attackDmg;
	}
}
