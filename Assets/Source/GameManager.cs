using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private bool _isGameOver = false;
    public TextMeshProUGUI gameOver;
    public Button restart;
    
    public void EndGame()
    {
        if (!_isGameOver)
        {
            _isGameOver = true;
            gameOver.gameObject.SetActive(true);
            restart.gameObject.SetActive(true);
            
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
