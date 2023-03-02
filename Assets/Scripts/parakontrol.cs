using UnityEngine;
using UnityEngine.UI;

public class parakontrol : MonoBehaviour
{
    [SerializeField] float parahiz;
    [SerializeField] float tuzakhiz;
    [SerializeField] Text puandeger;
    private void Update()
    {
        transform.Rotate(new Vector3(0f, parahiz, 0f)); // paranın y ekseninde 20 birim hızla dönmesini sağlar
        transform.Rotate(new Vector3(tuzakhiz, tuzakhiz, 0f));// dönen tuzağın dönme hızını ayarlıyoruz)
        

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Oyuncu"))
        {
            /* int puanyazidegeri = int.Parse(puandeger.text); // paun degerindeki texti üzerinde işlem yapabilmek için int değerine çeviriyoruz
            puanyazidegeri += 50; // karakterimiz paraya değerse puandeğerimiz 50 artacak
            puandeger.text = puanyazidegeri.ToString(); // puandeğerimizi string e çevirerek yazı şeklinde görünmesini sağlıyoruz */
            GameObject.Find("Seviye Kontrol").GetComponent<SeviyeKontrol>().PuanEkle(50);

            Destroy(gameObject);
        }
    }

}
