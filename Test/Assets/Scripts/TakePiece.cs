using UnityEngine;

public class TakePiece : MonoBehaviour
{
    public static TakePiece instance;
    [SerializeField] private RaycastHit2D hit;
    public GameObject currentPiece;
    public Vector2 initPos;

    private void Awake()
    {
        instance = this;
    }

    // Prendre une pièce
    public void Take(Vector2 origin)
    {
        hit = Physics2D.Raycast(origin, Vector3.forward);
        if (hit.collider != null)
        {
            currentPiece = hit.transform.gameObject;
            initPos = currentPiece.transform.position;
        }
        else
        {
            currentPiece = null;
        }
    }
}
