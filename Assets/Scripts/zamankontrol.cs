using UnityEngine;
using UnityEngine.UI;
public class zamankontrol : MonoBehaviour
{

    [SerializeField] Text zamansayidegeri;
    [SerializeField] float zaman;
    private bool oyunetkinmi;
    void Start()
    {
        oyunetkinmi = true;
        zamansayidegeri.text = zaman.ToString(); // tabeladaki zaman değerini unity üzerinden kontrol edebilmem için
    }

    // Update is called once per frame
    void Update()
    {
        if (oyunetkinmi==true && GetComponent<OyuncuKontrolü>().enabled==true) // oyun etkinse ve karakterimiz ölü değilse süre azalıcak
        { 
            zaman -= Time.deltaTime; //zamanın azalmasını sağlıyoruz
            zamansayidegeri.text = ((int)zaman).ToString(); // zamanın azaldığını tabelada görüyoruz int eklememizin sebbei tabelada tam sayı kısmını görmek istememizdir

            if (zamansayidegeri.text=="0") // zaman sayacımız 0 olursa
            {
                oyunetkinmi = false; // oyunumuzun etkin olmadığını gösteriyor
                GetComponent<OyuncuKontrolü>().Ölüm();// ölüm animasyonu devreye giriyor
            }

        }
       
    }
}
