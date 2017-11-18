using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    Rigidbody2D rbody;
    Animator anim;

    // Use this for initialization
    void Start() {

        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update() {
        Vector2 movement_vector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Debug.Log("1");
        if (movement_vector != Vector2.zero) {

            anim.SetBool("isWalking", true);
            anim.SetFloat("input_X", movement_vector.x);
            anim.SetFloat("input_Y", movement_vector.y);
            Debug.Log("2");

        }
        else {

            anim.SetBool("isWalking", false);
            Debug.Log("3");

        }

        rbody.MovePosition(rbody.position + movement_vector * Time.deltaTime);

    }
}
