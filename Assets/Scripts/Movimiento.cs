using LitJson;
using TMPro;
using System.IO;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    Vector3 escala;
    float escalaX;
    float escalaY;
    public bool permiteMoverse ;
    public GameObject animacion;
    AnimationLoadManager animationLoadManager;
    public int diaActual;
    public GameObject objeto;
    public bool camina;
    public bool trigger;
    public GameObject imagen;
    public Animator animator;
    public JsonData jsonData;

    public GameObject panelOpcionesCama;

    //NPC dialogs
    public GameObject  DialogoMomC;
    public GameObject  DialogoNPC1C;
    public GameObject  DialogoNPC2C;
    public GameObject DialogoCoorp;
    public TextMeshProUGUI  DialogoMom;
    public TextMeshProUGUI  DialogoNPC1;
    public TextMeshProUGUI  DialogoNPC2;
    public TextMeshProUGUI  DialogoNino;

    public GameObject botonRegalo;
    public GameObject botonCarta;
    public GameObject botonPeriodico;


    private JSONLoaderJuego0 jsonLoader;


    void Awake()
    {
        jsonLoader = GameObject.FindObjectOfType<JSONLoaderJuego0>();
    }

    public GameObject panelOpcionesSilla;
    public GameObject panelOpcionesSillon;
    public GameObject panelOpcionesHablar;
    public GameObject panelOpcionesComer;
    public GameObject panelOpcionesDiscurso;

    //public TextMeshProUGUI buttonAlimento1;

    void Start()
    {

        trigger = false;
        objeto.SetActive(false);
        imagen.SetActive(false);
        escala = transform.localScale;
        escalaX = escala.x;
        escalaY = escala.y;

 
        if(DialogoMomC!=null)
        {
            DialogoMomC.SetActive(false);
        }
        
        if(DialogoNPC1C!=null)
        {
            DialogoNPC1C.SetActive(false);
        }

        if(DialogoNPC2C!=null)
        {
            DialogoNPC2C.SetActive(false);
        }

        if (DialogoCoorp != null)
        {
            DialogoCoorp.SetActive(false);
        }

        if (panelOpcionesCama!=null)
        {
            panelOpcionesCama.SetActive(false);
        }
        if (panelOpcionesSilla != null)
        {
            panelOpcionesSilla.SetActive(false);
        }
        if (panelOpcionesSillon != null)
        {
            panelOpcionesSillon.SetActive(false);
        }
        if (panelOpcionesHablar != null)
        {
            panelOpcionesHablar.SetActive(false);
        }
        if (panelOpcionesComer != null)
        {
            panelOpcionesComer.SetActive(false);
        }
        if (panelOpcionesDiscurso != null)
        {
            panelOpcionesDiscurso.SetActive(false);
        }

        if (File.Exists(Application.dataPath + "/Gamedata.json"))
        {
            jsonData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/Gamedata.json"));
            diaActual = (int)jsonData[0];
        }
    }



    void Update()
    {
        if(permiteMoverse)
        {
            if (File.Exists(Application.dataPath + "/Gamedata.json"))
            {
                jsonData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/Gamedata.json"));
                diaActual = (int)jsonData[0];
                
            }

            GameObject player = GameObject.Find("Personaje");

            transform.Translate(Input.GetAxis("Horizontal") * 3f * Time.deltaTime, 0f, 0f);
            transform.Translate(0f, Input.GetAxis("Vertical") * 3f * Time.deltaTime, 0f);

            if (Input.GetAxis("Horizontal") < 0)
            {
                camina = true;
                animator.SetTrigger("camina");
                escala.x = -escalaX;
            }
            if (Input.GetAxis("Horizontal") > 0)
            {
                camina = true;
                animator.SetTrigger("camina");
                escala.x = escalaX;
            }
            if (Input.GetAxis("Vertical") > 0)
            {
                camina = true;
                animator.SetTrigger("camina");
                escala.y = escalaY;
            }
            if (Input.GetAxis("Vertical") < 0)
            {
                camina = true;
                animator.SetTrigger("camina");
                escala.y = escalaY;
            }
            transform.localScale = escala;

            camina = false;
            animator.SetTrigger("dejaCaminar");
        }
       
    }

    void loadAnimation()
    {
        GameObject tempObj = new GameObject();
        tempObj = Resources.Load("an", typeof(GameObject)) as GameObject;
        if (tempObj == null)
        {
            Debug.LogError("No esta encontrando el clip de la animacion ");
        }
        else
        {
            Animation anim = animacion.GetComponent<Animation>();

            Animation animation = new Animation();
            animation = tempObj.GetComponent<Animation>();
            AnimationClip animationClip = new AnimationClip();
            animationClip = animation.clip;


            if (anim != null)
            {
                if (animationClip != null)
                {
                    anim.AddClip(animationClip, "animation");
                    anim.Play("animation");
                }
                else
                {
                    print("objeto animacion esta bien y clip es nulo");
                }
            }
            else
            {
                if (animationClip != null)
                {
                    print("Objeto animacion es nulo pero clip encontrado");
                }
                else
                {
                    print("todo es nulo");
                }

            }
        }
    }

    /**
        void OnTriggerEnter2D(Collider2D col)
        {
            GameObject fondo = GameObject.Find("Background");
            Debug.Log("Colisión con " + col.name);

            //print("El dia actual era....." + diaActual);
            if (col.name== "cama" && fondo.GetComponent<TimeDayFunction>().hora>6 && diaActual<4)
            {
                //imagen.SetActive(true);
                // if (imagen != null)
                //{
                //  StartCoroutine(imagen.GetComponent<VideoStream>().playVideo());
                //}
                //else print("es nula");

                
                animator.SetTrigger("duerme");
                
                SoundManager.PlaySound("dormir");
                permiteMoverse = false;
            }

            //loadAnimation();   
            //animationLoadManager = animacion.GetComponent<AnimationLoadManager>();
            
            //Invoke("LoadAnimataionClip", 3);

        }
     */
    

    void OnTriggerStay2D(Collider2D col)
    {
        GameObject fondo = GameObject.Find("Background");
        if (col.name == "camaClick" && fondo.GetComponent<TimeDayFunction>().hora > 18 && diaActual < 4)
        //if (col.name == "camaClick" && fondo.GetComponent<TimeDayFunction>().hora > 18 && diaActual < 4)
        {

            if (panelOpcionesCama != null)
            {
                panelOpcionesCama.SetActive(true);
            }

        }

        //PARA SENTARSE
        else if (col.name == "silla")
        {
            if (panelOpcionesSilla != null)
            {
                panelOpcionesSilla.SetActive(true);
            }

        }
        else if(col.name == "sillon")
        {

            if (panelOpcionesSillon != null)
            {
                panelOpcionesSillon.SetActive(true);
            }

        }
        


        else if (col.name == "Nevera")
        {
            if (panelOpcionesComer != null)
            {
                panelOpcionesComer.SetActive(true);
            }

        }

        


    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //PARA DORMIR
        GameObject fondo = GameObject.Find("Background");
        if (col.name == "cama" && fondo.GetComponent<TimeDayFunction>().hora < 19)
        {
            jsonLoader.darInformacion("NO TENGO GANAS DE DORMIR");
        }
        else if(col.name== "PuntoDiscurso")
        {
            if (panelOpcionesDiscurso != null)
            {
                panelOpcionesDiscurso.SetActive(true);
                botonCarta.SetActive(false);
                botonPeriodico.SetActive(false);
                botonRegalo.SetActive(false);
            }
        }
        else if (col.name == "HablarCalvo"){
            hablarNPC1();
        }
        else if (col.name == "HablarNina"){
            hablarNPC2();
        }
        //PARA HABLAR
        else if (panelOpcionesHablar != null &&col.name == "mama")
        {
            hablarMom();
        }
        if (col.name == "GameObject")
        {
            SoundManager.PlaySound("patearBalon");
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        GameObject fondo = GameObject.Find("Background");
        if (panelOpcionesCama != null)
        {
            panelOpcionesCama.SetActive(false);
        }
        else if (col.name == "HablarCalvo"){
            DialogoNPC1C.SetActive(false);
            DialogoNPC1.text = jsonLoader.dialogNPC1;
        }
        else if (col.name == "HablarNina"){
            DialogoNPC2C.SetActive(false);
            DialogoNPC2.text = jsonLoader.dialogNPC2;
        }
        else if(panelOpcionesSilla!= null && col.name =="silla")
        {
            panelOpcionesSilla.SetActive(false);
        }
        else if (panelOpcionesSillon != null && col.name =="sillon" )
        {
            panelOpcionesSillon.SetActive(false);
        }
        else if (panelOpcionesHablar != null && col.name =="mama")
        {
            DialogoMomC.SetActive(false);
        }
        else if ( col.name == "PuntoDiscurso")
        {
            panelOpcionesDiscurso.SetActive(false);
            botonCarta.SetActive(true);
            botonPeriodico.SetActive(true);
            botonRegalo.SetActive(true);
        }
        else if (panelOpcionesComer != null)
        {
            panelOpcionesComer.SetActive(false);
        }

    }

    public void OnClick(){

        GameObject fondo = GameObject.Find("Background");
                    

        if ( fondo.GetComponent<TimeDayFunction>().hora > 6 && diaActual < 4)
        {
            panelOpcionesCama.SetActive(false);
            animator.SetTrigger("duerme");

            SoundManager.PlaySound("dormir");
            permiteMoverse = false;
        }
        
    }

    public void OnClickSentarseSilla()
    {
        permiteMoverse = false;
        panelOpcionesSilla.SetActive(false);
        animator.SetTrigger("sientaSilla");        
        
    }

    public void OnClickSentarseSillon()
    {
        permiteMoverse = false;
        panelOpcionesSillon.SetActive(false);
        animator.SetTrigger("sientaSilla");    
               
    }
        

    public void OnClickHablarMama()
    {

        panelOpcionesHablar.SetActive(false);
        animator.SetTrigger("hablar");
        //permiteMoverse = false;

    }

    public void OnClickComer()
    {

        panelOpcionesComer.SetActive(false);
        GameObject camara = GameObject.Find("Main Camera");
        camara.GetComponent<JSONLoaderJuego0>().AbrirDespensa();

        //permiteMoverse = false;

    }

    public void mantenerseSentado()
    {
        animator.SetTrigger("quedarseSentado");
        
    }

    public void permitirMovimiento()
    {
        permiteMoverse = true;
    }


    public void permitirAnimacion()
    {
        trigger = true;
        objeto.SetActive(true);
                
    }

    void LoadAnimataionClip()
    {
        animationLoadManager.LoadAnimation("an", null);
    }

    public void hablarNPC1(){
        SoundManager.PlaySound("hablaCalvo");
        DialogoNPC1C.SetActive(true);
        DialogoNPC1.text = jsonLoader.dialogNPC1;
    }

    public void hablarNPC2(){
        SoundManager.PlaySound("hablaNina");
        DialogoNPC2C.SetActive(true);
        DialogoNPC2.text = jsonLoader.dialogNPC2;
    }

    public void hablarMom(){
        SoundManager.PlaySound("hablaMama");
        DialogoMomC.SetActive(true);
        DialogoMom.text = jsonLoader.dialogMom;
    }

    public void hablarNino()
    {
        Destroy(GameObject.Find("Particle System"));
        panelOpcionesDiscurso.SetActive(false);
        DialogoCoorp.SetActive(true);
        permiteMoverse = false;
        animator.SetTrigger("hablar");
        StartCoroutine(jsonLoader.cargarDialogosHH(diaActual-1));
    }

}