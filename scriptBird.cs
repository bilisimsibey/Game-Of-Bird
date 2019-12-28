using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptBird : MonoBehaviour
{
    public static scriptBird instance; //başka scriptlerden public değişkenlere erişim sağlamamıza yarayan değişken

    [SerializeField] 
    Rigidbody2D birdRigidbody=null;
    [SerializeField]
    Animator birdAnim=null;

    public bool didFlap;
    public bool isAlive;

    float speed = 3f;
    float BounceSpeed = 4f;

    public AudioSource audiosource;
    public AudioClip died;
    public AudioClip ping;
    public AudioClip flybird;
    public int score;


    private void Awake()
    {
        if (instance==null) //başka bir scriptten kontrol sağlanmnıyor ise
        {
            instance = this; //bu scripti kullan
        }
        isAlive = true;

        SetCameraX();
    }

    private void FixedUpdate()
    {
        if (isAlive)
        {
            Vector3 temp=transform.position;
            temp.x += speed * Time.deltaTime;
            transform.position = temp;
            if (didFlap)
            {
                didFlap = false;
                birdRigidbody.velocity = new Vector2 (0,BounceSpeed);
                birdAnim.SetTrigger("flapblue");
                audiosource.PlayOneShot(flybird);
               
            }
            if (birdRigidbody.velocity.y>=0)
            {
                transform.rotation = Quaternion.Euler(0,0,0);
            }
            else
            {
                float angle = 0;
                angle = Mathf.Lerp(0,-90,-birdRigidbody.velocity.y/7);
                transform.rotation = Quaternion.Euler(0,0,angle);
            }
        }
    }

    public void fly()
    {
        didFlap = true;

    }

    public float GetPositionX()
    {
        return transform.position.x;
    }
    
    void SetCameraX()
    {
        scriptCamera.setX = (Camera.main.transform.position.x - transform.position.x)-1f;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Ground" || collision.gameObject.tag=="Pipe")
        {
            if (isAlive)
            {
                isAlive = false;
                birdAnim.SetTrigger("diedblue");

                GamePlayControl.ornek.SkoruGoster(score);

                audiosource.PlayOneShot(died);

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="PipeHolder")
        {
            score++;
            GamePlayControl.ornek.SetScore(score);
            audiosource.PlayOneShot(ping);
            
        }
    }
}
