using UnityEngine;

public class WeaponCollisionDetector : MonoBehaviour
{
    public Weapon weapon;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Enemy enemy = collider.transform.parent.GetComponent<Enemy>();
        enemy.TakeDamage(weapon.Damage);
    }
}
