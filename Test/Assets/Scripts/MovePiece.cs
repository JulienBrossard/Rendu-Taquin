using System;
using UnityEngine;

public class MovePiece : MonoBehaviour
{
    public static MovePiece instance;
    public int nullIndex;
    [SerializeField] private GameObject[] movablePieces;

    [SerializeField] private int currentIndex;
    /*[SerializeField] private RaycastHit2D leftHit;
    [SerializeField] private RaycastHit2D rightHit;
    [SerializeField] private RaycastHit2D upHit;
    [SerializeField] private RaycastHit2D downHit;*/

    private void Awake()
    {
        instance = this;
    }

    // Bouge la pièce tenue
    public void Move(Vector2 position)
    {
        if (TakePiece.instance.currentPiece!=null && Tools.instance.IsObjectInArray(TakePiece.instance.currentPiece,movablePieces) )
        {
            if (Puzzle.instance.piecesPosition[nullIndex].x - TakePiece.instance.initPos.x == -1 || Puzzle.instance.piecesPosition[nullIndex].x - TakePiece.instance.initPos.x == 1 )
            {
                TakePiece.instance.currentPiece.transform.position = new Vector3(position.x,TakePiece.instance.currentPiece.transform.position.y,0);
            }
            else
            {
                TakePiece.instance.currentPiece.transform.position = new Vector3(TakePiece.instance.currentPiece.transform.position.x,position.y,0);;
            }
        }
    }

    // Pose la pièce
    public void LetPiece()
    {
        if (TakePiece.instance.currentPiece!=null)
        {
            if (Vector2.Distance(Puzzle.instance.piecesPosition[nullIndex], TakePiece.instance.currentPiece.transform.position)<0.8f) // Pose la pièce à la place de la case vide
            {
                currentIndex = Tools.instance.FindObjectInArray(TakePiece.instance.currentPiece, Puzzle.instance.pieces);
                TakePiece.instance.currentPiece.transform.position = Puzzle.instance.piecesPosition[nullIndex];
                Puzzle.instance.pieces[nullIndex] = TakePiece.instance.currentPiece;
                Puzzle.instance.pieces[currentIndex] = null;
                nullIndex = currentIndex;
                MovablePieces();
            }
            else // Remet la pièce à sa place
            {
                TakePiece.instance.currentPiece.transform.position = TakePiece.instance.initPos;
            }
        }
    }

    public void MovablePieces()
    {
        // Petit problème rencontré avec es raycats 2D qui ne détectent qu'une fois sur 2
        
        /*movablePieces = new List<GameObject>();
        leftHit = Physics2D.Raycast(Puzzle.instance.piecesPosition[nullIndex], Vector2.left);
        rightHit = Physics2D.Raycast(Puzzle.instance.piecesPosition[nullIndex], Vector2.right);
        upHit = Physics2D.Raycast(Puzzle.instance.piecesPosition[nullIndex], Vector2.up);
        downHit = Physics2D.Raycast(Puzzle.instance.piecesPosition[nullIndex], Vector2.down);
        Debug.DrawRay(Puzzle.instance.piecesPosition[nullIndex],Vector2.left,Color.red);
        Debug.DrawRay(Puzzle.instance.piecesPosition[nullIndex],Vector2.right,Color.red);
        Debug.DrawRay(Puzzle.instance.piecesPosition[nullIndex],Vector2.up,Color.red);
        Debug.DrawRay(Puzzle.instance.piecesPosition[nullIndex],Vector2.down,Color.red);
        
        
        if (leftHit.collider!=null)
        {
            Debug.Log(leftHit.collider);
            movablePieces.Add(leftHit.transform.gameObject);
        }
        if (rightHit.collider!=null)
        {
            movablePieces.Add(rightHit.transform.gameObject);
        }
        if (upHit.collider!=null)
        {
            movablePieces.Add(upHit.transform.gameObject);
        }
        if (downHit.collider!=null)
        {
            movablePieces.Add(downHit.transform.gameObject);
        }*/

        switch (nullIndex)
        {
            case 0 :
                movablePieces = new GameObject[2];
                movablePieces[0] = Puzzle.instance.pieces[1];
                movablePieces[1] = Puzzle.instance.pieces[3];
                break;
            case 1 :
                movablePieces = new GameObject[3];
                movablePieces[0] = Puzzle.instance.pieces[0];
                movablePieces[1] = Puzzle.instance.pieces[2];
                movablePieces[2] = Puzzle.instance.pieces[4];
                break;
            case 2 :
                movablePieces = new GameObject[2];
                movablePieces[0] = Puzzle.instance.pieces[1];
                movablePieces[1] = Puzzle.instance.pieces[5];
                break;
            case 3 :
                movablePieces = new GameObject[3];
                movablePieces[0] = Puzzle.instance.pieces[0];
                movablePieces[1] = Puzzle.instance.pieces[6];
                movablePieces[2] = Puzzle.instance.pieces[4];
                break;
            case 4 :
                movablePieces = new GameObject[4];
                movablePieces[0] = Puzzle.instance.pieces[1];
                movablePieces[1] = Puzzle.instance.pieces[7];
                movablePieces[2] = Puzzle.instance.pieces[3];
                movablePieces[3] = Puzzle.instance.pieces[5];
                break;
            case 5 :
                movablePieces = new GameObject[3];
                movablePieces[0] = Puzzle.instance.pieces[2];
                movablePieces[1] = Puzzle.instance.pieces[8];
                movablePieces[2] = Puzzle.instance.pieces[4];
                break;
            case 6 :
                movablePieces = new GameObject[2];
                movablePieces[0] = Puzzle.instance.pieces[3];
                movablePieces[1] = Puzzle.instance.pieces[7];
                break;
            case 7 :
                movablePieces = new GameObject[3];
                movablePieces[0] = Puzzle.instance.pieces[6];
                movablePieces[1] = Puzzle.instance.pieces[8];
                movablePieces[2] = Puzzle.instance.pieces[4];
                break;
            case 8 :
                movablePieces = new GameObject[2];
                movablePieces[0] = Puzzle.instance.pieces[5];
                movablePieces[1] = Puzzle.instance.pieces[7];
                break;
        }
        
    }
}
