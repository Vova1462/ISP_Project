using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour {
    public float bullet_life_time=2f;
    public bool oneCollisionPerBullet = true;
	// Use this for initialization
	void Start () {
        Destroy(gameObject, bullet_life_time);
	}
	
	// Update is called once per frame
	void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy" && oneCollisionPerBullet)
        {
            Destroy(collision.gameObject);
            collision.gameObject.tag = "Dead";
        }
        if (collision.gameObject.tag == "Player" && oneCollisionPerBullet)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            Renderer playerRenderer = player.GetComponent<Renderer>();
            playerRenderer.material.color = new Color(255, 255, 255, 255);
            Text healthPoint = GameObject.Find("Health").GetComponent<Text>();
            Rigidbody playerRigidbody = player.GetComponent<Rigidbody>();
            playerRigidbody.isKinematic = true;
            player.tag = "Dead";
            GameObject playerGun = GameObject.FindGameObjectWithTag("Player_gun");
            playerGun.SetActive(false);
        }
        Destroy(gameObject);
        oneCollisionPerBullet = false;
    }
    
}
