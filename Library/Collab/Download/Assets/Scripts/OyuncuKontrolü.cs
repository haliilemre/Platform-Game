using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // bu kütüphaneyi ok sayısını ekranda göstermek için gerekli kodları yazmada kullanıyoruz

public class OyuncuKontrolü : MonoBehaviour
{
    /*
    oyuncu ya tıkladığında sağ kısımda order layer var zeminin layer ı sıfır olduğu için karakterin kini 1 yapınca karakterin ayaklarının zemine girmesi engellendi

     */
    private float oyuncuHızıX;
    [SerializeField] float hız;
    [SerializeField] float ziplamagücü;// ziplama gücü diye bir değişken oluşturarak unity arayüzünden kontrol edebilme sağlandı
    private Rigidbody2D oyuncuBeden;
    private Vector3 temelLocalScale;
    public bool oyuncuZeminde; // Zemin üzerinde mi değil mi kontrolü
    private bool ciftZiplayabilme;
    [SerializeField] GameObject okObjesi;
    [SerializeField] bool atisYapildi; //player objesine atak özelliği ekliyoruz (durum kontrolü için)
    [SerializeField] float guncelAtisSüresi;
    [SerializeField] float temelAtisSayaci; // sayaç ve atağı kontrol etme işlemi...
    private Animator animasyonum; // animatörden değer almak için animasyonum değişkeni oluşturuyoruz
    [SerializeField] int oksayisi; // okları saymak için bir değişken oluşturuyoruz
    [SerializeField] Text oksayisigörünüm; // ok sayısını ekranda göstermek için oksayisigörünüm adında text değişkeni oluşturuyoruz
    [SerializeField] AudioClip ölümmüzik;

    // Start is called before the first frame update
    void Start()
    {
        
        atisYapildi = false;
        animasyonum = gameObject.GetComponent<Animator>(); // animasyonum değerine animatörümüzdeki değeri atayarak her seferinde yazma zorluğundan kurtuluyoruz
        oyuncuBeden = GetComponent<Rigidbody2D>();
        temelLocalScale = transform.localScale;
        oksayisigörünüm.text = oksayisi.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        #region oyuncuya hareket kazandırma...
        oyuncuHızıX = Input.GetAxis("Horizontal"); // -1 ile 1 arasında sağ-sol ok tuşlarına basılma süresine göre değerler gelir.
        animasyonum.SetFloat("Hiz", Mathf.Abs(oyuncuHızıX)); // mathf.abs yönün mutlak değerini alıyor, bu kod ile yönümüzün hızını Hiz değişkenine gönderiyoruz
        oyuncuBeden.velocity = new Vector2(oyuncuHızıX * hız, oyuncuBeden.velocity.y);
        #endregion

        #region oyuncunun sağ ve sol hareket yönüne göre yüzünün dönmesi
        if (oyuncuHızıX > 0)
        {
            transform.localScale = new Vector3(temelLocalScale.x, temelLocalScale.y, temelLocalScale.z);
        }
        else if (oyuncuHızıX < 0)
        {
            transform.localScale = new Vector3(-temelLocalScale.x, temelLocalScale.y, temelLocalScale.z); // oyunda sol yön tuşuna bastığımızda karakterin x ekseninde sola dönmesini sağladık.
        }
        #endregion

        #region oyuncunun zıplamasıyla ilgili kontroller
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (oyuncuZeminde== true)
            {
                oyuncuBeden.velocity = new Vector2(oyuncuBeden.velocity.x, ziplamagücü); 
                animasyonum.SetTrigger("Ziplama"); // boşluk tuşuna bastığımızı ziplama değişkenine ileten kod
                ciftZiplayabilme = true;
            }
            else
            {
                if (ciftZiplayabilme == true)
                {
                    oyuncuBeden.velocity = new Vector2(oyuncuBeden.velocity.x, ziplamagücü);
                    ciftZiplayabilme = false;
                }
            }
        }
        #endregion

        #region oyuncuya ok attırıyoruz

