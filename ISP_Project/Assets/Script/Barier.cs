using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Barier : MonoBehaviour {
    public float speed = 0f;
    public float lasttime = 0;
    private float delay = 10;
	// Use this for initialization
	// Update is called once per frame
	void Update () {
       GameObject target = GameObject.FindGameObjectWithTag("Player");
       if (target != null)
        {
            this.GetComponent<Rigidbody>().velocity = -this.transform.forward * speed;
            if (this.transform.position.x <= -22 || isReadyToCreate())
            {
                Destroy(gameObject);
                print("Barier");
            }
     
        }

    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
            collision.gameObject.tag = "Dead";
        }
    }
    public bool isReadyToCreate()
    {
        return (Time.time >= lasttime + delay);
    }
}
