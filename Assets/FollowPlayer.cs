using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public Transform player;
    public float followSpeed = 1;

    Vector3 startPos;
    Vector3 playerStartPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        playerStartPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerDelta = player.position - playerStartPos;
        transform.position = (startPos + playerDelta * followSpeed);
    }
}
