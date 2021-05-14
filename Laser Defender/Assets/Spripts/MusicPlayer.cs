using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    // Making music player a singleton so that only one track
    // plays continuously in all the scenes without starting over from the beginning

    // Start is called before the first frame update
    void Awake() // Happens at the very beginning
    {
        SetUpSingleton();        
    }

    private void SetUpSingleton()
    {
        // GetType() gets the type of the objects it is in, in this case - it's a MusicPlayer
        if (FindObjectsOfType(GetType()).Length > 1) // Note: the metod name is FindObjectS(!)OfType
        {
            Destroy(gameObject); // If MusicPlayer already exists, we destroy the new instance
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
