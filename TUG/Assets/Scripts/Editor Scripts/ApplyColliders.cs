using UnityEngine;
using System.Collections;

//Makes scrips execute in edit mode
[ExecuteInEditMode] 
public class ApplyColliders : MonoBehaviour 
{
	public bool applyCollider = false;
    public bool removeCollider = false;
    public bool removeScript = false;

    private void Update()
    {
        if (applyCollider == true)
        {
            applyCollider = false;
            applyColliders();
        }

        if (removeCollider == true)
        {
            removeCollider = false;
            removeColliders();
        }

        if (removeScript == true)
        {
            DestroyImmediate(this);
        }
    }

    private	void applyColliders ()
	{
        //Finds objects with MeshFilters
		MeshFilter[] children = gameObject.GetComponentsInChildren <MeshFilter> ();

		for (int i=0; i < children.Length; i++)
		{
            //Check if there is already a collider on the object
            if (children[i].gameObject.GetComponent<Collider>() == null)
            {
                children[i].gameObject.AddComponent<BoxCollider>();  //Add a collider to the object
            }
		}
	}

	private	void removeColliders ()
	{
        //Finds objects with colliders
		Collider[] children = gameObject.GetComponentsInChildren <Collider> ();
		for (int i=0; i < children.Length; i++)
		{
			//Normal 'Destroy' Doesn't work in edit mode
			DestroyImmediate (children[i]); //Remove colliders from objects
		}
	}
}
