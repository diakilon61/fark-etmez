using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class karakterkontrol : MonoBehaviour
{
    
    public float hiz;
    public Animator animasyoncum;
    private int altin_miktari;
    private int mucevher_miktari;
    public Text text_altin_miktari;
    public Text mucevher_miktari_text;
    public GameObject pnl_oyunsonu;
    public Text text_oyunsonu_altın_mik;
    public Text text_oyunsonu_mucevher_miktari;
    public static bool Oyun_Basladımı = false;
    public GameObject pnl_Oyun_bası;
    public AudioSource altin_toplama_sesi;
    public AudioSource cokaltin_toplama_sesi;
    public bool ates;
    public bool ates_balta;
    
    float horizontal;
    bool oldum_mu_hareketi_durdur = false;
    public int canhakki = 3;
    public GameObject elTutma;
    List<GameObject> yokEdilecekler = new List<GameObject>();
    public List<GameObject> tasinabilen_objeler = new List<GameObject>();

    public Button kutu_tutma;
    public float kutu_atma_gucu_yukari;
    public float kutu_atma_gucu_ileri;
  


    public int kacinci_level = 1;
    public Transform ates_nesnesi;
    public GameObject mermi;
    public float mermi_sikma_hizi = 4f;
    float mermi_sikma_hiz_aktif = 0;

    float balta_atma_hizi_aktif = 0;
    public GameObject balta;
    public float balta_atma_hizi=4f;
    public Transform ates_nesnesi_balta;

    public GameObject startpozisyonu;
    GameObject checkpoint_hafızadaki;

    public static bool duvarziplamasi;

    public GameObject bton2;
    public GameObject bton2_sag;
    public RaycastHit2D kutum;
    public LayerMask layers;


    void Start()
    {

        Oyun_Basladımı = false;
        transform.position = startpozisyonu.transform.position;
        elTutma.SetActive(false);
        kutu_tutma = FindInActiveObjectByName("el_tutma").GetComponent<Button>();
        bton2.SetActive(false);
        bton2_sag.SetActive(false);
    }


    void Update()
    {
        if (oldum_mu_hareketi_durdur == true)
        {
            return;
        }
        if (mermi_sikma_hiz_aktif > 0)
        {
            mermi_sikma_hiz_aktif -= Time.deltaTime;
        }
        if(balta_atma_hizi_aktif > 0)
        {
            balta_atma_hizi_aktif -= Time.deltaTime;

        }
        if (Input.GetKeyDown(KeyCode.F) && mermi_sikma_hiz_aktif <= 0)
        {
            ates = true;

            mermi_sikma_hiz_aktif = mermi_sikma_hizi;

            GameObject go = Instantiate(mermi, ates_nesnesi.transform.position, new Quaternion());
            if (transform.localScale.x < 0)
            {

                go.GetComponent<mermi_hareket>().mermi_sola_git();
            }

        }
        else
        {
            ates = false;
        }
        animasyoncum.SetBool("ates", ates);
        if(Input.GetButtonDown("balta_firlat") && balta_atma_hizi_aktif <= 0)
        {
            ates_balta = true;

            balta_atma_hizi_aktif = balta_atma_hizi;

            GameObject go = Instantiate(balta, ates_nesnesi_balta.transform.position, new Quaternion());
            if (transform.localScale.x < 0)
            {
                //koda erısme icin
                go.GetComponent<balta_firlatma>().balta_sola_git();
            }


        }
        else
        {
            ates_balta = false;
        }

    
    }
  
    void FixedUpdate()
    {
        if (Oyun_Basladımı == false)
        {
            return;
        }
        if (oldum_mu_hareketi_durdur == true)
        {
            return;
        }
   
 

        //float horizontal = Input.GetAxis("Horizontal");
        transform.position += new Vector3(horizontal * hiz * Time.deltaTime, 0, 0);
        bool kosuyormuyum = false;

        if (horizontal != 0)
        {
            kosuyormuyum = true;
            animasyoncum.speed = Mathf.Abs(horizontal);
        }
        else
        {
            animasyoncum.speed = Mathf.Abs(1);
        }


        animasyoncum.SetBool("kosuyormuyum", kosuyormuyum);

        if (horizontal > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);

            RaycastHit2D carptı = Physics2D.Raycast(transform.position, Vector2.right, 30f,layers);
            if (carptı.collider != null)
            {
                print("kutuya cartı");
                bton2.SetActive(true);
                kutum = carptı;
                kendine_cek();
                kutum.collider.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

                

            }
            else if (carptı.collider == null)
            {
                bton2.SetActive(false);

            }



        }
        else if (horizontal < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);

            RaycastHit2D carptı = Physics2D.Raycast(transform.position, Vector2.left, 30f, layers);
            if (carptı.collider != null)
            {
                print("kutuya cartı");
                bton2_sag.SetActive(true);
                kutum = carptı;
                kendine_cek_sag();
                kutum.collider.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

            }

            else if (carptı.collider == null)
            {
                bton2_sag.SetActive(false);
            }

        }



    }
    GameObject FindInActiveObjectByName(string name)
    {
        Transform[] objs = Resources.FindObjectsOfTypeAll<Transform>() as Transform[];
        for (int i = 0; i < objs.Length; i++)
        {
            if (objs[i].hideFlags == HideFlags.None)
            {
                if (objs[i].name == name)
                {
                    return objs[i].gameObject;
                }
            }
        }
        return null;
    }
    /// <summary>
    /// //////////////////////
    /// </summary>
    public void Balta_firlat()
    {
        if (  balta_atma_hizi_aktif <= 0)
        {
            ates_balta = true;

            balta_atma_hizi_aktif = balta_atma_hizi;

            GameObject go = Instantiate(balta, ates_nesnesi_balta.transform.position, new Quaternion());
            if (transform.localScale.x < 0)
            {
                //koda erısme icin
                go.GetComponent<balta_firlatma>().balta_sola_git();
            }




        }
        else
        {
            ates_balta = false;
        }
    }

    public void hareket(int miktar)
    {
        horizontal = miktar;
    }
    public void kendine_cek()
    {
        kutum.collider .GetComponent<Rigidbody2D>().velocity = new Vector2(-55, 10);
        
    }
    public void kendine_cek_sag()
    {
        kutum.collider.GetComponent<Rigidbody2D>().velocity = new Vector2(55, 0);
        print("sagacektim");
    }

    void OnTriggerEnter2D(Collider2D carpilan_nesne)
    {
        if (carpilan_nesne.tag == "altin")
        {
            altin_miktari++;
            text_altin_miktari.text = altin_miktari.ToString();
            altin_toplama_sesi.Play();
            Destroy(carpilan_nesne.gameObject);


        }
        else if (carpilan_nesne.tag == "kapi")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            if (PlayerPrefs.GetFloat("level") < kacinci_level)
            {
                PlayerPrefs.SetInt("level", kacinci_level);
            }
        }
        else if (carpilan_nesne.tag == "altinlar")
        {
            mucevher_miktari++;
            mucevher_miktari_text.text = mucevher_miktari.ToString();
            cokaltin_toplama_sesi.Play();
            Destroy(carpilan_nesne.gameObject);
        }
        else if (carpilan_nesne.tag == "cekpoint")
        {
            checkpoint_hafızadaki = carpilan_nesne.gameObject;

        }
        else if (carpilan_nesne.tag == "tuzaklar")
        {

            olme();
        }
        // burda kaldık dusen zemın kod saglam unıty bozuk mk
        else if (carpilan_nesne.tag == "dusen_zemin")
        {
            // carpilan_nesne.GetComponent<Rigidbody2D>().simulated = true
            carpilan_nesne.gameObject.SetActive(false);
        }
        else if (carpilan_nesne.CompareTag("patlatılabilir")) yokEdilecekler.Add(carpilan_nesne.gameObject);
    }
    void OnTriggerStay2D(Collider2D carpilanNesne)
    {
        if (carpilanNesne.CompareTag("patlatılabilir")) elTutma.SetActive(true);
        else if (carpilanNesne.CompareTag("anahtar")) { elTutma.gameObject.SetActive(true); }
        else if (carpilanNesne.CompareTag("kutu"))
        {
            elTutma.gameObject.SetActive(true);

        }
    }
    void OnTriggerExit2D(Collider2D carpilan_nesne)
    {
        if (carpilan_nesne.CompareTag("patlatılabilir"))
        {
            elTutma.SetActive(false);
            yokEdilecekler.Remove(carpilan_nesne.gameObject);
        }
        else if (carpilan_nesne.CompareTag("anahtar")) elTutma.SetActive(false);
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag.Equals("duvar"))
        {
            duvarziplamasi = true;
        }
        else duvarziplamasi = false;
        if (coll.gameObject.CompareTag("patlatılabilir")) yokEdilecekler.Add(coll.gameObject);
        if (coll.gameObject.CompareTag("kutu"))
        {
            bool varmi = false;
            foreach (GameObject herbiri in tasinabilen_objeler)
            {
                if (herbiri == coll.gameObject) varmi = true;
            }
            if (!varmi) tasinabilen_objeler.Add(coll.gameObject);
        }
    }
    void OnCollisionStay2D(Collision2D carpilanNesne)
    {
        if (carpilanNesne.gameObject.CompareTag("patlatılabilir"))
        {
            elTutma.SetActive(true);
        }
        if (carpilanNesne.gameObject.CompareTag("kutu"))
        {
            elTutma.SetActive(true);
           
        }
    }
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("patlatılabilir"))
        {
            elTutma.SetActive(false);
            yokEdilecekler.Remove(col.gameObject);
        }
        if (col.gameObject.CompareTag("kutu"))
        {
            elTutma.SetActive(false);
            tasinabilen_objeler.Remove(col.gameObject);

        }
    }
    public void Oyun_basladımı()
    {

        Oyun_Basladımı = true;

        pnl_Oyun_bası.SetActive(false);

    }
    void cekpoint_cagirma()
    {
        if (checkpoint_hafızadaki != null)
        {
            animasyoncum.SetBool("karakter_oldumu", false);
            transform.position = checkpoint_hafızadaki.transform.position;

            oldum_mu_hareketi_durdur = false;
        }
        else if (checkpoint_hafızadaki == null)
        {
            animasyoncum.SetBool("karakter_oldumu", false);
            transform.position = startpozisyonu.transform.position;

            oldum_mu_hareketi_durdur = false;
        }

    }
    void olme()
    {

        if (canhakki > 0)
        {
            canhakki--;
            animasyoncum.SetBool("karakter_oldumu", true);
            oldum_mu_hareketi_durdur = true;
            Invoke("cekpoint_cagirma", 1);

        }
        else if (canhakki <= 0)
        {
            oldum_mu_hareketi_durdur = true;
            animasyoncum.SetBool("karakter_oldumu", true);
            Invoke("ol", 1);
        }


    }
    void ol()
    {
        Destroy(gameObject);
        pnl_oyunsonu.SetActive(true);
        text_oyunsonu_altın_mik.text = text_altin_miktari.text;
        text_oyunsonu_mucevher_miktari.text = mucevher_miktari_text.text;

    }
    public void YokEtme()
    {
    
        foreach (GameObject herbiri in yokEdilecekler)
        {
            Destroy(herbiri);
        }


    }

    public void Tutma()
    {

         foreach (GameObject herbiri in tasinabilen_objeler )
        {
            herbiri.GetComponent<Rigidbody2D>().velocity = (new Vector2(0, 0));
            if (herbiri.transform.position.x > transform.position.x && kutu_tutma == true)
            {

                herbiri.GetComponent<Rigidbody2D>().AddForce(new Vector2(kutu_atma_gucu_ileri, kutu_atma_gucu_yukari));
              
            }
            else if (herbiri.transform.position.x < transform.position.x && kutu_tutma == true)
            {
                
                herbiri.GetComponent<Rigidbody2D>().AddForce(new Vector2(-kutu_atma_gucu_ileri, kutu_atma_gucu_yukari));

            }             
        }
        
    }
}


