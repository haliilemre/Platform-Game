using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LifeManager : MonoBehaviour
{

    public int kalanCan = 3;//kalan can değeri
    public static LifeManager globalErisim;//scripte her yerden erişebilmek için static alan tanımlıyoruz.
    public string sahneAdi;//hangi sahnede olduğunu tutuyoruz
    private void Awake()//sahnede en erken çalışan unity methodu
    {
        if (globalErisim == null) //daha önce bu scriptten static alan tanımlanmamışsa 
        { 
            globalErisim = this;//bir değişkene atıyoruz
            DontDestroyOnLoad(this.gameObject);//ve gameobjesinin yok edilmemesini bildiriyoruz (sahneler arası geçişte )
        }
        else
            Destroy(this);//eğer daha önce bu scriptten static alan tanımlanmışsa yok ediyoruz

    }
    public void CanKontrol() //her öldüğümüzde bu methodu çağırıp ara sahne kontrolü yapıyoruz
    {
        kalanCan--;//kalan canı eksiltiryoruz
        if (kalanCan != 0) //eğer sıfır değilse  sahne adını daha önceden tanımladığımız değişkene alıp ara sahneyi yüklüyoruz
        {
            sahneAdi = SceneManager.GetActiveScene().name;// sahne isminin alınması
            SceneManager.LoadScene("AraSahne");//ara sahne yüklenmesi
        }
           
        
    }
}
