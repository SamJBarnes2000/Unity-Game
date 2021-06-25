using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableScript : MonoBehaviour
{
    public string itemType;
    public int quantity;
    private GameObject player;
    private PlayerController playerController;

    void Start ()
    {
        player = GameObject.FindWithTag("player");
        playerController = player.GetComponent<PlayerController>();

    }

}

