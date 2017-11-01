using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camMouseLook : MonoBehaviour {

    Vector2 mouseLook;
    Vector2 smoothV;

    Quaternion rotateCam, rotateChar;

    public float sensitivity = 5.0f;
    public float smoothing = 2.0f;

    GameObject character;


    // Use this for initialization
    void Start() {
        character = this.transform.parent.gameObject;
        rotateCam = transform.rotation;
        rotateChar = character.transform.rotation;

    }

    // Update is called once per frame
    void Update() {
        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);
        mouseLook += smoothV;

        mouseLook.y = Mathf.Clamp(mouseLook.y, -90f, 90f);

        rotateCam = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        rotateChar = Quaternion.AngleAxis(mouseLook.x, character.transform.up);

        transform.localRotation = rotateCam;
        character.transform.localRotation = rotateChar;

        if (Input.GetAxis("Fire2") != 0) {
            if (Input.GetAxisRaw("Fire2") != 0) {
                rotateCam = Quaternion.identity;
                rotateChar = Quaternion.identity;
                mouseLook = Vector2.zero;
            }
        }

        
    }

}