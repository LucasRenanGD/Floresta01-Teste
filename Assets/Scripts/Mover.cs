using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Mover : MonoBehaviour
{
    [Range(1, 25)]
    [SerializeField] float movSpeed = 5f;
    Vector2 movement = Vector2.zero;
    Rigidbody2D rb;

    void Awake() => rb = GetComponent<Rigidbody2D>();
    
    public void Move(Vector2 inputs)
    {
        movement = new Vector2(inputs.x, inputs.y) * movSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);
    }
}