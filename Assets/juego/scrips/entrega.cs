using UnityEngine;

public class entrega : MonoBehaviour
{
    [Header("Punto de entrega")]
    [SerializeField] private Transform puntoEntrega;

    [Header("Objetos necesarios")]
    [SerializeField] private int objetosNecesarios = 3;

    private int objetosEntregados = 0;

    public void EntregarObjeto(GameObject objeto)
    {
        if (objeto == null || puntoEntrega == null) return;

        objeto.transform.SetParent(null);
        objeto.transform.position = puntoEntrega.position;
        objeto.transform.rotation = puntoEntrega.rotation;

        Rigidbody rb = objeto.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.isKinematic = true;
        }

        Collider[] colliders = objeto.GetComponentsInChildren<Collider>();

        foreach (Collider col in colliders)
        {
            col.enabled = true;
        }

        objetosEntregados++;

        Debug.Log("Objetos entregados: " + objetosEntregados);

        if (objetosEntregados >= objetosNecesarios)
        {
            Debug.Log("¡GANASTE!");
        }
    }
}