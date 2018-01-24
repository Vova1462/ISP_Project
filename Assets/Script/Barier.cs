using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Barier : MonoBehaviour {
    public float speed = 500f;
	// Use this for initialization
	// Update is called once per frame
	void Update () {
       GameObject target = GameObject.FindGameObjectWithTag("Player");
       if (target != null)
        {
            this.GetComponent<Rigidbody>().velocity = this.transform.right * speed;
            if (this.transform.position.x <= -22f)
            {
                Destroy(gameObject);
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
}
