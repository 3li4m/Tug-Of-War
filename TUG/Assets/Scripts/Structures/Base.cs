using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
public class Base : NetworkBehaviour
{
	public int sizeX =5, sizeZ =5;
	public const int empty =-1;

	private int [,] unitIndexes;
	protected UnitPrefabManager unitPrefabManager;
	public GridManager gridManager;
	public Transform enemyBase;
	public int selectedUnit;
	public BasePlacementUi baseUi;
	public Transform spawnOffset;

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
					GameObject unit = Instantiate(nextUnit,getGridWorld(x,z,spawnOffset.position)  ,nextUnit.transform.rotation)as GameObject;
					//GameObject unit = NetworkServer.Spawn(nextUnit);
					//unit.transform.position = 
					unit.GetComponent<UnitPathfinding>().destanation = enemyBase;//the base now tells the unit where to walk
				}
			}
		}
	}

	GameObject getNextUnit(int x, int z)
	{
		if (unitIndexes [x, z] != empty)
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
		int x = Mathf.RoundToInt(cell.x * (float)sizeX); 
		int y = Mathf.RoundToInt(cell.y * (float)sizeZ);
		baseUi.drawSelected (getGridWorld(x, y));

		x -= 1; //arrays start at 0 so shift the value from 1 to 0 10 to 9 ect
		y -=1 ; 
		if (unitIndexes [x, y] == empty) 
		{
			unitIndexes [x, y] = selectedUnit; //to alow for bigger units make a place unit on grid function
		}
	}
	Vector3 getGridWorld(int x, int y)
	{

		float _x = (float)x/ (float)sizeX;
		float _y = (float)y/ (float)sizeZ;
		return gridManager.worldAtRatio (new Vector2 (_x,_y));
	}
	Vector3 getGridWorld(int x, int y,Vector3 offset)
	{
		float _x = (float)x/ (float)sizeX;
		float _y = (float)y/ (float)sizeZ;
		return gridManager.worldAtRatio (new Vector2 (_x,_y),offset);
	}
}
