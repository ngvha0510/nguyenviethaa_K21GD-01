using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float speed;
    private float currentPosX;
    private Vector3 velocity = Vector3.zero;

    [SerializeField] private Transform Player;
    [SerializeField] private float aheadDistance;
    [SerializeField] private float cameraspeed;
    private float lookahead;

    private void Update()
    {
        //transform.position = Vector3.SmoothDamp(transform.position, new Vector3(currentPosX, transform.position.y, transform.position.z), ref velocity, speed);

        transform.position = new Vector3(transform.position.x, Player.position.y + lookahead, transform.position.z);
        lookahead = Mathf.Lerp(lookahead, (aheadDistance * Player.position.y), Time.deltaTime * cameraspeed);
     
    }

    public void MoveToNewRoom(Transform _newRoom)
    {
        currentPosX = _newRoom.position.y;
    }
}
