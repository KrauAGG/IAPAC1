using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moves2 : MonoBehaviour
{
    //public bool seek = true;
    public bool arrive = true;

    public GameObject target;

    public float acceleration = 0.1f;
    public float maxSpeed = 7f;
    public float movSpeed = 0f;

	public float turnAcceleration = 0.2f; // in degrees
	public float maxTurnSpeed = 10.0f; // in degrees / second
    public float turnSpeed = 0f;

    public float slowDistance = 4f;
    public float stopDistance = 2f;


    Vector3 movement = Vector3.zero;
    Quaternion rotation;  
    float freq = 0f;

    void Start()
    {
        Seek();        
    }

    void Update()
    {
        if (Vector3.Distance(target.transform.position, transform.position) < stopDistance) return;

        freq += Time.deltaTime;
        if (freq > 0.5)
        {
            freq -= 0.5f;
            Seek(); 
        }

        turnSpeed += turnAcceleration * Time.deltaTime;
        turnSpeed = Mathf.Min(turnSpeed, maxTurnSpeed);
        movSpeed += acceleration * Time.deltaTime;
        movSpeed = Mathf.Min(movSpeed, maxSpeed);

        if (arrive) Arrive(Time.deltaTime);

        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * turnSpeed);
        transform.position += transform.forward.normalized * movSpeed * Time.deltaTime;   
        
    }

    void Seek()
    {
        Vector3 direction = target.transform.position - transform.position;
        direction.y = 0f;
        movement = direction.normalized * acceleration;
        float angle = Mathf.Rad2Deg * Mathf.Atan2(movement.x, movement.z);
        rotation = Quaternion.AngleAxis(angle, Vector3.up);
    }


    void Arrive(float dt)
    {
        float distance = Vector3.Distance(target.transform.position, transform.position);
        if (distance > slowDistance) return;
        movSpeed = maxSpeed * (distance - stopDistance) / (slowDistance - stopDistance);

        // Nota: no es comproba si l'acceleració és masssa elevada.
    }
}
