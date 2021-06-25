using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonController : MonoBehaviour
{
    Health health;              //  Skeleton HP
    private Animator myAnim;
    private Transform target;   //  The player's position
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
        //  Skeleton starts following player if they get within detection range
        if (Vector3.Distance(target.position, transform.position) <= maxrange && Vector3.Distance(target.position, transform.position) >= minrange)
        {
            FollowPlayer();
        }

        //  Skeleton walks back to spawn point once player escapes detection range
        else if (Vector3.Distance(target.position, transform.position) >= maxrange)
        {
            GoHome();
        }
       
    }

    //  Follow the player everywhere
    public void FollowPlayer()
    {
        myAnim.SetBool("IsMoving", true);
        myAnim.SetFloat("MoveX", (target.position.x - transform.position.x));
        myAnim.SetFloat("MoveY", (target.position.y - transform.position.y));
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    //  Have the Skeleton move back to its spawn point
    public void GoHome()
    {
        myAnim.SetFloat("MoveX", (homepos.position.x - transform.position.x));
        myAnim.SetFloat("MoveY", (homepos.position.y - transform.position.y));
        transform.position = Vector3.MoveTowards(transform.position, homepos.position, speed * Time.deltaTime);

        //  Tell the Skeleton to stop moving once its reaches its home position
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
