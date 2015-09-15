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
				Instantiate (unit.unit, spot2.transform.position, spot2.transform.rotation);
				timer = 50;
			}
			else if (unitTeam.team == 2)
			{
				Instantiate (unit.unit, spot3.transform.position, spot3.transform.rotation);
				timer = 50;
			}
		}
	}
}
