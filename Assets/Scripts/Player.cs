using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D mybody;
    public float Speed;
    public float JumpForce;
    public AudioSource source;
    public AudioClip Coinclip;
    public Animator anim;
    public TextMeshProUGUI scoretext;
    float score;
    float Xvalue;

    private void Update()
    {
        Xvalue = Input.GetAxisRaw("Horizontal");
        mybody.velocity = new Vector2(Input.GetAxis("Horizontal") * Speed, mybody.velocity.y);

        float Horizontalinput = Input.GetAxisRaw("Horizontal");

        //Flip
        if (Horizontalinput > 0.01f)
        {
            transform.localScale = new Vector3(-1.5f,1.5f,1.5f);
        }
        else if (Horizontalinput < -0.01f)
        {
            transform.localScale = new Vector3(1.5f,1.5f,.5f);
        }
        

        //Jump
        if (Input.GetKey(KeyCode.Space))
        {
            mybody.AddForce(Vector2.up * JumpForce * Time.deltaTime, ForceMode2D.Impulse);
        }

        
        anim.SetBool("Isrunning", Horizontalinput != 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
            {
            Destroy(collision.gameObject);
            score++;
            scoretext.text = "Score:" + score.ToString();
            }
    }
    
}
