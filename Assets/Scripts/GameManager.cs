using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static Enemy CurrentEnemy;
    public PlayerController Player;
    public TextMeshProUGUI PlayerHPText;
    public TextMeshProUGUI EnemyHPText;
    public TextMeshProUGUI ResultsText;
    public GameObject SeaweedPrefab;
    public GameObject CurrentEnemyPrefab;
    public GameObject CurrentEnemyObject;
    public bool isGameActive;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player").GetComponent<PlayerController>();
        CurrentEnemyPrefab = SeaweedPrefab;
        InstantiateEnemy();
        isGameActive = true;
        ResultsText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerHPText.text = "Player HP: " + Player.HP;
        EnemyHPText.text = CurrentEnemy.Name + " HP: " + CurrentEnemy.HP;

        if (Player.HP == 0 || CurrentEnemy.HP == 0)
        {
            isGameActive = false;
        }

        if (!isGameActive && CurrentEnemy.HP == 0)
        {
            ResultsText.text = "VICTORY!";
            ResultsText.gameObject.SetActive(true);
        }
        else if (!isGameActive & Player.HP == 0)
        {
            ResultsText.text = "DEFEAT...";
            ResultsText.gameObject.SetActive(true);
        }
    }

    public void InstantiateEnemy()
    {
        CurrentEnemyObject = Instantiate(CurrentEnemyPrefab);
        CurrentEnemy = CurrentEnemyObject.GetComponent<Enemy>();
    }
}
