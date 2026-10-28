using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject objetoPrefab;
    [SerializeField] private int cantidadOnjetos;
    [SerializeField] private float tiempoVida= 3;
    [SerializeField] private float tiempoEspera;
    [SerializeField]private float separacion = 1;


    void Start()
    {
        StartCoroutine(CrearObjetos());
    }
    private IEnumerator CrearObjetos()
    {
        while(true)
        {
            for(int i = 0; i < cantidadOnjetos; i++)
            {
                Vector3 posicion = transform.position + transform.right *(i * separacion);
                GameObject objeto = Instantiate(objetoPrefab, posicion, transform.rotation);
                Destroy(objeto, tiempoVida);
            }
            yield return new WaitForSeconds(tiempoVida+ tiempoEspera);
        }
    }
}
