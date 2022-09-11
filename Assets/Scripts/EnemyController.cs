using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(Health))]
[RequireComponent(typeof(EnemyWeaponController))]
public class EnemyController : MonoBehaviour, ICharacter
{
    [Range(.5f, 5f)]
    [SerializeField] float contactThreshold = 1.5f;
    [Range(1f, 25f)]
    [SerializeField] float chaseThreshold = 10f;
    [Range(.5f, 5f)]
    [SerializeField] float delayBeforeActing = 1f;

    PlayerController player;
    Animator animator;
    Rigidbody2D rb;
    Mover mover;
    Health health;
    EnemyWeaponController enemyWeaponController;
    Vector2 monsterMovement;
    float distanceToPlayer;

    void Awake()
    {
        player = FindObjectOfType<PlayerController>(); //Not ideal (could be inject when spawned)
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        mover = GetComponent<Mover>();
        health = GetComponent<Health>();
        health.OnHealthReachZero += Die;
        enemyWeaponController = GetComponent<EnemyWeaponController>();
    }

    void Update()
    {
        if (Time.time < delayBeforeActing) return;

        FindPlayerPositionAndDistance();
        RotateEnemyToLookAtPlayer();
        EnemyDecisionMaking();
    }

    void EnemyDecisionMaking()
    {
        if (distanceToPlayer <= contactThreshold)
        {
            //Deal damage on contact?
        }
        else if (distanceToPlayer < chaseThreshold)
        {
            MoveMonster();
            enemyWeaponController.AimAndShoot(player.transform.position);
        }
    }

    void MoveMonster()
    {
        animator.SetTrigger("isChasing");
        mover.Move(monsterMovement);
    }


    void FindPlayerPositionAndDistance()
    {
        monsterMovement.x = player.transform.position.x - transform.position.x;
        monsterMovement.y = player.transform.position.y - transform.position.y;
        distanceToPlayer = Vector2.Distance(player.transform.position, transform.position);
    }

    void RotateEnemyToLookAtPlayer()//180 degrees
    {
        Vector3 lookVec = new Vector3(transform.position.x, transform.position.y, transform.position.x - player.transform.position.x);
        transform.LookAt(lookVec);
    }

    void Die()
    {
        Destroy(gameObject);
    }

    public void TakeDamage(int damage)
    {
        health.ModifyHealth(-damage);
    }

    public Team Team => Team.Enemy;
}