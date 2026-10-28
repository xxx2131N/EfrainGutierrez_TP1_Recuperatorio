using UnityEngine;

public class Checpoint : MonoBehaviour
{
    private Renderer checkPointRender;
    private void OnTriggerEnter(Collider other)
    {
        MovimientoPlayer Player = other.GetComponent<MovimientoPlayer>();
        if (Player != null )
        {
           Player.SetSpawnPoint(transform);
           if(checkPointRender != null)
            {
                checkPointRender.material.color = Color.yellow;
            }

        }
    }
}
