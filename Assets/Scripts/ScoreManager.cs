using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] int score; // Score
    [SerializeField] private int bestScore; // Best Score
    public static ScoreManager instance;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject scoreObject;

    private void Awake()
    {
        instance = this;
    }

    // Score Final
    public void FinalScore(int time)
    {
        score = 180 - time; // Score final
        scoreObject.SetActive(true); // Active le texte
        scoreText.text = "Score : " + score+"s"; // Affichage du score
        bestScore = PlayerPrefs.GetInt("bestScore", 181); // Récupérer la valeur
        if (bestScore>score) 
        {
            bestScore = score; // Reset du score
            PlayerPrefs.SetInt("bestScore",bestScore);
            PlayerPrefs.Save(); // Sauvegarde du score
        }
    }
}
