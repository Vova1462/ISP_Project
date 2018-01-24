using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player_controller : MonoBehaviour {

    
    public float move_speed = 10f;
    public float turn_speed = 150f;
    public int playerHealth = 5;
    public Gun gun;
    public Rigidbody player_rigidbody;
    public bool inAir;


    public Transform Enemy_Spawn;
    //public GameObject Enemy_random;

    // Use this for initialization
    public GameObject Enemy_prefab;
    //public float enemy_speed = 5f;
    void Start()
    {
        gun = GetComponentInChildren<Gun>();
        player_rigidbody = GetComponent<Rigidbody>();
        inAir = false;
        for (int i = 0; i < 2; i++)
        {
            Vector3 enemy_position = new Vector3(Random.Range(-50f, 47f), 1f, Random.Range(-47f, 50f));
            Enemy_Spawn.position = enemy_position;
            GameObject Enemy_random = (GameObject)Instantiate(Enemy_prefab, Enemy_Spawn.position, Enemy_Spawn.rotation);
        }
    }
	
	// Update is called once per frame
	void Update () {
        float move = Input.GetAxis("Vertical") * Time.deltaTime * move_speed, 
              turn = Input.GetAxis("Horizontal") *Time.deltaTime * turn_speed;

        transform.Translate(0, 0, move);
        transform.Rotate(0, turn, 0);

        float isFired = Input.GetAxis("Fire1");
        if (isFired > 0 && gun.isReadyToShoot() == true && this.tag == "Player")
        {
            gun.Fire();
        }
        if (Input.GetKeyDown(KeyCode.Space) && !inAir)
        {
            player_rigidbody.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
            inAir = true;
        }

       /* float isRay = Input.GetAxis("Fire2");
        if (isRay>0 && gun.isReadyToShoot() == true)
        {
            gun.Beam();
        }*/

	}
    void OnCollisionEnter(Collision collision)
    {
        inAir = false;
    }    
}
