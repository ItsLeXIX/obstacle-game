using TMPro;
using UnityEngine;

public class JumpCounterUI : MonoBehaviour
{
    public TextMeshProUGUI jumpCounterText;
    public PlayerMovement playerMovement;
    public int jumpCount;

    void Update()
    {
        jumpCount = playerMovement.jumpCount;
        jumpCounterText.text = "Jumps: " + jumpCount.ToString();
    }

}
