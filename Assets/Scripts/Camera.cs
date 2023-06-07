using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;




//Vectores para limitar el movimiento de la camara en los ejes X e Y
    public Vector2 limitX;
    public Vector2 limitY;
   
    public float interpolationRatio;
   
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("MainCharacter").GetComponent<Transform>();
    }




    // Update is called once per frame
    void LateUpdate()
    {
        if(target != null)
        {
            //posicion deseada de la camara
            Vector3 desiredPosition = target.position + offset;




            //limitamos la posicion en la X
            float clampX = Mathf.Clamp(desiredPosition.x, limitX.x , limitX.y);
            //limitamos la posicion en la Y
            float clampY = Mathf.Clamp(desiredPosition.y, limitY.x , limitY.y);




            //posicion limitada en X e Y
            Vector3 clampedPosition = new Vector3(clampX, clampY, desiredPosition.z);




            Vector3 lerpedPosition = Vector3.Lerp(transform.position, clampedPosition, interpolationRatio);




            transform.position = lerpedPosition;
        }
       
    }
}

