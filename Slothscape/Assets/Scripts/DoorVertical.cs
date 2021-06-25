using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorVertical : MonoBehaviour
{
    private PlayerController thePlayer;
    public SpriteRenderer theSR;
    public Sprite doorOpenSprite;
    public bool doorOpen, waitingToOpen;


    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (waitingToOpen)
        {
            if (Vector3.Distance(thePlayer.followingKey.transform.position, transform.position) < 0.1f)
            {
                waitingToOpen = false;

                doorOpen = true;

                theSR.sprite = doorOpenSprite;

                thePlayer.followingKey.gameObject.SetActive(false);
                thePlayer.followingKey = null;
                Invoke("DisableCollider", 1f);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (thePlayer.followingKey != null)
            {
                thePlayer.followingKey.followTarget = transform;
                waitingToOpen = true;
            }
        }
    }

    void DisableCollider()
    {
        GetComponent<Collider2D>().enabled = false;
    }
}
