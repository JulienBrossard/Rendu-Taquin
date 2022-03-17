using TMPro;
using UnityEngine;

public class BestScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI bestScoreText;
    [SerializeField] private int bestScore;
    
    void Start()
    {
        // Affiche le meilleur score
        bestScore = PlayerPrefs.GetInt("bestScore", 181);
        if (bestScore == 181)
        {
            bestScoreText.text = "Best Score : aucun";
        }
        else
        {
            bestScoreText.text = "Best Score : " + bestScore +"s";
        }
    }
    
}
