using UnityEngine;

public class Weapon : MonoBehaviour
{
    public string Name;
    public string Description;
    public float AttackTime;
    public int Damage;
    public int Ammo;
    public bool IsRanged;
    public WeaponCollisionDetector Detector;
    public PolygonCollider2D Collider;

    // Start is called before the first frame update
    void Start()
    {
        Collider = GetComponentInChildren<PolygonCollider2D>();
        Collider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