        if (Input.GetMouseButtonDown(0) && oksayisi>0) // ok  ateş tuşuna basılınca ve ok sayımız sıfır dan büyükse atılacak
        {
            if (atisYapildi == false)
            {
                atisYapildi = true;
                animasyonum.SetTrigger("Saldir"); // farenin sol tuşuna bastığımızı saldir değişkenine ileten kod
                Invoke("Atis", 0.5f); // okun oluşma süersini yarım saniye geciktirerek ok atış animasyonu ile eş zamanlı olmasını sağlıyoruz Invoke=geciktirme kodu.
               
            }
           
        }
        #endregion
        
        #region okları birer saniye aralıklarla atabilme.. yani sürekli spam yapılmasını engelleme...
        if (atisYapildi == true)
        {
            guncelAtisSüresi -= Time.deltaTime; // birinci frame ile ikinci frame arası geçiş süresi: time.deltatime
        }
        else
        {
            guncelAtisSüresi = temelAtisSayaci; 
        }

        if (guncelAtisSüresi <= 0)
        {
            atisYapildi = false;
        }
        
        #endregion
    }

    #region Kodların her seferinde tekrarlanmaması için fonksiyon haline getirdik..
    void Atis() // Kodların her seferinde tekrarlanmaması için fonksiyon haline getirdik..
    {
        GameObject okumuz = Instantiate(okObjesi, transform.position, Quaternion.identity);
        okumuz.transform.parent = GameObject.Find("oklar").transform; // okların sol kısımda ayrı ayrı değilde oklar klosürnde gözükmesini sağlıyoruz

        if (transform.localScale.x > 0) // eğer player x eksenine göre scale'ı 0'dan büyükse ok sağa doğru gitsin.. Değilse ok sola doğru gitsin.. bu sayede player nereye dönükse ok oraya gider.
        {
            okumuz.GetComponent<Rigidbody2D>().velocity = new Vector2(5f, 0f);
        }
        else
        {
            Vector3 okumuzScale = okumuz.transform.localScale;
            okumuz.transform.localScale = new Vector3(-okumuzScale.x, okumuzScale.y, okumuzScale.z);// ok sola giderken scale'i de sola dönmesini sağlar... 
            okumuz.GetComponent<Rigidbody2D>().velocity = new Vector2(-5f, 0f);
        }
        oksayisi--; // her ok atıldığında ok sayımız 1 azalıyor
        oksayisigörünüm.text = oksayisi.ToString(); // ok sayımızın değerini ok sayısını değerini göstericek değere gönderiyoruz.
    }
    public void Ölüm()
    {
        GameObject.Find("seskontrol").GetComponent<AudioSource>().clip = null; // öldüğümüzde arka plan müziğinin durmasını sağlıyoruz
        GameObject.Find("seskontrol").GetComponent<AudioSource>().PlayOneShot(ölümmüzik);// öldüğümüzde ölüm müziğinin devreye girmesini sağlıyoruz
        animasyonum.SetFloat("Hiz", 0); // karakterin hızını 0 yapıyor
        animasyonum.SetTrigger("Ölüm"); // ölüm animasyonunun devreye girmesini sağlıyor

        

        oyuncuBeden.constraints = RigidbodyConstraints2D.FreezePosition; // karakterin sağa ve sola gitmesini engelliyor

        enabled = false; // karakter ölünce scripts devre dışı kalır
    }




    #endregion Kodların her seferinde tekrarlanmaması için fonksiyon haline getirdik..


    #region karakterimiz düşmana çarpınca ölüm animasyonu devreye girmesi
    private void OnCollisionEnter2D(Collision2D collision) //oncollision= çarpışma anında
    {
        //Debug.Log(collision.gameObject.name); kod çalışıyormu kontrol denemesi
        if (collision.gameObject.CompareTag("Düsman") || collision.gameObject.CompareTag("tuzak")) 
        {
            Ölüm();

        }
    }

    #endregion karakterimiz düşmana çarpınca ölüm animasyonu devreye girmesi











}
