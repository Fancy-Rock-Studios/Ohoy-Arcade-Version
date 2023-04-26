using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public string Hint;
    public int HP;
    public int Damage;
    public float AttackTime;
    public float MovementTime;
    public bool IsAttacking;
    public bool IsAttacked;
    public int CurrentAttackIndex = 0;
    public string Name;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator Attack()
    {
        transform.localPosition += Vector3.left * 10 / 32f;
        IsAttacking = true;
        yield return ResetEnemyAfterCooldown();
    }

    public IEnumerator ResetEnemyAfterCooldown()
    {
        yield return new WaitForSeconds(AttackTime);
        transform.localPosition -= Vector3.left * 10 / 32f;
        IsAttacking = false;
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
