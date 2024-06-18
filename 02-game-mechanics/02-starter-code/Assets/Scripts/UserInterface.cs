using UnityEngine;
using UnityEngine.UI;

public class UserInterface : MonoBehaviour
{
    [SerializeField] private Text goldLabel; 

    private void Start()
    {
        GameManager.Instance.OnGoldSet.AddListener(HandleGoldSet);
        HandleGoldSet(); // Ensure the gold is set correctly when this object starts.
    }

    private void HandleGoldSet()
    {
        goldLabel.text = "GOLD: " + GameManager.Instance.Gold.ToString();
    }
}