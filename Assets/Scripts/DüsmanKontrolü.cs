using UnityEngine;

public class DüsmanKontrolü : MonoBehaviour
{
    [SerializeField] bool zeminUstunde; // objenin zemin üzerinde olup olmadığını kontrolünü yapabiliriz.
    [SerializeField] float tuzakhiz;
    private float genislik;
    private Rigidbody2D düsmanBeden;
    [SerializeField] LayerMask engel; // ışının hangi katmanlarda çalıştığını belirliyoruz.
    [SerializeField] float hiz;
    private static int toplamdüsmansayi=0; // toplam düşman sayısını düsmankontrolü scripts de yazarak bu scripts'e sahip düsmanların sayısını belirlemeye yardımcı olacak

    // Start is called before the first frame update
    void Start()
    {
        toplamdüsmansayi++; // oyun başladığında kaç düşman olduğunu sayması için, başlangıçta oluşan düşman sayısı kadar artıyor
        //Debug.Log("Düşman ismi:"+gameObject.name+"Oyundaki toplam Düşman Sayısı:"+ toplamdüsmansayi); // handi düşmanın önce oluştuğu ve adını konsolda görmek için yazılan kod
        genislik = GetComponent<SpriteRenderer>().bounds.extents.x; // 
        düsmanBeden = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()

    {
        
        #region ışının blok üstünde sınırlarını ve şartlarını ayarlıyoruz
        RaycastHit2D hit = Physics2D.Raycast(transform.position + (transform.right * genislik / 2), Vector2.down, 2f, engel); // RaycastHit2d: bir ışın çıkararak bu ışının çarpma kontrolünü sağlar. physics2d.raycast: ışının çizilmesine yarar.

        if (hit.collider != null)// eğer ışın biyere çarpmıyorsa düsman1 zeminin üzerindedir. 
        {
            zeminUstunde = true;
        }
        else
        {
            zeminUstunde = false;
        }

        Döndür();
        #endregion 
    }

    #region gizmos çizme 
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 gercekPozisyon = transform.position + (transform.right * genislik / 2); // çizgiyi objenin tam ortasındaydı. bu çizgiyi 
        Gizmos.DrawLine(gercekPozisyon, gercekPozisyon + new Vector3(0, -2f, 0)); // çizginin nereden hangi noktaya olduğunu belirledik.
    }
    #endregion

    #region düsman1'e hareket kazandırıyoruz
    void Döndür()
    {
        if (!zeminUstunde) // obje eğer zemin üstünde değilse 180 derece dönecek ve sağa sola hareketlenme işlemi bu sayede gerçekleşecek.
        {
            transform.eulerAngles += new Vector3(0, 180f, 0);
        }
        düsmanBeden.velocity = new Vector2(transform.right.x * hiz, 0f); // düsman1'e hareket kazandırıyoruz.
    }
    #endregion


    
}
