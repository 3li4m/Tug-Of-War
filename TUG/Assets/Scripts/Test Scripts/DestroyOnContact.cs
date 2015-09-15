using UnityEngine;
using System.Collections;

public class DestroyOnContact : MonoBehaviour
{
    void OnCollisionEnter()
    {
        Destroy(gameObject);
    }
}