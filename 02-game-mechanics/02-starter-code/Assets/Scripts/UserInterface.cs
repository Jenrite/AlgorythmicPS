using UnityEngine;
using UnityEngine.UI;

public class UserInterface : MonoBehaviour
{
    [SerializeField] private Text goldLabel;
    [SerializeField] private Text healthLabel;

    private void Start()
    {
        GameManager.Instance.OnGoldSet.AddListener(HandleGoldSet);
        HandleGoldSet(); // Ensure the gold is set correctly when this object starts.
        GameManager.Instance.OnHealthSet.AddListener(HandleHealthSet);

        // Ensure the health label is set correctly when this object starts
        HandleHealthSet();
    }

    // This method updates the health label text based on GameManager.Instance.Health
    private void HandleHealthSet()
    {
        healthLabel.text = "HEALTH: " + GameManager.Instance.Health.ToString();
    }
    private void HandleGoldSet()
    {
        goldLabel.text = "GOLD: " + GameManager.Instance.Gold.ToString();
    }
}