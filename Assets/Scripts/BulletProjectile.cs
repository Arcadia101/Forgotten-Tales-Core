using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectile : MonoBehaviour
{
    public float life = 0;
    public float lifespan = 10f; //Let's use these two variables to ensure after some time the bullets just disappear either collide or not
    private Rigidbody bulletRB;
    public float maxDistance = 20;
    private Vector3 origin;


    private void Update()
    {
        expiration(origin);


    }


    private void Awake()
    {
        bulletRB = GetComponent<Rigidbody>();
    }

    private void Start()
    {

        origin = transform.position;
        float speed = 10f;
        bulletRB.velocity = transform.forward * speed;


    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<BulletTarget>() != null)
        {
            //Hit target.
            Debug.Log("Hit target");
        }
        else
        {
            //Hit something else.
            Debug.Log("Hit no target");
        }
        Destroy(gameObject);
    }
    private void expiration(Vector3 reference_point)
    {

        life += Time.deltaTime; //Here we increase the time a bullet has been in the world
        if (life > lifespan) //Here we verify if that time has been greater than the max time it should be.
        {
            Destroy(gameObject); //if it is, bye baby
        }

        //Alternatively, if the bullet is too far from a reference point, it will get destroyed as well. For now our reference is just the origin's position
        if ((transform.position - reference_point).magnitude > maxDistance) //We check if the separation between current position and the initial point is greater than the max distance
        {
            Destroy(gameObject); //if it is, bye baby
        }




    }
}