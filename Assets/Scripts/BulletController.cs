using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BulletController : MonoBehaviour
{
    [Range(1, 100)]
    [SerializeField] float bulletSpeed = 10f;
    Rigidbody2D rb;
    int damage = 0;
    Team bulletTeam;

    void Awake() => rb = GetComponent<Rigidbody2D>();
    void Start() => SetSpeed();
    void SetSpeed() => rb.AddForce(transform.right * bulletSpeed, ForceMode2D.Impulse);
    bool IsEnemy(ICharacter iCharacter) => iCharacter.Team != bulletTeam;

    public void Initialize(int weaponDamage, Team team)
    {
        damage = weaponDamage;
        bulletTeam = team;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        ICharacter iCharacter = other.gameObject.GetComponent<ICharacter>();
        if (iCharacter != null && IsEnemy(iCharacter))
        {
            iCharacter.TakeDamage(damage);
        }

        Destroy(gameObject);
    }


}