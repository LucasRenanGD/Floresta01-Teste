using System;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(Health))]
public class PlayerController : MonoBehaviour, ICharacter
{
    Vector2 playerInputs = Vector2.zero;
    Rigidbody2D rb;
    Vector2 mousePosition;
    Mover mover;
    Health health;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        mover = GetComponent<Mover>();
        health = GetComponent<Health>();
        health.OnHealthReachZero += Die;
    }


    void Update() => GetInputs();

    void FixedUpdate()
    {
        mover.Move(playerInputs);
        RotatePlayer();
    }

    void GetInputs()
    {
        playerInputs.x = Input.GetAxis("Horizontal");
        playerInputs.y = Input.GetAxis("Vertical");
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void RotatePlayer() //Rotate the player 180 when mouse is on the opposite side of the screen
    {
        Vector3 lookVec = new Vector3(transform.position.x, transform.position.y, mousePosition.x - transform.position.x);
        transform.LookAt(lookVec);
    }

    void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void TakeDamage(int damage)
    {
        health.ModifyHealth(-damage);
    }

    public Team Team => Team.Player;
}