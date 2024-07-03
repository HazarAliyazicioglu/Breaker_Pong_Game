using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;

namespace BrickBreakerScripts
{
    public class Player : MonoBehaviour
    {
        public float speed = 600;
        public Vector3 scale;

        private GameObject ball;
        private int gridNumber;
        private bool hasPower;
        private Vector2 move;
        private Rigidbody2D rb;

        // Start is called before the first frame update
        void Start()
        {
            gridNumber = GridManager.gridNumber;
            hasPower = false;
            scale = transform.localScale;
            rb = GetComponent<Rigidbody2D>();
            PlayerReset();
        }

        private void OnEnable()
        {
            BusSystem.PlayerReset += PlayerReset;
        }

        private void OnDisable()
        {
            BusSystem.PlayerReset -= PlayerReset;
        }

        // Update is called once per frame
        void Update()
        {
            move = new Vector2(Input.GetAxisRaw("Horizontal"), rb.velocity.y);
            PowerRemove();
        }

        private void FixedUpdate()
        {
            PlayerMovement();
        }

        private void OnCollisionEnter2D(Collision2D collider)
        {
            if (collider.gameObject.name is "Right Wall" or "Left Wall")
            {
                rb.velocity = Vector2.zero;
            }

            switch (collider.gameObject.name)
            {
                case "FastBall(Clone)":
                    StartCoroutine(FastBallEffect());
                    Destroy(collider.gameObject);
                    break;
                case "SlowBall(Clone)":
                    StartCoroutine(SlowBallEffect());
                    Destroy(collider.gameObject);
                    break;
                case "ExpandBall(Clone)":
                    StartCoroutine(ExpandBallEffect());
                    Destroy(collider.gameObject);
                    break;
                case "ShrinkBall(Clone)":
                    StartCoroutine(ShrinkBallEffect());
                    Destroy(collider.gameObject);
                    break;
                case "MultipleBall(Clone)":
                    ball=Instantiate(PowerBallManager.instance.ball, PowerBallManager.instance.ball.transform.position,Quaternion.identity);
                    Destroy(collider.gameObject);
                    break;
            }
        }
    

    void PlayerMovement()
    {
        rb.velocity = Vector2.zero;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(move.x * speed * Time.deltaTime, rb.velocity.y);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(move.x * speed * Time.deltaTime, rb.velocity.y);
        }
    }

    void PlayerReset()
    {
        transform.position = new Vector2(0, -9);
        speed = 600;
        transform.localScale = scale;
        BusSystem.ResetScore();
    }


    IEnumerator FastBallEffect()
    {
        Debug.Log("Effect started");
        hasPower = true;
        speed = 800;
        yield return new WaitForSeconds(10f);
        speed = 600;
        hasPower = false;
        Debug.Log("Effect ended");
    }

    IEnumerator SlowBallEffect()
    {
        Debug.Log("Effect started");
        hasPower = true;
        speed = 400;
        yield return new WaitForSeconds(10f);
        hasPower = false;
        speed = 600;
        Debug.Log("Effect ended");
    }

    IEnumerator ExpandBallEffect()
    {
        Debug.Log("Effect started");
        hasPower = true;
        transform.localScale = new Vector3(scale.x * 2, scale.y, scale.z);
        yield return new WaitForSeconds(10f);
        transform.localScale = scale;
        hasPower = false;
        Debug.Log("Effect ended");
    }

    IEnumerator ShrinkBallEffect()
    {
        Debug.Log("Effect started");
        hasPower = true;
        transform.localScale = new Vector3(scale.x / 2, scale.y, scale.z);
        yield return new WaitForSeconds(10f);
        transform.localScale = scale;
        hasPower = false;
        Debug.Log("Effect ended");
    }

    void PowerRemove()
    {
        if (gridNumber < GridManager.gridNumber)
        {
            StopCoroutine(FastBallEffect());
            StopCoroutine(SlowBallEffect());
            StopCoroutine(ExpandBallEffect());
            StopCoroutine(ShrinkBallEffect());
            Destroy(ball);
            gridNumber = GridManager.gridNumber;
        }
    }
}

}