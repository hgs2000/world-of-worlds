using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public int ranNum;
    public GameObject alvo;
    public float speed = 0.3f;
    public Rigidbody2D rBody;
    private Animator anim;
    private bool isDead;
    private Vector2 vetor = new Vector2();
    private float executionTime;
    public float fovAngle = 90f;
    public bool canSeePlayer;
    public bool waiting;
    public Transform viewer;
    public GameObject player;
    public Quaternion currentView;

    void Start() {
        waiting = false;
        ranNum = 1;
        rBody = GetComponentInParent<Rigidbody2D>();
        anim = GetComponentInParent<Animator>();
        isDead = false;
        executionTime = 0;
        currentView = transform.rotation;
    }

    void Update() {
        float z = viewer.rotation.z;

        if (!waiting) {
            rBody.MovePosition(rBody.position + vetor * Time.deltaTime);

            executionTime += Time.deltaTime;
            switch (ranNum) {
                case 1:
                    vetor.Set(Vector2.up.x, Vector2.up.y);
                    z = 180f;
                    break;
                case 2:
                    vetor.Set(Vector2.down.x, Vector2.down.y);
                    z = 0f;
                    break;
                case 3:
                    vetor.Set(Vector2.right.x, Vector2.right.y);
                    z = 270f;
                    break;
                case 4:
                    vetor.Set(Vector2.left.x, Vector2.left.y);
                    z = 90f;
                    break;
            }
            viewer.rotation = new Quaternion(0, 0, z, 0);
            Debug.Log("Valor Z: " + z + ". Valor Z do viewer: " + viewer.rotation.z);

            if (vetor != Vector2.zero) {
                anim.SetBool("isWalking", true);
                anim.SetFloat("inputX", vetor.x);
                anim.SetFloat("inputY", vetor.y);
            }
            else {
                anim.SetBool("isWalking", false);
                anim.SetFloat("inputX", 0);
                anim.SetFloat("inputY", 0);
            }
            if (executionTime > 1) {
                ranNum = Random.Range(1, 5);
                StartCoroutine(AtEase());
                executionTime = 0;
            }
        }
    }

    IEnumerator AtEase() {
        waiting = true;
        yield return new WaitForSeconds(2);
        waiting = false;
    }

    void OnCollisionEnter2D(Collision2D col) {
        //Debug.Log("Inimigo esbarrou");
        if (col.gameObject.name == "Wall") {
            switch (ranNum) {
                case 1:
                    vetor.Set(vetor.x - 3, vetor.y);
                    break;
                case 2:
                    vetor.Set(vetor.x + 3, vetor.y);
                    break;
                case 3:
                    vetor.Set(vetor.x, vetor.y - 3);
                    break;
                case 4:
                    vetor.Set(vetor.x, vetor.y + 3);
                    break;
            }
            rBody.MovePosition(rBody.position + vetor * Time.deltaTime);
        }
    }
}