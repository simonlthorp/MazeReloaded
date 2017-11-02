using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addFog : MonoBehaviour {
    public Shader shader1;
    public Shader shader2;
    public Shader shader3;
    public GameObject maze;
    public Renderer[] rend1;
    public Renderer rend2;
    bool foggy = false;
    bool isDay = true;
	// Use this for initialization
	void Start () {
		rend1= maze.GetComponentsInChildren<Renderer>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxisRaw("Fire3") != 0) {
            changeShader();
        }

        if(Input.GetAxisRaw("Fire4") != 0)
        {
            ToggleDay();
        }

    }

    void changeShader() {
        if (foggy) {
            foreach (Renderer rend in rend1) {
                rend.material.shader = shader1;
            }
        }
        else {
            foreach (Renderer rend in rend1) {
                rend.material.shader = shader2;
            }
        }
        foggy = !foggy;
    }

    private void ToggleDay()
    {
        if (isDay)
        {
            foreach (Renderer rend in rend1)
            {
                rend.material.shader = shader1;
            }
        }
        else
        {
            foreach (Renderer rend in rend1)
            {
                rend.material.shader = shader3;
            }
        }
        foggy = !foggy;
    }
}
