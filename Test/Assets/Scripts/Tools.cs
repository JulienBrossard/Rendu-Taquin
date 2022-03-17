using UnityEngine;

public class Tools : MonoBehaviour
{
    public static Tools instance;

    private void Awake()
    {
        instance = this;
    }

    public int FindObjectInArray(GameObject obj, GameObject[] array) // Trouve l'index de l'objet
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == obj)
            {
                return i;
            }
        }

        return 0;
    }

    public bool IsObjectInArray(GameObject obj, GameObject[] array) // Boolean de l'objet dans l'array
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == obj)
            {
                return true;
            }
        }

        return false;
    }
}
