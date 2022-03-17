using System;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    public static Puzzle instance;
    public GameObject[] pieces;
    public Vector3[] piecesPosition = new Vector3[9];

    private void Awake()
    {
        instance = this;
    }

    public void AddPiece(GameObject piece) // Ajoute une pièce dans la liste
    {
        for (int i = 0; i < piecesPosition.Length; i++)
        {
            if (piece.transform.position == piecesPosition[i])
            {
                pieces[i] = piece;
            }
        }
    }

    public void Check() // Check si les objets sont bien placés
    {
        for (int i = 0; i < pieces.Length; i++)
        {
            if (pieces[i]!=null)
            {
                if (pieces[i].name.Replace("(Clone)",String.Empty) != (i+1).ToString())
                {
                    return;
                }
            }
        }
        GameManager.instance.Result(true);
    }
    
    
}
