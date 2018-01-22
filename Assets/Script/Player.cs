using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour {
    public float player_speed = 15;
    public Rigidbody playerRigidbody;
    public int health = 3;

    //Ray variables
    public float handRange = 30f;
    public Transform raySpawn;
    private Camera fpsCam;
    private float catchRate;
    private WaitForSeconds catchDuration = new WaitForSeconds(.07f);
    private LineRenderer laserLine;
    private float delay;
    // Use this for initialization
    void Start () {
        laserLine = GetComponent<LineRenderer>();
        fpsCam = GetComponentInParent<Camera>();
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetButton("Fire1") && Time.time > delay)
        {
            StartCoroutine(CatchEffect());
            Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));
            RaycastHit hit;
            laserLine.SetPosition(0, raySpawn.position);
            if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, handRange))
            {
                laserLine.SetPosition(1, hit.point);
            } else
            {
                laserLine.SetPosition(1, fpsCam.transform.forward * handRange);
            }
            delay = Time.time + catchRate;
        }
		
	}
    private IEnumerator CatchEffect()
    {
        laserLine.enabled = true;
        yield return catchDuration;
        laserLine.enabled = false;
    }
}
