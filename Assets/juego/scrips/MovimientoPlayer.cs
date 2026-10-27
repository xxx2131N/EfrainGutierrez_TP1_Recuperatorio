using UnityEngine;

public class MovimientoPlayer : MonoBehaviour
{
    [SerializeField] private float velocidad = 5;
    [SerializeField] private float FuerzaSalto =5;

    [Header ("la camara")]
    [SerializeField] private Transform camara;
    [SerializeField] private float sensibilidad=100;
    [SerializeField] private InterfacePlayer inter;
    private float rotacionX =0;
    private Rigidbody rb;
    private Vector3 direccion= Vector3.zero;
    void Start()
    {
        rb= GetComponent<Rigidbody>();

        Cursor.lockState= CursorLockMode.Locked;
        Cursor.visible= false;
    }
    void Update()
    {
        float mouseX= Input.GetAxis("Mouse X") * sensibilidad *Time.deltaTime;
        float mouseY= Input.GetAxis("Mouse Y") * sensibilidad *Time.deltaTime;
        transform.Rotate(0f,mouseX,0f);
        rotacionX -= mouseY;
        rotacionX = Mathf.Clamp(rotacionX, -90,90);
        if(camara != null)
        {
            camara.localRotation = Quaternion.Euler(rotacionX,0,0);
        }
        
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        direccion = transform.right* inputX + transform.forward* inputY;
        direccion.Normalize();

        float velocidadadActual = velocidad;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            velocidadadActual *= 2f;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Saltar();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
    private void FixedUpdate()
    {
        if(rb == null) return;
        float velocidadActual = velocidad;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            velocidadActual *= 2;
        }
        rb.linearVelocity = new Vector3(direccion.x * velocidadActual,rb.linearVelocity.y, direccion.z * velocidadActual);
    }
    private void Saltar()
    {
        if (rb == null) return;
        if(Physics.Raycast(transform.position, Vector3.down, 1.1f))
        {
            rb.AddForce(Vector3.up * FuerzaSalto,ForceMode.Impulse);
        }
    }
}
