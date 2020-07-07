using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private GameObject player;
    private PlayerScore playerScore;

    private float minX = 0f, maxX = 199f;

    // Start is called before the first frame update
    void Awake()
    {
        player=GameObject.Find("Player");
        playerScore = player.GetComponent<PlayerScore>();
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        if (playerScore.isAlive)
        {
            Vector3 temp = transform.position;
            temp.x = player.transform.position.x;
            if (temp.x < minX)
            {
                temp.x = minX;

            }
            if (temp.x > maxX)
            {
                temp.x = maxX;

            }
            temp.y = player.transform.position.y + 2f;
            transform.position = temp;


        }
    }
}
