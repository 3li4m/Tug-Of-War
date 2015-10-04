using UnityEngine;
using System.Collections;

public class UnitPrefabManager : MonoBehaviour
{

	public unitVariants[] units;//should not be public please do not acces via here use the function



	public static UnitPrefabManager getPrefabManager()
	{
		return GameObject.FindObjectOfType<UnitPrefabManager> ();
	}

	public GameObject getPrefab(int unitIndex,unitUpgrade upgrade)
	{
		if (units [unitIndex].baseUnit == null)
		{
			Debug.LogError(unitIndex+ "has not been implimented in the prefab manager");
		}
		//check the upgrade and spawn the coresponding moddel
		if (upgrade == null) 
		{
			return units[unitIndex].baseUnit;
		}
		return units[unitIndex].baseUnit;//to stop compile errors does not have to be here
	}
}

[System.Serializable]
public class unitVariants
{
	public string name;
	public GameObject baseUnit;
	public GameObject [] upgradedModles;
}

public class unitUpgrade//to be implimented
{

}


