using TMPro;
using UnityEngine;

public class PlayerCollectAbility : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI UI_pointsCount;
    private int Points = 0;
    
    public void AddPoints(int points)
    {
        Points += points;
        UpdateUI();
    }
    public void UpdateUI()
    {
        UI_pointsCount.text = $"{Points}";
    }
}
