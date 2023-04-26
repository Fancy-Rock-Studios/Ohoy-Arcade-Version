using UnityEngine;

public class PlayerCollisionDetector : MonoBehaviour
{

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
        PlayerController player = transform.parent.GetComponent<PlayerController>();
        player.TakeDamage(enemy.Damage);
    }
}
