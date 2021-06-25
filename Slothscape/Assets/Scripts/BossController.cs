using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{

    private Animator myAnim;
    private Transform target;
    public Transform homepos;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float maxrange;
    [SerializeField]
    private float minrange;

    // Start is called before the first frame update    
    void Start()
    {
        myAnim = GetComponent<Animator>();
        target = FindObjectOfType<PlayerController>().transform;
    }


    void Update()
    {
        if (Vector3.Distance(target.position, transform.position) <= maxrange && Vector3.Distance(target.position, transform.position) >= minrange)
        {
            FollowPlayer();
        }
        else if (Vector3.Distance(target.position, transform.position) >= maxrange)
        {
            GoHome();
        }
       
    }

    public void FollowPlayer()
    {
        myAnim.SetBool("IsMoving", true);
        myAnim.SetFloat("MoveX", (target.position.x - transform.position.x));
        myAnim.SetFloat("MoveY", (target.position.y - transform.position.y));
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    public void GoHome()
    {
        myAnim.SetFloat("MoveX", (homepos.position.x - transform.position.x));
        myAnim.SetFloat("MoveY", (homepos.position.y - transform.position.y));
        transform.position = Vector3.MoveTowards(transform.position, homepos.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, homepos.position) == 0)
        {
            myAnim.SetBool("IsMoving", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "MyWeapon")
        {
            Vector2 difference = transform.position - other.transform.position;
            transform.position = new Vector2(transform.position.x + difference.x, transform.position.y + difference.y);
        }
    }
}
