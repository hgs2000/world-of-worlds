using System.Collections;
using UnityEngine;

public class LightFollow : MonoBehaviour {

    public Transform target;
    public float m_speed;
    public float zoom;
    Light _light;


    // Use this for initialization
    void Start () {
        _light = GetComponent<Light>();
        m_speed = 0.1f;
        zoom = 4f;
    }
	
	// Update is called once per frame
	void Update () {
        if (target) {
            transform.position = new Vector3(target.position.x, target.position.y, -2);
        }
    }
}
