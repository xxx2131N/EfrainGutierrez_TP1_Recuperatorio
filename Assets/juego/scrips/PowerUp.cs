using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private float TiempoAbilidad = 5;
    [SerializeField] private float Culdawn = 8;
    [SerializeField] private LayerMask capaObstaculos;
    private bool puedeUsar = true;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && puedeUsar)
        {
            StartCoroutine(UsarFreez());
        }
    }

    private IEnumerator UsarFreez()
    {
        puedeUsar = false;
        plataformeo[] plataformas = FindObjectsOfType<plataformeo>();
        rotation[] rotaciones = FindObjectsOfType<rotation>();

        foreach(plataformeo plataforma in plataformas)
        {
            if(PerteneceAlaCapa(plataforma.gameObject)) plataforma.ActivarFreez(true);
        }
        foreach (rotation rotacion in rotaciones)
        {
            if(rotacion != null && PerteneceAlaCapa(rotacion.gameObject))
            {
                rotacion.ActivarFreez(true);
            }
        }

        yield return new WaitForSeconds(TiempoAbilidad);

        foreach (plataformeo plataforma in plataformas)
        {
            if (plataforma != null && PerteneceAlaCapa  (plataforma.gameObject))
            {
                plataforma.ActivarFreez(false);
            }
            
        }

        foreach (rotation rotacion in rotaciones)
        {
            if (rotacion != null && PerteneceAlaCapa(rotacion.gameObject)) 
            {
                rotacion.ActivarFreez(false);
            }

            yield return new WaitForSeconds(Culdawn);

            puedeUsar = true;
        }    
    }
    private bool PerteneceAlaCapa(GameObject objeto)
    {
        return ((capaObstaculos.value & (1 << objeto.layer)) != 0);
    }

}
