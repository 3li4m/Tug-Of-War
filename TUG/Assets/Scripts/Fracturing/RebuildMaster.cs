using UnityEngine;
using System.Collections;

public class RebuildMaster : MonoBehaviour
{
    public int livePieces = 25;

    public void subtractPiece()
    {
        livePieces = livePieces - 1;

        if(livePieces <= 12)
        {
            Rigidbody[] children = gameObject.GetComponentsInChildren<Rigidbody>();

            for (int i = 0; i < children.Length; i++)
            {
                if(!children[i].gameObject.GetComponent<Rebuild>().isDead)
                {
                    float force = 0f;
                    Vector3 explodeAngle = new Vector3(0, -1, 0);

                    children[i].gameObject.GetComponent<Rebuild>().deadLaunch(explodeAngle, force);
                }
            }
        }
    }
}