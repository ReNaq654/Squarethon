using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    public PlayerMovement movement;

    public PlayerFollow follow;

    private SpriteRenderer sprite;

    public float restartDelay = 1f;


    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Barrier")
        {
            Die();
        }
    }

    void Die()
    {
        sprite.enabled = false;
        movement.enabled = false;
        follow.enabled = false;
        Invoke(nameof(Restart), restartDelay);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
