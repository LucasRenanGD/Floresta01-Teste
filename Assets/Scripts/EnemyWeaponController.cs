using UnityEngine;

[RequireComponent(typeof(Weapon))]
public class EnemyWeaponController : MonoBehaviour
{
    [SerializeField]
    float damping = 5f;
    [SerializeField]
    Transform weaponPointTransform;
    Weapon weapon;
    void Awake() => weapon = GetComponent<Weapon>();

    public void AimAndShoot(Vector3 position)
    {
        Vector2 lookVector = new Vector2(position.x - weaponPointTransform.position.x, position.y - weaponPointTransform.position.y);
        var rotation = Quaternion.LookRotation(lookVector);
        rotation *= Quaternion.Euler(0, -90, 0); // this adds a 90 degrees Y rotation
        weaponPointTransform.rotation = Quaternion.Slerp(weaponPointTransform.rotation, rotation, Time.deltaTime * damping);
        weapon.Shoot();
    }
}
