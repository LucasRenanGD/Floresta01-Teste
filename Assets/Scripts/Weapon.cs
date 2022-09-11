using System;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] int weaponDamage = 20;
    [SerializeField] float cooldownBetweenShots = .5f;
    [SerializeField] Transform bulletSpawnPoint;
    [SerializeField] GameObject bulletPrefab;
    float timeOfLastShot = 0;

    Team team;

    void Awake() => team = GetComponentInParent<ICharacter>().Team;

    public void Shoot()
    {
        if (Time.time - timeOfLastShot < cooldownBetweenShots) return;

        BulletController bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation).GetComponent<BulletController>();
        bullet.Initialize(weaponDamage, team);

        timeOfLastShot = Time.time;
    }

}