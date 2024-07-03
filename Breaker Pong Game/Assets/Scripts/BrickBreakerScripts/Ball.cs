using UnityEngine;

namespace BrickBreakerScripts
{
    public class Ball : MonoBehaviour
    {
        public float speed ;

        private bool isTouched = false;
        private Vector2 direction;
        private Rigidbody2D rb;
        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            ResetBall();
        }
        
        private void OnEnable()
        {
            BusSystem.ResetBall += ResetBall;
        }

        private void OnDisable()
        {
            BusSystem.ResetBall -= ResetBall;
        }

        // Update is called once per frame
        void Update()
        {
            // Topu belirli bir hızda hareket ettir
            rb.velocity = direction * speed;
            IsBallTouched();
        }
    
        void ResetBall()
        {
            speed = 7f;
            isTouched = false;
            // Topu ortalayıp rastgele bir yöne hareket ettir
            transform.position = new Vector3(0,-3,0);
            float angle = Random.Range(3.5f,6);
            direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)).normalized;
            rb.velocity = direction * speed;
        }
    
        void IsBallTouched()
        {
            if (isTouched == false)
            {
                speed = 7f;
            }else if (isTouched == true)
            {
                speed = 13f;
            }
        }
    
        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.name == "Player")
            {
                isTouched = true;
                float angle = Random.Range(0.5f,2.5f);
                direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)).normalized;
                rb.velocity = direction * speed;
            }
            else if (collision.gameObject.name == "GameOver Wall")
            {
                if (gameObject.name is "Ball")
                {
                    isTouched = false;
                    speed = 5f;
                    ResetBall();
                    BusSystem.ReduceScore();
                }
                else if (gameObject.name is "Ball(Clone)")
                {
                    Destroy(gameObject);
                }

                
            }
            else if (collision.gameObject.name is "Brick")
            {
                Vector2 normal = collision.GetContact(0).normal;
                direction = Vector2.Reflect(direction, normal).normalized;
                rb.velocity = direction * speed;
                Destroy(collision.gameObject);
                BusSystem.PowerBallSpawner(collision.gameObject.transform.position);
                BusSystem.AddScore();
                BusSystem.BrickReducer();
                if (GridManager.childCount == 0 && GridManager.gridNumber < 3)
                {
                    BusSystem.LevelFinish();
                }
            
            }
            else
            {
                // Yukarıdaki koşullar dışındaki her durumda çarpma normalini kullanarak topun gideceği yönü hesaplama 
                Vector2 normal = collision.GetContact(0).normal;
                direction = Vector2.Reflect(direction, normal).normalized;
                rb.velocity = direction * speed;
            }
        
        
        }
    }
}
