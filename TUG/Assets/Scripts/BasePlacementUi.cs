using UnityEngine;
using System.Collections;


public class BasePlacementUi : MonoBehaviour
{
	public GameObject selectedGizmoPrefab;
	public Base myBase;//this creates a double refernce (this references the base base references this remove in future once base grids sizes can be gotten)
	public GameObject[,] displayUnits;
	GameObject selectedGizmoWorld;

	void Start()
	{
		displayUnits = new GameObject[myBase.sizeX,myBase.sizeZ];
		selectedGizmoWorld = Instantiate (selectedGizmoPrefab, Vector3.zero, Quaternion.identity)as GameObject;
		selectedGizmoWorld.SetActive (false);
	}

	public void drawSelected(Vector3 location)
	{
		selectedGizmoWorld.SetActive (true);
		selectedGizmoWorld.transform.position = location;
	}

	public void hideSelectedGizmo()
	{
		selectedGizmoWorld.SetActive (false);
	}
	public void onTileChanged(int x, int y,Vector3 location,GameObject mesh)//call when a unit has been placed
	{
		location = new Vector3(location.x +0.5f, location.y, location.z); //dont know why but the origin is off by 0.5 on only 1 axis
		Destroy(displayUnits[x,y]);
		displayUnits[x,y] = (GameObject)Instantiate(mesh,location,mesh.transform.rotation);
		displayUnits[x,y].GetComponent<Animator>().enabled = false;//stop the base units playing the walk animation
		displayUnits[x,y].GetComponent<UnitPathfinding>().enabled = false;//stops the unit trying to pathfind
		displayUnits[x,y].GetComponent<Collider>().enabled = false;
	}
}
