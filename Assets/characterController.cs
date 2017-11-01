using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour {
    public float speed = 10.0f;
    public GameObject maze;
    private CapsuleCollider col;
    public MeshCollider[] cols;
    Vector3 startPos;
	// Use this for initialization
	void Start () {
        col = GetComponent<CapsuleCollider>();
        cols = maze.GetComponentsInChildren<MeshCollider>();
        Cursor.lockState = CursorLockMode.Locked;
        startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        float translation = Input.GetAxis("Vertical") * speed;
        float straffe = Input.GetAxis("Horizontal") * speed;

        translation *= Time.deltaTime;
        straffe *= Time.deltaTime;

        transform.Translate(straffe, 0, translation);

        if (Input.GetAxisRaw("Fire1") != 0) {
            walkThroughWalls();
        }

        if (Input.GetAxis("Fire2") != 0) {
            if (Input.GetAxisRaw("Fire2") != 0) {
                transform.position = startPos;
            }
        }

        if (Input.GetAxis("Cancel") != 0) {
            if (Input.GetAxisRaw("Cancel") != 0) {
                Application.Quit();
            }
        }

        if (Input.GetKeyDown("`")) {
            Cursor.lockState = CursorLockMode.None;
        }
	}

    void walkThroughWalls() {
        int count = 1;
        foreach(MeshCollider meshCol in cols) {
            if (count != 1) {
                meshCol.enabled = !meshCol.enabled;
            }
            count++;
        }
    }
}
