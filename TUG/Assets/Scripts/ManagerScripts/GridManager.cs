using UnityEngine;
using System.Collections;

public class GridManager : MonoBehaviour 
{
	//tell the base when a cell is clicked and what cell
	//tell the base the world coords of the cells
	public Collider myGrid;
	public Base myBase;
	public void checkCell()//raycast and find if we are hitting a cell
	{
		Ray myRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hitInfo;
		if(myGrid.Raycast(myRay,out hitInfo,Mathf.Infinity))
		{
			if(hitInfo.collider == myGrid)//if we hit the correct grid
			{
				Vector3 localCoord =  hitInfo.point -myGrid.transform.position;
				myBase.addUnit(getRatioFormLocal(localCoord));
				//send to a ui here(tip using the gitinfo.point and placing a gizmo or such will place it at the mouses click area to allign to grid simpily round)
			}
		}
	}


	Vector2 getRatioFormLocal(Vector3 local)
	{
		float localX = local.x;
		float localZ = local.z;

		//offet to the bottom left

		localX += myGrid.bounds.extents.x;
		localZ += myGrid.bounds.extents.z;

		localX = localX / myGrid.bounds.size.x;
		localZ = localZ / myGrid.bounds.size.z;
		return new Vector3 (localX, localZ);

	}


	public Vector3 worldAtRatio(Vector2 ratio)
	{
		ratio.x = ratio.x * myGrid.bounds.size.x;
		ratio.y = ratio.y * myGrid.bounds.size.z;

		ratio.x -= myGrid.bounds.extents.x;
		ratio.y -= myGrid.bounds.extents.z;
		return new Vector3 (ratio.x, myGrid.transform.position.y, ratio.y);
	}


 





}
