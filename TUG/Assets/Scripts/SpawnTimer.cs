using UnityEngine;
using System.Collections;

public class SpawnTimer : MonoBehaviour 
{
	public float timer;
	public SpawnUnit unit;
	public Transform spot2;
	public Transform spot3;
	public BaseUnit unitTeam;
	
	
	
	void Start () 
	{
		unit = GetComponent<SpawnUnit>();
	}
	
	
	void Update () 
	{
		timer -= Time.deltaTime;
		
		
		if (timer <= 0)
		{
			if (unitTeam.team == 1)
			{
				Instantiate (unit.unit, spot2.transform.position, spot2.transform.rotation); // spawns unit onto quad infront of team 1s base 
				timer = 10;
			}
			else if (unitTeam.team == 2) 
			{
				Instantiate (unit.unit, spot3.transform.position, spot3.transform.rotation); // spawns unit onto quad infront of team 2s base 
				timer = 10;
			}
		}
	}
}
