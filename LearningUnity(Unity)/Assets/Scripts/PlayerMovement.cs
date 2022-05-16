using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float playerSpeed = 0.005f;
    bool leftMove = false;
    bool rightMove = false;
    private Rigidbody2D rigidbody;
    float jumpVelocity = 10f;
    bool jumping = false;
    // Start is called before the first frame update
    void Awake()
    {
        rigidbody = transform.GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Tile")
        {
            jumping = false;
        }
        //jumping = false;
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = GetComponent<Rigidbody2D>().position;

        if (Input.GetKeyDown("d"))
        {
            rightMove = true;
        }
        if (Input.GetKeyDown("a"))
        {
            leftMove = true;
        }
        if (Input.GetKeyUp("d"))
        {
            rightMove = false;
        }
        if (Input.GetKeyUp("a"))
        {
            leftMove = false;
        }
        if (leftMove == true)
        {
            transform.position = new Vector3((playerPos.x - playerSpeed), playerPos.y);
        }
        if (rightMove == true)
        {
            transform.position = new Vector3((playerPos.x + playerSpeed), playerPos.y);
        }

        if (Input.GetKeyDown(KeyCode.Space) && jumping == false)
        {
            rigidbody.velocity = Vector2.up * jumpVelocity;
            jumping = true;
        }
    }

}