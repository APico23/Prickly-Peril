using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public float smoothing;

    public Vector2 maxPosition;
    public Vector2 minPosition;

    private void Start()
    {
        
    }

    void LateUpdate()
    {
        if(transform.position != target.position)
        {
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y + 5, transform.position.z);

            targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);
            targetPosition.y = Mathf.Clamp (targetPosition.y, minPosition.y, maxPosition.y);

            if (target.position.y >= 240)
            {
                targetPosition.x = transform.position.x;
                if (GetComponent<Camera>().orthographicSize < 40) {
                    GetComponent<Camera>().orthographicSize += 0.1f;
                }
                
            }
            else
            {
                if (GetComponent<Camera>().orthographicSize > 10)
                {
                    GetComponent<Camera>().orthographicSize -= 0.1f;
                }
            }

            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing); 
        }
    }
}
