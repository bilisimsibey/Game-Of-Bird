using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptTemizlikci : MonoBehaviour
{
    private GameObject[] backGround;
    private GameObject[] ground;
    private float lastBGX;
    private float lastGrodundX;

    private void Awake()
    {
        backGround = GameObject.FindGameObjectsWithTag("BackGround");
        ground = GameObject.FindGameObjectsWithTag("Ground");

        lastBGX = backGround[0].transform.position.x;
        lastGrodundX = ground[0].transform.position.x;

        for (int i = 1; i < backGround.Length; i++)
        {
            if (lastBGX<backGround[i].transform.position.x)
            {
                lastBGX = backGround[i].transform.position.x;
            }
        }

        for (int i = 0; i < ground.Length; i++)
        {
            if (lastGrodundX<ground[i].transform.position.x)
            {
                lastGrodundX = ground[i].transform.position.x;

            }
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="BackGround")
        {
            Vector3 temp = collision.transform.position; //vector3 türünde değişken tanımladık ve değer objenin değerlerini aktardır
            float genislik = ((BoxCollider2D)collision).size.x; //float türünde değişken tanımladık ve değen objenin boxcollider.x değerlerini aktardır
            temp.x = genislik + lastBGX; //vector3 değişkenimizin x değerine yeni değer atadık
            collision.transform.position = temp; //değen objenin değerlerini değiştirdik
            lastBGX = temp.x; //sonraki background yüklenmesi için eşitledik
            
        }
        else if (collision.tag == "Ground")
        {
            Vector3 temp = collision.transform.position;
            float genislik = ((BoxCollider2D)collision).size.x;
            temp.x = genislik + lastGrodundX;
            collision.transform.position = temp;
            lastGrodundX = temp.x;
        }
    }
}
