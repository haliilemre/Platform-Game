using UnityEngine;
public class TriggerKontrolü : MonoBehaviour
{
    [SerializeField] GameObject oyuncu;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        oyuncu.GetComponent<OyuncuKontrolü>().oyuncuZeminde = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        oyuncu.GetComponent<OyuncuKontrolü>().oyuncuZeminde = false;
    }
    


}
