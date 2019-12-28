using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataControl : MonoBehaviour
{
    public static DataControl ornek;

    private const string high_score = "High Score";
    private void Awake()
    {
        TekilNesne();
        oyunilkdefabasladi();
    }

    void TekilNesne()
    {
        if (ornek!=null) //script baska yerden kullanılıyor ise
        {
            Destroy(gameObject); //objeyi yok et
        }
        else
        {
            ornek = this; //kullanılmıyor ise bu scripti kullan
            DontDestroyOnLoad(gameObject); //objeyi yok etme
        }

    }

    void oyunilkdefabasladi()
    {
        if (PlayerPrefs.HasKey("oyunilkdefabasladi")) //calisip calismadigi kontrol ediliyor
        {
            PlayerPrefs.SetInt(high_score,0); //calismadiysa score sıfır oluyor
            PlayerPrefs.SetInt("oyunilkdefabasladi",0); //score ekleniyor
        }

    }

    public void setHighScore(int score)
    {
        PlayerPrefs.SetInt(high_score,score); //dataya score kayıt ediliyor

    }

    public int getHighScore()
    {
        return PlayerPrefs.GetInt(high_score); //dataya yüksek skor kayıt ediliyor

    }
}
