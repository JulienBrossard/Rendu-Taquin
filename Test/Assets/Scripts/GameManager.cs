using System;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeText; // Texte affichant le temps restant
    [SerializeField] private float time = 180; // Temps restant
    [SerializeField] private GameObject defeat; // Texte de défaite
    [SerializeField] private GameObject victory; // Texte de victoire
    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        // Affichage du temps à chaque Update
        time = time - Time.deltaTime;
        timeText.text = "Time : " + (int) time;
        if ((int) time<1)
        {
           Result(false); 
        }
    }

    // Fonction pour afficher le résultat et les boutons
    public void Result(bool result)
    {
        if (!result)
        {
            Menu.instance.Pause();
            Menu.instance.continueButton.SetActive(false);
            defeat.SetActive(true);
        }
        else
        {
            Menu.instance.Pause();
            Menu.instance.continueButton.SetActive(false);
            victory.SetActive(true);
            ScoreManager.instance.FinalScore((int) time);
        }
    }
}
