using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AraSahneManager : MonoBehaviour
{
    public Text CanText;
    public string sahneAdi;

    private void Awake()
    {
        CanText.text = LifeManager.globalErisim.kalanCan.ToString();

        sahneAdi = LifeManager.globalErisim.sahneAdi;
        StartCoroutine(SahneYukleyici());
    }
    public IEnumerator SahneYukleyici() 
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(sahneAdi);
    }
}
