using UnityEngine;
using System.Collections;

public class Rebuild : MonoBehaviour
{
    public int health;
    private int originalHealth;
    private Rigidbody rb;
    public bool isDead = false;
    public bool reforming = false;

    //Positions
    private Vector3 originalPos;
    private Vector3 newPos;

    //Rotatioms
    private Quaternion originalRot;
    private Quaternion newRot;

    private float startTime;
    private float journeyLength;

    public float timer;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        originalPos = transform.position;
        originalRot = transform.rotation;
        originalHealth = health;
    }
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            initReform();
        }

        if (reforming)
        {
            reform();
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Bullet" && !isDead)
        {
            health = health - 1;

            if (health <= 0)
            {
                float range = 0.25f;
                float force = 1f;
                
                Vector3 contactAngle = -(col.contacts[0].normal);
                Vector3 rebound = new Vector3(contactAngle.x + Random.Range(-range, range), contactAngle.y + Random.Range(-range, range), contactAngle.z + Random.Range(-range, range));
                deadLaunch(rebound, force);
            }
        }
    }

    public void deadLaunch(Vector3 direction, float force)
    {
        rb.isKinematic = false;
        rb.AddForce(direction * force, ForceMode.Impulse);
        isDead = true;
        GetComponentInParent<RebuildMaster>().subtractPiece();
    }

    private void initReform()
    {
        newPos = transform.position;
        newRot = transform.rotation;
        startTime = Time.time;
        journeyLength = Vector3.Distance(newPos, originalPos);

        reforming = true;
    }

    private void reform()
    {
        float distCovered = (Time.time - startTime) * 10;
        float fracJourney = distCovered / journeyLength;
        transform.position = Vector3.Lerp(newPos, originalPos, fracJourney);
        transform.rotation = Quaternion.Slerp(newRot, originalRot, fracJourney);
        
        timer += Time.deltaTime;

        if (transform.position == originalPos && transform.rotation == originalRot || timer > 2.5f)
        {
            timer = 0;
            rb.isKinematic = true;
            transform.position = originalPos;
            transform.rotation = originalRot;
            isDead = false;
            health = originalHealth;
            reforming = false;
            GetComponentInParent<RebuildMaster>().livePieces ++;
        }
    }
}