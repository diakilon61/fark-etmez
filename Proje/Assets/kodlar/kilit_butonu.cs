﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class kilit_butonu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
        //yukarıdaki kod kayıtlı levelleri hafızadan sılmek ıcın cıktı almadan once bunu bir kere aktıf et :
        // startın en basına yaz: PlayerPrefs.DeleteAll(); 1kere calısır oyunu kodu sonra sıl
        string isim = gameObject.name;
        int level_sirasi = int.Parse(isim);
        if ((PlayerPrefs.GetInt("level") + 1) <level_sirasi )
        {
            GetComponent<Button>().interactable = false;
        }
    }
    
    
    void Update()
    {
      

    }
}
