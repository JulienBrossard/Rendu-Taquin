using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private Touch touch; 
    
    void Update()
    {
        // Tactile
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(Input.touchCount - 1); // Dernier toucher
            if (touch.phase == TouchPhase.Moved) // Lorsqu'on déplace le doigt
            {
                MovePiece.instance.Move(Camera.main.ScreenToWorldPoint(touch.position));
            }

            if (touch.phase == TouchPhase.Began) // Le premier toucher
            {
                TakePiece.instance.Take(Camera.main.ScreenToWorldPoint(touch.position));
            }

            if (touch.phase == TouchPhase.Ended) // Lorqu'on enlève le doigt
            {
                MovePiece.instance.LetPiece();
            }
        }
    }
}
