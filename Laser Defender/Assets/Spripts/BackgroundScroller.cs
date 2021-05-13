using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    /*
     * This is the parallax background effect script.
     * How to create this effect:
     * 1: Create 3D object >> Quad and remove "Mesh collider"
     * 2: Change your sprite to texture (from sprite 2D to "Default") and put the "Wrap mode" to "Repeat"
     * 3: Put the texture on the quad and change the shader to "Unlit/Texture"
    */

    [SerializeField] float backgroundScrollSpeed = 0.5f;
    Material myMaterial;
    Vector2 offSet;


    // Start is called before the first frame update
    void Start()
    {
        myMaterial = GetComponent<Renderer>().material; // Getting material (texture) of the quad
        offSet = new Vector2(0f, backgroundScrollSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        myMaterial.mainTextureOffset += offSet * Time.deltaTime; // We get access to the texture`s offset values and change them
    }
}
