using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class DragableObjects : MonoBehaviour, IDragHandler//, IPointerDownHandler, IPointerUpHandler
{
    public ObstacleDataSO data;
    [SerializeField]protected bool isDragging = false;
    //public List<> data;
    protected Camera cam; // sirve para guardar una referencia a la camara pirncipal y convierte la posicion del mouse a coordenads del mundo
    [SerializeField]protected Transform target;
    void Start()
    {
        cam = Camera.main;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();// patron singleton

        GetComponent<SpriteRenderer>().sprite = data.icon;

       // target =  GameManager.Instance.player.GetComponent<Transform>();
    }


    void Update()
    {
        VerificateDrag();
    }
    
    /*
     No funciona el OnPointerDown y OnPointerUp )):
    public void OnPointerDown(PointerEventData eventData)
    {
        isDragging = true;
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        isDragging = false;
    }
    */
    public void DragObjects()
    {
        Vector3 MousePos = Input.mousePosition;
        // Math.Abs obtiene el valor absoluto de un numero en el mundo , osea convierte un valor negativo a positivo
        //Esta linea de codigo sirve para calcular de la posicion del mouse en el mundo para que el ScreenToWorldPoint funcione de manera correcta
        MousePos.z = Mathf.Abs(cam.transform.position.z - transform.position.z);
        Vector3 worldPos = cam.ScreenToWorldPoint(MousePos);
        transform.position = worldPos;
    }
    public void VerificateDrag()
    {
        if (isDragging)
        {
            DragObjects();
        }

    }
    public void OnMouseOver()
    {
        if (Input.GetMouseButton(0))
        {
            isDragging = true;
        }
        else 
        { 
            isDragging= false;
        
        }      
    } 
    public void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerMovement barraDespertar = collision.collider.GetComponent<PlayerMovement>();
        if (barraDespertar != null)
        {
            barraDespertar.DamageOdurability(20);
        }       
    }

    
}
