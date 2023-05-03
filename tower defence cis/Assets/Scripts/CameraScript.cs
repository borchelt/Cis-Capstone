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
       //get camera movement using keyboard 
        if (gameScreenActive == true && PauseMenuUI.gameStopped == false )
        {
            //get the original postion of the camera
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

            //get camera movment from mouse dragging
            mouseDrag();

            //limit camera movement 
            position.x = Mathf.Clamp(position.x, -xMax, xMax);
            position.y = Mathf.Clamp(position.y, -yMax, yMax);

            //update position of the camera 
            transform.position = position;

            //zoom in and out with scroll wheel
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
    
    //drags the camera around with the mouse
    void mouseDrag()
    {
            
        if (gameScreenActive == true)
        {
            //if clicking
            if (Input.GetMouseButton(0))
            {

                //gets the vector between the mouse and the camera 
                mouseVec = Camera.main.ScreenToWorldPoint(Input.mousePosition) - position;

                if (!mouseDown)
                {
                    //set mouseDown to true and update the mouse position
                    mouseDown = true;
                    mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                    //check if the mouse is over the ui 
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
            //if not clicking
            else
            {
                mouseDown = false;
                canDrag = true;
            }

            //update the camera position based on the mouse
            if (mouseDown && canDrag)
            {
                position = mousePos - mouseVec;
            }
        }

    }
    


}
