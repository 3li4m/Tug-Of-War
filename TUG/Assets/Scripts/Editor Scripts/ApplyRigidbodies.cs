using UnityEngine;
using System.Collections;

//Makes scrips execute in edit mode
[ExecuteInEditMode] 
public class ApplyRigidbodies : MonoBehaviour 
{
	public bool applyRigidbody = false; 
	public bool removeRigidbody = false;
    public bool removeScript = false;

    private void Update()
    {
        if (applyRigidbody == true)
        {
            applyRigidbody = false;
            applyRigidbodies();
        }

        if (removeRigidbody == true)
        {
            removeRigidbody = false;
            removeRigidbodies();
        }

        if (removeScript == true)
        {
            DestroyImmediate(this);
        }
    }

    private	void applyRigidbodies ()
	{
        //Finds objects with MeshFilters
		MeshFilter[] children = gameObject.GetComponentsInChildren <MeshFilter> ();

		for (int i=0; i < children.Length; i++)
		{
            //Check if there is already a rigidbody on the object
            if (children[i].gameObject.GetComponent<Rigidbody>() == null)
            {
                children[i].gameObject.AddComponent<Rigidbody>();  //Add a rigidbody to the object
            }
		}
	}

	private	void removeRigidbodies ()
	{
        //Finds objects with rigidbodies
		Rigidbody[] children = gameObject.GetComponentsInChildren <Rigidbody> ();
		for (int i=0; i < children.Length; i++)
		{
			//Normal 'Destroy' Doesn't work in edit mode
			DestroyImmediate (children[i]); //Remove rigidbodies from objects
		}
	}
}
