using UnityEngine;

public class plataformeo : MonoBehaviour
{
    [SerializeField] private float velociadad = 5;
    [SerializeField] private float tiempoEspera = 1;
    private bool esperando = false;

    [Header("puntos de desplaxamiento")]
    [SerializeField] private Transform punto1;
    [SerializeField] private Transform punto2;
    private Transform puntoDestino;
    private float velocidadOriginal;

    void Start()
    {
        velocidadOriginal = velociadad;
        if(punto1 != null && punto2!= null)
        {
            transform.position = punto1.position;
            puntoDestino = punto2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (punto1 == null || punto2 == null || esperando) return;
        transform.position = Vector3.MoveTowards(transform.position, puntoDestino.position,velociadad*Time.deltaTime);
        if (Vector3.Distance(transform.position, puntoDestino.position) < 0.01)
        {
            transform.position = puntoDestino.position;
            esperando = true;
            Invoke(nameof(CambiarDestino),tiempoEspera);
        }
    }
    private void CambiarDestino()
    {
        if(puntoDestino == punto2)
        {
            puntoDestino= punto1;
        }
        else
        {
            puntoDestino = punto2;
        }
        esperando= false;
    }
    public void ActivarFreez(bool activar)
    {
        if (activar)
        {
            velociadad = velocidadOriginal /2;
        }
        else
        {
            velociadad= velocidadOriginal;
        }
    }
}
