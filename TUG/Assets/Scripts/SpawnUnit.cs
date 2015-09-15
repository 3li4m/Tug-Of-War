using UnityEngine;
using System.Collections;

public class SpawnUnit : MonoBehaviour 
{
	public GameObject unit;
	public Camera cam;
	
	void Start()
	{
		
	}
	
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.Mouse0))
		{
			checkSpot();
		}
	}
	
	void placeUnit (UnitSpot spot, GameObject unit)
	{
		Instantiate (unit, spot.transform.position, spot.transform.rotation);
		spot.isTaken = true;
		GetComponent<UnitPathfinding>().enabled = false;
	}
	
	void checkSpot()
	{
		Ray ray = cam.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit , Mathf.Infinity))
		{
			UnitSpot spot = hit.collider.gameObject.GetComponent<UnitSpot>();
			if (spot != null)
			{
				if (spot.isTaken == false)
				{
					placeUnit(spot, unit);
				}
			}
		}
		
	}
}
