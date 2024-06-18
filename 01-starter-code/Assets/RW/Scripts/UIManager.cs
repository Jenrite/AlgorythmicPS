using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public Image heart1;
    public Image heart2;
    public Image heart3;

    private void Update()
    {
        scoreText.text = "Sheep Saved: " + GameManager.Instance.sheepSaved;
        UpdateHearts(GameManager.Instance.sheepDropped);
    }

    private void UpdateHearts(int sheepDropped)
    {
        if (sheepDropped >= 1) heart1.enabled = false;
        if (sheepDropped >= 2) heart2.enabled = false;
        if (sheepDropped >= 3) heart3.enabled = false;
    }
}
