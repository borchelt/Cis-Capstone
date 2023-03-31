using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraScript : MonoBehaviour
{
    public float speed = 20f;
    public float zoom = 5f;
    public Camera cam;
    public float xMax = 100;
    public float yMax = 100;
    Vector3 mousePos;
    Vector3 mouseVec;
    bool mouseDown;
    Vector3 mouseSpeed;
    Vector3 lastMousePos;
    Vector3 position;
    bool canDrag;

    // variable to assist with UI and mouse interactivity
    public static bool gameScreenActive;

    // Update is called once per frame
    void LateUpdate()
    {
       
        if (gameScreenActive == true && PauseMenuUI.gameStopped == false )
        {
            position = transform.position;

            if (Input.GetKey("w") || Input.GetKey(KeyCode.UpArrow))
            {
                position.y += speed * Time.deltaTime;
            }

            if (Input.GetKey("s") || Input.GetKey(KeyCode.DownArrow))
            {
                position.y -= speed * Time.deltaTime;
            }

            if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))
            {
                position.x -= speed * Time.deltaTime;
            }

            if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
            {
                position.x += speed * Time.deltaTime;
            }

            mouseDrag();

            position.x = Mathf.Clamp(position.x, -xMax, xMax);
            position.y = Mathf.Clamp(position.y, -yMax, yMax);

            transform.position = position;

            if (Input.mouseScrollDelta.y > 0)
            {
                cam.orthographicSize -= zoom * Time.deltaTime;
                cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, 1, 20);
            }
            if (Input.mouseScrollDelta.y < 0)
            {
                cam.orthographicSize += zoom * Time.deltaTime;
                cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, 1, 20);
            }

            lastMousePos = Input.mousePosition;

        }
    }
    
    void mouseDrag()
    {
            
        if (gameScreenActive == true)
        {
            if (Input.GetMouseButton(0))
            {

                
                mouseVec = Camera.main.ScreenToWorldPoint(Input.mousePosition) - position;

                if (!mouseDown)
                {
                    mouseDown = true;
                    mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                    if (EventSystem.current.IsPointerOverGameObject())
                    {
                        canDrag = false;
                    }
                    else
                    {
                        canDrag = true;
                    }
                }

            }
            else
            {
                mouseDown = false;
                canDrag = true;
            }

            if (mouseDown && canDrag)
            {
                position = mousePos - mouseVec;
            }
        }

    }
    


}
