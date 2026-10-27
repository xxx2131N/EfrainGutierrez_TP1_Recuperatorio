using UnityEngine;

public class rotation : MonoBehaviour
{
    [SerializeField] private float Velocidad = 90;
    private Vector3 rotacionObjetivo;
    private bool girando= false;
    void Start()
    {
        rotacionObjetivo = transform.eulerAngles;
        Activar();
    }

    // Update is called once per frame
    void Update()
    {
        if (girando)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation,Quaternion.Euler(rotacionObjetivo), Velocidad * Time.deltaTime);
            if (Quaternion.Angle(transform.rotation, Quaternion.Euler(rotacionObjetivo)) < 0.1)
            {
                transform.rotation = Quaternion.Euler(rotacionObjetivo);
                girando = false;
                Activar();
            }
        }
    }

    private void Activar()
    {
        int eje = Random.Range(0,2);
        int angulo = Random.Range(0,2) == 0 ? 90 : -90;
        if (eje == 0)
        {
            rotacionObjetivo += new Vector3(angulo,0,0);
        }
        else
        {
            rotacionObjetivo += new Vector3(0,0,angulo);
        }
        girando = true;
        Debug.Log("esta jirando");
    }
}
