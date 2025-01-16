using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    public static GameManager Instance { get { return instance; } }

    [SerializeField]
    private TMP_Text scoreText = null;

    [SerializeField]
    private GameObject collectablePrefab = null;
    private int score = 0;

    void Awake()
    {
        if(instance!=null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            AddScore(300);
            SpawnCollectable();
        }
    }

    void Update()
    {

      
    }

    public void AddScore(int amount)
    {
        score += amount;
        scoreText.text = "Score:" + score.ToString();
    }

    public int GetScore()
    {
        return score;
    }

    public void SpawnCollectable()
    {
        Vector3 spawnPosition = Vector3.zero;
        spawnPosition.x = Random.Range(-2.5f, 2.7f);
        spawnPosition.y = Random.Range(-2.7f, 1.9f);
        GameObject newCollectable = Instantiate(collectablePrefab, spawnPosition, Quaternion.identity);
        
    }
}
