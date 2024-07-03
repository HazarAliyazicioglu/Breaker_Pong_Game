using UnityEngine;
using Random = UnityEngine.Random;

public class BallManager : MonoBehaviour
{
    public float speed = 5f;

    private bool isTouched = false;
    private Vector2 direction;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ResetBall();
    }
    
    void Update()
    {
        // Topu belirli bir hızda hareket ettir
        rb.velocity = direction * speed;
        IsBallTouched();
    }
    
    void ResetBall()
    {
        // Topu ortalayıp rastgele bir yöne hareket ettir
        transform.position = Vector2.zero;
        float angle = Random.Range(0, (2 * Mathf.PI ));
        if ( angle is > 1 and < 2)
        {
            angle = Random.Range(0, (2 * Mathf.PI ));
        }else if (angle is > 4.4f and < 5.2f)
        {
            angle = Random.Range(0, (2 * Mathf.PI ));
        }
        direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)).normalized;
        rb.velocity = direction * speed;
    }

     void IsBallTouched()
     {
         if (isTouched == false)
         {
             speed = 5f;
         }else if (isTouched == true)
         {
             speed = 12f;
         }
     }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player1")
        {
            isTouched = true;
            // Player1 adındakji gameobjesiyle çarpışma durumunda çarpma normalini kullanarak topun yeni yönünü hesaplama
            Vector2 normal = collision.GetContact(0).normal;
            float angle = Random.Range(0, (2 * Mathf.PI / 6 ));
            direction = new Vector2(Mathf.Abs(Mathf.Cos(angle)), Mathf.Abs(Mathf.Sin(angle))).normalized;
            rb.velocity = direction * speed;
        }
        else if (collision.gameObject.name == "Player2")
        {
            isTouched = true;
            // Player2 adındakji gameobjesiyle çarpışma durumunda çarpma normalini kullanarak topun yeni yönünü hesaplama
            Vector2 normal = collision.GetContact(0).normal;
            float angle = Random.Range(0, (2 * Mathf.PI / 6 ));
            direction = new Vector2(Mathf.Abs(Mathf.Cos(angle)) * -1, Mathf.Abs(Mathf.Sin(angle)) * -1).normalized;
            rb.velocity = direction * speed;
        }
        else if (collision.gameObject.name is "Goal 1" or "Goal 2")
        {
            isTouched = false;
            if (collision.gameObject.name == "Goal 1")
            {
                BusSystem.AddScoreTwo();
            }
            else
            {
                BusSystem.AddScoreOne();
            }
            // Goal 1 veya Goal 2 adındakji gameobjesiyle çarpışma durumunda ResetBall adındaki fonksiyonu çalıştırma
            speed = 5f;
            ResetBall();
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