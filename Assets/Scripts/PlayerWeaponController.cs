using UnityEngine;

[RequireComponent(typeof(Weapon))]
public class PlayerWeaponController : MonoBehaviour
{
    [Tooltip("Ease the rotation speed of the weapon")]
    [Range(0, 100)]
    [SerializeField] float damping = 10;
    Vector2 mousePosition;
    Weapon weapon;

    void Awake()
    {
        weapon = GetComponent<Weapon>();
    }

    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetButton("Fire1"))
        {
            weapon.Shoot();
        }
    }

    void FixedUpdate() => Rotation();

    void Rotation()
    {
        Vector2 lookVector = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        var rotation = Quaternion.LookRotation(lookVector);
        rotation *= Quaternion.Euler(0, -90, 0); // this adds a 90 degrees Y rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
    }
}