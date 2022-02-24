using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerBulletFire : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float shootSpeed;
    [SerializeField] private float reloadTime = 2f;
    [SerializeField] private int maxAmmo = 6;
    [SerializeField] private int currentAmmo;
    private GameObject GunEndPoint;

    bool isReloading = false;

    private void Awake()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        GunEndPoint = GameObject.Find("GunEndPoint");
    }

    private void Start()
    {
        playerController.OnShoot += PlayerController_OnShoot;
        currentAmmo = maxAmmo;
    }
    private void Update()
    {
        AmmoHandler();
    }

    private void PlayerController_OnShoot(object sender, PlayerController.OnShootEventArg e)
    {
        if (currentAmmo <= 0) return;

        // Debug.Log("Oggbogg Shoot rolver");
        GameObject firedBullet = Instantiate(bullet, GunEndPoint.transform.position, GunEndPoint.transform.rotation);

        Vector3 diff = e.shootPos - e.gunEndPointPos;
        diff.Normalize();
        firedBullet.GetComponent<Rigidbody2D>().velocity = diff * bulletSpeed;
        currentAmmo--;
        Debug.Log(currentAmmo);
    }
    IEnumerator Reload()
    {
        // Make Gun Reload with its stats.
        print("Reloading...");
        yield return new WaitForSeconds(3);
        currentAmmo = maxAmmo;
    }

    private void AmmoHandler()
    {
        if (currentAmmo <= 0 && isReloading == false)
        {
            // print("huh");
            StartCoroutine(Reload());
            isReloading = true;
        }
    }

}
