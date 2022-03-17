using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> androidImages; // Image Android du jeu
    [SerializeField] private List<GameObject> iphoneImages; // Image Apple du jeu
    [SerializeField] private List<Vector3> positions; // Position des images
    [SerializeField] private GameObject currentImage; // Image actuelle
    [SerializeField] private int imageNb; // nombre d'image
    [SerializeField] private int positionNb; // nombre de position


    void Start()
    {
        MakeLevel(); // Création aléatoire du level
    }

    void MakeLevel() // Création aléatoire du level
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            Puzzle.instance.piecesPosition = positions.ToArray(); // Enregistre les valeurs de position
            androidImages.Remove(androidImages[4]); // Case vide
            // Positionnement aléatoire des autres images
            for (int i = 0; i < 8; i++)
            {
                imageNb = Random.Range(0, androidImages.Count); // nombre d'image
                currentImage = Pooler.instance.Pop("Android" + androidImages[imageNb].name); // image actuelle
                positionNb = Random.Range(0, positions.Count); // nombre de position
                currentImage.transform.position = positions[positionNb]; // changement de position
                Puzzle.instance.AddPiece(currentImage); // Ajoute la pièce à la liste des pièces
                positions.Remove(positions[positionNb]); // Retire la position
                androidImages.Remove(androidImages[imageNb]); // Retire la pièce
            }
            MovePiece.instance.nullIndex = Tools.instance.FindObjectInArray(null,Puzzle.instance.pieces); // Trouve l'index de la case vide
            MovePiece.instance.MovablePieces(); // Liste des pièces bougeable
        }
        else
        {
            Puzzle.instance.piecesPosition = positions.ToArray(); // Enregistre les valeurs de position
            iphoneImages.Remove(iphoneImages[4]); // Case vide
            // Positionnement aléatoire des autres images
            for (int i = 0; i < 8; i++)
            {
                imageNb = Random.Range(0, iphoneImages.Count); // nombre d'image
                currentImage = Pooler.instance.Pop("Apple" + iphoneImages[imageNb].name); // image actuelle
                positionNb = Random.Range(0, positions.Count);// nombre de position
                currentImage.transform.position = positions[positionNb]; // changement de position
                Puzzle.instance.AddPiece(currentImage); // Ajoute la pièce à la liste des pièces
                positions.Remove(positions[positionNb]); // Retire la position
                iphoneImages.Remove(iphoneImages[imageNb]); // Retire la pièce
            }
            MovePiece.instance.nullIndex = Tools.instance.FindObjectInArray(null,Puzzle.instance.pieces); // Trouve l'index de la case vide
            MovePiece.instance.MovablePieces(); // Liste des pièces bougeable
        }
    }
}
