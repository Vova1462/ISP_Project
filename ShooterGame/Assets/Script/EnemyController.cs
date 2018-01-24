using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    public Gun gun;
    public float turnSpeed = 3;
    public float mindist = 10;
    public int enemyHealth = 3;
    // Use this for initialization
    // Update is called once per frame
    void Update () {
        GameObject target = GameObject.FindGameObjectWithTag("Player");
        if (target != null)
        {
            this.transform.LookAt(target.transform.position);
            if (gun.isReadyToShoot())
            {
                gun.Fire();
            }
            if (Distance(gameObject, target)>=mindist)
                this.GetComponent<Rigidbody>().velocity = -this.transform.forward * turnSpeed;

        }
	}
    
    public float Distance(GameObject Enemy, GameObject Player)
    {
        float dist_x = Mathf.Abs(Enemy.transform.position.x - Player.transform.position.x);
        float dist_z = Mathf.Abs(Enemy.transform.position.z - Player.transform.position.z);
        float dist = Mathf.Sqrt(dist_x * dist_x + dist_z * dist_z);
        //print(dist);
        return dist;
    }
}
