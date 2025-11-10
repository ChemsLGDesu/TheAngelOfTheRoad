using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class DragableObjects : MonoBehaviour, IDragHandler//, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private bool isDragging = false;
    public List<DragObjects> data;
    private Camera cam; // sirve para guardar una referencia a la camara pirncipal y convierte la posicion del mouse a coordenads del mundo

    void Start()
    {
        cam = Camera.main;
    }


    void Update()
    {
        VerificateDrag();
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        isDragging = true;
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        isDragging = false;
    }
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
}
