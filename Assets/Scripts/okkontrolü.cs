using UnityEngine;
using UnityEngine.UI;

public class okkontrolü : MonoBehaviour
{
    // Quaternion.identity animasyonun dönme işlenimini sağlamak için
    [SerializeField] GameObject okanimasyon;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!(collision.gameObject.tag=="Oyuncu")) // ok oyuncu etiketi olmayan birine çarpıyorsa işlemi yapıyoruz
        {
            Destroy(gameObject);
            if (collision.gameObject.CompareTag("Düsman")) // okun düsmana çarpıp çarmadığı kontrol ediliyor
            {
                Destroy(collision.gameObject); // ok düşmana çarptıysa onu yok etsin
                GameObject.Find("Seviye Kontrol").GetComponent<SeviyeKontrol>().PuanEkle(100);
                Instantiate(okanimasyon, collision.gameObject.transform.position, Quaternion.identity); // ölen objenin tam öldüğü yerden animasyonun çıkmasını sağlıyor   
            }
        }
        if (!(collision.gameObject.tag == "Oyuncu")) //ok oyuncu etiketi olmayan birine çarpıyorsa işlemi yapıyoruz
        {
            if (collision.gameObject.CompareTag("havadazemin")) // ok havadazemin objesine çarparsa yok oluyor
            {
                Destroy(gameObject);
            }
            
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject); // oklar sahneden çıkınca silinmesi için
    }
}
