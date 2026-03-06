using UnityEngine;
using TMPro;

public class ScoreTracker : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public int score = 0;
    public Transform playerTransform;
    public float startZ;

    void Start()
    {
        startZ = playerTransform.position.z;
    }

    void Update()
    {
        UpdateScore();

    }
    void UpdateScore()
    {
        float distanceScore = playerTransform.position.z - startZ;
        score = Mathf.FloorToInt(distanceScore); 
        scoreText.text = "Score: " + score.ToString();
    }
}
