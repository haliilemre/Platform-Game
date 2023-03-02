using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SeviyeKontrol : MonoBehaviour
{
    [SerializeField] Text puandeger;

    private void Start()
    {
        puandeger = GameObject.Find("puan yazi degeri").GetComponent<Text>();
    }

    public void yeniBolum()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // aktif olan sahneden bir sonraki sahneyi yüklemeyi sağlar.
    }

    public void tekrarOyna()
    {
        Time.timeScale = 1; // tekrar oynaya basıldığında zaman ölçeği 1 olur ve tekrar oynamaya başlayabiliriz.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // aktif sahneyi tekrardan yüklemeyi sağlar.

    }

    public void CikisPaneli(string ustPanel)
    {
        //GameObject.Find(ustPanel).SetActive(false);
        SceneManager.LoadScene("AnaMenu");
    }

    public void PuanEkle(int puan)
    {
        int puanyazidegeri = int.Parse(puandeger.text); // paun degerindeki texti üzerinde işlem yapabilmek için int değerine çeviriyoruz
        puanyazidegeri += 100; // düsman öldürünce puandeğerimiz 100 artacak
        puandeger.text = puanyazidegeri.ToString(); // puandeğerimizi string e çevirerek yazı şeklinde görünmesini sağlıyoruz
    }
}
