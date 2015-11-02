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
		int x = Mathf.RoundToInt(cell.x * (sizeX -1)); //-1 because 1* size x will be out of the array bounds
		int y = Mathf.RoundToInt(cell.y * (sizeZ -1));
		baseUi.drawSelected (getGridWorld(x, y));
		print (getGridWorld(x, y)+ "x: "+x+"y: "+y);
		if (unitIndexes [x, y] == empty) 
		{
			unitIndexes [x, y] = selectedUnit; //to alow for bigger units make a place unit on grid function
			print ("unit added at: X:"+(int)x + "Y: "+(int)y);
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
