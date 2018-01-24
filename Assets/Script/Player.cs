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
    private float catchRate=0.2f;
    private WaitForSeconds catchDuration = new WaitForSeconds(.07f);
    private LineRenderer laserLine;
    public float last_time = 0f;
    public float delta_time_bar = 1f;
    public float delay = 1;

    public Transform barier_spawn;
    public GameObject barier_prefab;
    // Use this for initialization
    void Start () {
        laserLine = GetComponent<LineRenderer>();
        fpsCam = GetComponentInChildren<Camera>();
        playerRigidbody = GetComponent<Rigidbody>();
        CreateBarier();
    }

    // Update is called once per frame
    void Update () {
        Vector3 input = new Vector3(0, 0, Input.GetAxisRaw("Horizontal"));
        Vector3 velocity = input.normalized * player_speed;
        Vector3 movePosition = velocity * Time.deltaTime;

        transform.position += movePosition;
        if (Time.time - last_time >= delta_time_bar)
        {
            CreateBarier();
            last_time = Time.time;
            print("Train");
        }
            
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

    public void CreateBarier()
    {
        float z = 0;
        int position = Random.Range(1, 3);
        if (position == 1)
            z = -3.5f;
        else if (position == 2)
            z = 0f;
        else
            z = 3.5f;
        barier_spawn.position = new Vector3(22, 0.0f, z);
        GameObject train = (GameObject)Instantiate(barier_prefab, barier_spawn.position, barier_spawn.rotation);
        //print("Done");
    }

    /*public bool isReadyToCreate()
    {
        return (Time.time >= last_time + delay);
    }*/

    private IEnumerator CatchEffect()
    {
        laserLine.enabled = true;
        yield return catchDuration;
        laserLine.enabled = false;
    }
}
