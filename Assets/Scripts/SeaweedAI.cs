using System.Collections;
using UnityEngine;

public class SeaweedAI : MonoBehaviour
{
    private Enemy enemy;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Enemy>();
        StartCoroutine(SeaweedAIScript());
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy.HP == 0)
        {
            StopAllCoroutines();
        }
    }

    public IEnumerator SeaweedAIScript()
    {
        while (true)
        {
            int attacking = Random.Range(0, 3);

            if (attacking == 0)
            {
                yield return enemy.Attack();
            }
            else
            {
                yield return new WaitForSeconds(enemy.MovementTime);
            }
        }
    }
}
