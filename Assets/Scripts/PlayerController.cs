using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int HP = 500;
    public GameObject CutlassPrefab;
    public GameObject DaggerPrefab;
    public GameObject BoatAxePrefab;
    public GameObject FlintlockPrefab;
    public GameObject CurrentWeaponPrefab;
    public GameObject CurrentWeaponObject;
    public Weapon CurrentWeapon;
    public Transform WeaponSlot;
    public bool isAttacking;
    private float movementSpeed = 0.5f;
    private float horizontalInput;
    private float verticalInput;
    public PlayerCollisionDetector Detector;
    public PolygonCollider2D Collider;

    // Start is called before the first frame update
    void Start()
    {
        CurrentWeaponPrefab = CutlassPrefab;
        InstantiateWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.up * Time.deltaTime * movementSpeed * verticalInput);
        transform.Translate(Vector3.right * Time.deltaTime * movementSpeed * horizontalInput);

        if (Input.GetKeyDown(KeyCode.C) && HP != 0)
        {
            if (CurrentWeaponPrefab == CutlassPrefab)
            {
                CurrentWeaponPrefab = DaggerPrefab;
            }
            else if (CurrentWeaponPrefab == DaggerPrefab)
            {
                CurrentWeaponPrefab = BoatAxePrefab;
            }
            else if (CurrentWeaponPrefab == BoatAxePrefab)
            {
                CurrentWeaponPrefab = FlintlockPrefab;
            }
            else if (CurrentWeaponPrefab == FlintlockPrefab)
            {
                CurrentWeaponPrefab = CutlassPrefab;
            }

            foreach (Transform child in WeaponSlot)
            {
                Destroy(child.gameObject);
            }

            InstantiateWeapon();
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            if (CurrentWeapon.Ammo > 0 && !CurrentWeapon.IsRanged)
            {
                MeleeAttack();
            }
        }

        if (HP == 0)
        {
            movementSpeed = 0;
            CurrentWeapon.Ammo = 0;
        }
    }

    public void InstantiateWeapon()
    {
        CurrentWeaponObject = Instantiate(CurrentWeaponPrefab, WeaponSlot);
        CurrentWeapon = CurrentWeaponObject.GetComponent<Weapon>();
    }

    public void MeleeAttack()
    {
        CurrentWeaponObject.transform.localPosition = Vector3.right * 10 / 32f;
        CurrentWeapon.Collider.enabled = true;
        StartCoroutine(ResetWeaponAfterCooldown());
    }

    public IEnumerator ResetWeaponAfterCooldown()
    {
        yield return new WaitForSeconds(CurrentWeapon.AttackTime);
        CurrentWeaponObject.transform.localPosition = Vector3.zero;
        CurrentWeapon.Collider.enabled = false;
    }

    public void TakeDamage(int DMG)
    {
        HP -= DMG;
        if (HP <= 0)
        {
            HP = 0;
        }
    }
}
