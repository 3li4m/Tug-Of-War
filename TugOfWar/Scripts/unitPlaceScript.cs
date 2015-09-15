using UnityEngine;
using System.Collections;

public class unitPlaceScript : MonoBehaviour 
{
	public UnitSpot Newspot;
	public GameObject Unit;
	public Camera cam;
	public LayerMask layerMask;
	
	void Update () 
	{
		if (Input.GetKey(KeyCode.Mouse0))
		{
			checkSpot();
		}
	}
	
	void PlaceUnit(UnitSpot spot, GameObject unit)
	{
		Instantiate (unit, spot.transform.position, unit.transform.rotation);
		spot.isTaken = true;
	}
	
	void checkSpot()
	{
		Ray ray = cam.ScreenPointToRay(Input.mousePosition);
		RaycastHit information;
		if (Physics.Raycast (ray, out information ,Mathf.Infinity, layerMask ))
		{
			UnitSpot spot = information.collider.gameObject.GetComponent <UnitSpot>();
			if (spot != null)
			{
				if (spot.isTaken == false)
				{
					PlaceUnit(spot, Unit);
				}
			}
		}
	}
}
