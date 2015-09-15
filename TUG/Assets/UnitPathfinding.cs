using UnityEngine;
using System.Collections;

public class UnitPathfinding : MonoBehaviour // NEEDS TO BE NETWORK BEHAVIOUR
{
	private NavMeshAgent myNavmeshAgent;
	public Transform destanation;
	
	private BaseUnit myBase;
	public BaseUnit agrodUnit;
	public float walkRange;
	
	void Start()
	{
		myBase = GetComponent<BaseUnit>();
		myNavmeshAgent = GetComponent<NavMeshAgent>();
	}
	
	void Update () 
	{
		move();
	}
	
	void move()
	{
		if (agrodUnit != null && agrodUnit.gameObject.activeSelf)// check if the agroed unit exists and is alive
		{
			if (Vector3.Distance (transform.position, agrodUnit.transform.position) > walkRange)// check if we are close enough based of wallk range
			{
				myNavmeshAgent.SetDestination (agrodUnit.transform.position); // move to the target
			}
			else 
			{
				myNavmeshAgent.Stop();
			}
		}
		else // if were not attacking anything 
		{
			myNavmeshAgent.SetDestination(destanation.position);// move to the destination
		}
	}
	
	void changeTarget(Collider other)
	{
		BaseUnit newAgro = other.gameObject.GetComponent <BaseUnit>();//Store the baseUnit on other
		if (newAgro != null)// check if its null
		{
			if (agrodUnit == null)// check if im attacking something
			{
				if (!myBase.checkTeam (newAgro)); // check if its on the enemy team
				{
					agrodUnit = newAgro; // store agroed unit into the new agro
				}
			}
		}

	}
	
	void OnTriggerEnter(Collider other)
	{
		changeTarget(other);
	}
	
	void OnTriggerStay(Collider other)
	{
		changeTarget(other);
	}
	
}
