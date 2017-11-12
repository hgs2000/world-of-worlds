using System.Collections;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform target;
    public float m_speed;
    public float zoom;
    Camera mycam;

    // Use this for initialization
    void Start () {
        mycam = GetComponent<Camera>();
        m_speed = 0.1f;
        zoom = 4f;
    }
	
	// Update is called once per frame
	void Update () {

        mycam.orthographicSize = (Screen.height / 100f) / zoom;

        if (target) {
            transform.position = Vector3.Lerp(transform.position, target.position, m_speed) + new Vector3(0,0,-10);
        }
    }
}
