using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    [SerializeField] private float speed = 0.5f;
    [SerializeField] private float movement;

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        movement = speed * Time.deltaTime * 10;
        
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (transform.position.y >= 3.1)
            {
                transform.position = new Vector3(transform.position.x,3.1f,transform.position.z);
            }
            else
            {
                transform.position = new Vector3(transform.position.x,transform.position.y + movement,transform.position.z);
            }
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (transform.position.y <= -3.8)
            {
                transform.position = new Vector3(transform.position.x,-3.8f,transform.position.z);
            }
            else
            {
                transform.position = new Vector3(transform.position.x,transform.position.y - movement,transform.position.z);
            }
        }
    }
}
