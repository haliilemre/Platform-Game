using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kamerakontrol : MonoBehaviour
{

    Transform oyuncuyeri;
    [SerializeField] float minX, maxX;
    // Start is called before the first frame update
    void Start()
    {
        oyuncuyeri = GameObject.Find("Oyuncu").transform; // oyuncunun yerini belirleyip oyuncuyeri değişkenine gönderiyoruz
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(oyuncuyeri.position.x,minX,maxX),transform.position.y,transform.position.z); 
        // üsteki kod: kameranın oyuncumuzun x değerlerini takip ederek hareket etmesini sağlıyor Mathf.Clamp metodu ile fakat verdiğimiz minimum ve maximum x değerleninin dışına çıkmadan
    }
}
