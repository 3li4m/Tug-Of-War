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
		if (myGrid.Raycast (myRay, out hitInfo, Mathf.Infinity)) {
			if (hitInfo.collider == myGrid) {//if we hit the correct grid
				Vector3 localCoord = hitInfo.point - myGrid.transform.position;
				myBase.addUnit(getRatioFormLocal(localCoord));
				//print(getRatioFormLocal(localCoord).ToString());

			}
		} 

	}

	Vector2 getRatioFormLocal(Vector3 local)
	{
		float localX = local.x + 0.5f;
		float localZ = local.z + 0.5f;

		//offet to the bottom left

		localX += myGrid.bounds.extents.x;
		localZ += myGrid.bounds.extents.z;

		localX = localX / myGrid.bounds.size.x;
		localZ = localZ / myGrid.bounds.size.z;


		return new Vector2 (localX, localZ);

	}


	public Vector3 worldAtRatio(Vector2 ratio)
	{
		ratio.x = ratio.x * myGrid.bounds.size.x;
		ratio.y = ratio.y * myGrid.bounds.size.z;

		ratio.x -= myGrid.bounds.extents.x;
		ratio.y -= myGrid.bounds.extents.z;
		return new Vector3 (ratio.x, 0, ratio.y) + myGrid.transform.position; //may not be 0 we will see
	}

	public Vector3 worldAtRatio(Vector2 ratio, Vector3 offset)
	{
		return worldAtRatio(ratio) - myGrid.transform.position + offset;
	}



}
