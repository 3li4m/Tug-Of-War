using UnityEngine;
using System.Collections;


public class BasePlacementUi : MonoBehaviour
{
	public GameObject selectedGizmoPrefab;
	GameObject selectedGizmoWorld;

	void Start()
	{
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
}
