using UnityEngine;

namespace BrickBreakerScripts
{
    public class GameOverWall : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            switch (collision.gameObject.name)
            {
                case "FastBall(Clone)":
                    Destroy(collision.gameObject);
                    break;
                case "SlowBall(Clone)":
                    Destroy(collision.gameObject);
                    break;
                case "ExpandBall(Clone)":
                    Destroy(collision.gameObject);
                    break;
                case "ShrinkBall(Clone)":
                    Destroy(collision.gameObject);
                    break;
                case "MultipleBall(Clone)":
                    Destroy(collision.gameObject);
                    break;
            }
        }
    }
}
