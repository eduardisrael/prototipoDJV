using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerSpeed=500; //velocidad actual - ball
    public float directionalSpeed=20; //direccion velocidad izquierda - derecha - hacia adelante (forward)
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        float moveHorizontal=Input.GetAxis("Horizontal"); //recibe informacion presionar izq-derecha
        //Debug.Log(moveHorizontal); //imprime en consola

        //controles - izquierda derecha - transforma posiciones
        //Lerp interpolacion lineal - nuevea posicion - movimiento suave entre 2 puntos diferentes(2 vectores)
        //new Vector -- nuevo vector gameObject con posicion x mov horizontal - +, en un tiempo consistente
        transform.position=Vector3.Lerp(gameObject.transform.position,new Vector3(
            Mathf.Clamp(gameObject.transform.position.x + moveHorizontal,-2.5f,2.5f),
            gameObject.transform.position.y,gameObject.transform.position.z),
            directionalSpeed + Time.deltaTime);
        

        //mover en cierta direccion cuando se ejerje una fuerza, en este caso la gravedad
        //vector3.forward direccion en cierto tiempo consistente
        GetComponent<Rigidbody>().velocity=Vector3.forward * playerSpeed * Time.deltaTime;
    }
}
