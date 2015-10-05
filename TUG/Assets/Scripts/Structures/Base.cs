using UnityEngine;
using System.Collections;

public class Base : MonoBehaviour 
{
	public int sizeX =5, sizeZ =5;
	public const int empty =-1;

	private int [,] unitIndexes;
	protected UnitPrefabManager unitPrefabManager;
	public GridManager gridManager;
	public Transform enemyBase;
	public int selectedUnit;
	public BasePlacementUi baseUi;
	private void Start() //will add this bases spawn wave so it will be called every time the game manager deems necicary
	{
		WaveManager.findGameManager ().spawnUnits += spawnWave;
		unitPrefabManager = UnitPrefabManager.getPrefabManager ();
		initalizeUnits ();
	}
	private void spawnWave()
	{
		for (int z=0; z < sizeZ; z++) 
		{
			for (int x=0; x < sizeX; x++) 
			{
				GameObject nextUnit = getNextUnit(x,z);
				if(nextUnit != null)
				{
					GameObject unit = Instantiate(nextUnit,getGridWorld(x,z),nextUnit.transform.rotation)as GameObject;//no clue where to spawn
					unit.GetComponent<UnitPathfinding>().destanation = enemyBase;//the base now tells the unit where to walk
				}
			}
		}
	}

	GameObject getNextUnit(int x, int z)
	{
		if (unitIndexes [x, z] != empty)//so we dont go over the array bounds
		{
			return unitPrefabManager.getPrefab (unitIndexes [x, z], null);
		}
		return null;
	}



	private void initalizeUnits()//makes all of the units = to empty(-1)
	{
		unitIndexes = new int[sizeX,sizeZ];
		for(int z=0; z < sizeZ; z++)
		{
			for(int x=0; x < sizeX; x++)
			{
				unitIndexes[x,z] = empty;
			}
		}
	}
	public void addUnit(Vector2 cell)//an economy class should be between here and acutaly modifying the grid
	{								//aditionaly there is no current selected unit option
		int x = Mathf.RoundToInt(cell.x * (sizeX -1)); //-1 because 1* size x will be out of the array bounds
		int y = Mathf.RoundToInt(cell.y * (sizeZ -1));
		baseUi.drawSelected (getGridWorld(x, y));
		if (unitIndexes [x, y] == empty) 
		{
			unitIndexes [(int)cell.x, (int)cell.y] = selectedUnit;
			print ("unit added at: X:"+x + "Y: "+y);
		}
	}
	Vector3 getGridWorld(int x, int y)
	{
		x = x / sizeX;
		y = y / sizeZ;

		return gridManager.worldAtRatio (new Vector2 (x,y));
	}
}
