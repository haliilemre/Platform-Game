using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanGosterici : MonoBehaviour
{
    public Text kalancan_text;

    private void Start()
    {
        kalancan_text.text = LifeManager.globalErisim.kalanCan.ToString();
    }
}
