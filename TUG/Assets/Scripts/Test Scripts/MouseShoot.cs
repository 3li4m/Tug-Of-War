using UnityEngine;
using System.Collections;

public class MouseShoot : MonoBehaviour
{
    public GameObject projectile;
    public float bulletSpeed;
	
	void Update ()
	{
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                //bullet = Instantiate(item, hit.point, Quaternion.identity);
                //Instantiate(projectile, transform.position, transform.rotation);
                GameObject bullet = Instantiate(projectile, transform.position, transform.rotation) as GameObject;
                Rigidbody rb = bullet.GetComponent<Rigidbody>();
                //rb.velocity = transform.TransformDirection(hit.point * -10);
                bullet.transform.LookAt(hit.point);
                rb.AddRelativeForce(Vector3.forward * bulletSpeed);
                Destroy(bullet, 3);
            }
        }
    }
}

