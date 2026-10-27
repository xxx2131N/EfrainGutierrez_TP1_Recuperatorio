using UnityEngine;

public class plataformeo : MonoBehaviour
{
    [SerializeField] private float velociadad = 5;

    [Header("puntos de desplaxamiento")]
    [SerializeField] private Transform punto1;
    [SerializeField] private Transform punto2;
    private Transform puntoDestino;

    void Start()
    {
        if(punto1 != null && punto2!= null)
        {
            transform.position = punto1.position;
            puntoDestino = punto2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (punto1 == null || punto2 == null) return;
        transform.position = Vector3.MoveTowards(transform.position, puntoDestino.position,velociadad*Time.deltaTime);
        if (Vector3.Distance(transform.position, puntoDestino.position) < 0.01)
        {
            if(puntoDestino == punto2)
            {
                puntoDestino = punto1;
            }
            else
            {
                puntoDestino = punto2;
            }
        }
    }
}
