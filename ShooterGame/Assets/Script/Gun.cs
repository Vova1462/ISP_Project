using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {
    public Transform bulletSpawn;
    public GameObject bulletPrefab;
    public float bullet_speed = 30f;
    public float cool_down = 0.2f;
    float lastShootTime = 0;
    //Ray component
    public float weaponRange = 30f;
    public Transform raySpawn;
    private Camera fpsCam;
    private WaitForSeconds shotDuration = new WaitForSeconds(.07f);
    private LineRenderer laserLine;

    void Start()
    {
        laserLine = GetComponent<LineRenderer>();
        fpsCam = GetComponent<Camera>();
    }

    public void Beam()
    {
        Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));
        RaycastHit hit;
        laserLine.SetPosition(0, raySpawn.position);
        if (Physics.Raycast(rayOrigin,fpsCam.transform.forward,out hit))
        {
            laserLine.SetPosition(1, hit.point);
        } else
        {
            laserLine.SetPosition(1, fpsCam.transform.forward * weaponRange);
        }
    }

    public void Fire()
    {

        GameObject bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bullet_speed;
        lastShootTime = Time.time;
    }

    public bool isReadyToShoot()
    {
        return (Time.time >= lastShootTime + cool_down);
    }

}
