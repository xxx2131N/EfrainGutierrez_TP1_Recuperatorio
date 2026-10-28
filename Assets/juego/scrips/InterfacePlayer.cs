using UnityEngine;

public class InterfacePlayer : MonoBehaviour
{
    [SerializeField] private Transform ManoD;
    [SerializeField] private Transform ManoI;

    [Header(" detecciondel objeto")]
    [SerializeField] private float DistanciaInter = 2;
    [SerializeField] private LayerMask lay;

    private GameObject objetoManoD;
    private GameObject objetoManoI;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            DetectarInteraccion(ManoD, ref objetoManoD);
        }
        if(Input.GetKeyDown(KeyCode.Q))
        {
            DetectarInteraccion(ManoI, ref objetoManoI);
        }
    }
    private void DetectarInteraccion(Transform mano, ref GameObject ObjetoEnMano)
    {
        if(mano == null)
        {
            Debug.Log("falto asignar las manos animal");
            return;
        }
        if(ObjetoEnMano != null)
        {
            SoltarInteractuable(ref ObjetoEnMano);
            return;
        }
        Collider[] objetos = Physics.OverlapSphere(transform.position, DistanciaInter, lay);

        foreach (Collider col in objetos)
        {
            GameObject objeto = col.gameObject;

            if (objeto == objetoManoD || objeto == objetoManoI)
            {
                continue;
            }
            RecojerInteractuable(objeto, mano, ref ObjetoEnMano);
            return;
        }
    }
    private void RecojerInteractuable(GameObject objeto, Transform mano, ref GameObject objetoEnMano)
    {
        objetoEnMano = objeto;
        Rigidbody rb = objeto.GetComponent<Rigidbody>();

        if(rb != null)
        {
            rb.isKinematic = true;
            rb.linearVelocity = Vector3.zero;
        }
        Collider [] colliders = objeto.GetComponentsInChildren<Collider>();
        foreach(Collider col in colliders)
        {
            col.enabled= false;
        }
        objeto.transform.SetParent(mano);
        objeto.transform.localPosition = Vector3.zero;
        objeto.transform.localRotation = Quaternion.identity;
    }
    private void SoltarInteractuable(ref GameObject objetoEnMano)
    {
        if(objetoEnMano == null) return;
        GameObject objeto = objetoEnMano;

        objeto.transform.SetParent(null, true);
        Collider[] colliders = objeto.GetComponentsInChildren<Collider>();
        foreach(Collider col in colliders)
        {
            col.enabled = true;
        }
        Rigidbody rb = objeto.GetComponent<Rigidbody>();
        if(rb != null)
        {
            rb.isKinematic = false;
        }
        objetoEnMano = null;
        Debug.Log("objeto soltado");
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position,DistanciaInter);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("lava"))
        {
            Destroy(gameObject);
        }
    }

}
