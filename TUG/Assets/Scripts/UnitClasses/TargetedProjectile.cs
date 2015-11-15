using UnityEngine;
using System.Collections;

public class TargetedProjectile : MeleUnit
{
	public DamagableEntity target;
	public float speed;
	[HideInInspector]
	public int myDamage;
	public float lifeTime =3f; //do we set it on the ranged units or on the porjectile prefab?
	public float detonationRange =0.5f;
	void Start()
	{
		StartCoroutine(countDown());
	}

	void Update() //shit fix later
	{
		if(target == null)
			die();

		if(Vector3.Distance(target.transform.position, transform.position) < detonationRange)
		{
			fire(target);
			die ();
		}

		transform.position +=(target.transform.position - transform.position).normalized *speed;
	}

	IEnumerator countDown()
	{
		yield return new WaitForSeconds(lifeTime);
		die ();
	}
}
