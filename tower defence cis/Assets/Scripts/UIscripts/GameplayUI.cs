using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Pathfinding;

public class GameplayUI : MonoBehaviour
{
    // variables and objects set
    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;
    public Button button5;
    public Button button6;
    public Button spellButton;

    Button[] buttonArr;

    // objects for placement

    public GameObject[] objects;
    public GameObject selectedObj;
    Vector2 position;
    RaycastHit rayHit;
    public LayerMask mask;
    BasicTowerScript towerScript;
    ProjectileScript ProjScript;
    public float gridSize;
    bool canPlace;
    Color originalColor;
    SpriteRenderer sprite;
    Mana manaManager;
    GraphUpdateObject scan;

    // listeners are initiated
    void Start()
    {
        buttonArr = new Button[] { button1, button2, button3, button4, button5, button6, spellButton };
        manaManager = FindObjectOfType<Mana>();
        //button1.onClick.AddListener(on1);
        //button2.onClick.AddListener(on2);
        //button3.onClick.AddListener(on3);
        //button4.onClick.AddListener(on4);
        //button5.onClick.AddListener(on5);
        //button6.onClick.AddListener(on6);
        //spellButton.onClick.AddListener(onSpell);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("obj: " + selectedObj);
        checkButtonPrice();
        getPlaceRay();
        collisionCheck();

        if(selectedObj != null)
        {
            selectedObj.transform.position = new Vector2(snapToGrid(position.x), snapToGrid(position.y));

            if(Input.GetMouseButtonDown(1))
            {
                Destroy(selectedObj);
                place(false);
            }
            if(Input.GetMouseButtonDown(0) && canPlace)
            {
                place(true);
            }
            

        }
    }

    // activate placement for tower
    public void on1()
    {
        Debug.Log("button1");
        startPlacement(0);
    }

    // activate placement for tower
    public void on2()
    {
        Debug.Log("button2");
        startPlacement(1);
    }

    // activate placement for tower
    public void on3()
    {
        Debug.Log("button3");
        startPlacement(2);
    }

    // activate placement for tower
    public void on4()
    {
        Debug.Log("button4");
        startPlacement(3);
    }

    // activate placement for tower
    public void on5()
    {
        Debug.Log("button5");
        startPlacement(4);
    }

    // activate placement for trap
    public void on6()
    {

        Debug.Log("button6");
        startPlacement(5);
        /*
        if (trapnum >= 0)
        {

        }
        else
        {
            // no deactivate button listener for button 6
        }
        */
    }

    // activate spell use
    public void onSpell()
    {
        startPlacement(6);
        Debug.Log("spell");
        /*
        if(spellReady == true)
        {
            // activate spell placement
            spellReady = false;
        }
        else
        {
            // spell timer is still active
        }
        */
    }

    public void getPlaceRay()
    {
        Vector2 placeRay = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D rayHit = Physics2D.Raycast(placeRay, transform.forward, 1000);
        if (rayHit.collider)
        {
            position = rayHit.point;
        }
    }

    public void startPlacement(int i)
    {

        Debug.Log("obj: spawned: " + selectedObj);
        selectedObj = Instantiate(objects[i], position, transform.rotation);
        
        sprite = selectedObj.GetComponent<SpriteRenderer>();
        Debug.Log("color " + sprite.color);
        originalColor = sprite.color;
        

        if(selectedObj.GetComponent<BasicTowerScript>() != null)
        {
            towerScript = selectedObj.GetComponent<BasicTowerScript>();
            towerScript.active = false;
        }

        if (selectedObj.GetComponent<ProjectileScript>() != null)
        {
            ProjScript = selectedObj.GetComponent<ProjectileScript>();

        }
    }

    public void place(bool subtractCost)
    {
        if (selectedObj.layer == 8)
        {
            scan = new GraphUpdateObject(selectedObj.GetComponent<Collider2D>().bounds);
            scan.updatePhysics = true;
            AstarPath.active.UpdateGraphs(scan);
        }
        
        sprite = null;
        selectedObj = null;
        Debug.Log("obj: placed");
        if(towerScript && subtractCost)
        {
            towerScript.active = true;
            manaManager.currentManaAmount -= towerScript.cost;
        }
            
        towerScript = null;
        Debug.Log("obj: tower activated");
        if (ProjScript && subtractCost)
        {
            ProjScript.active = true;
            manaManager.currentManaAmount -= ProjScript.cost;
        }

        ProjScript = null;
        Debug.Log("obj: proj activated");
    }

    float snapToGrid(float position)
    {
        float difference = position % gridSize;
        position -= difference;
        if(difference > gridSize/2)
        {
            position += gridSize;
        }
        return position;
    }

    public void collisionCheck()
    {
       if(towerScript !=null)
       {
            if (!towerScript.overlapping)
            {
                canPlace = true;
                if (originalColor != null && sprite != null)
                    sprite.color = originalColor;
                
            }
            else
            {
                Debug.Log("cantPlace");
                canPlace = false;
                sprite.color = Color.red;
            }
       }
       else if (ProjScript != null)
       {
           if (!ProjScript.overlapping)
            {
                canPlace = true;
                if (originalColor != null && sprite != null)
                    sprite.color = originalColor;
            }
            else
            {
                Debug.Log("cantPlace");
                canPlace = false;
                sprite.color = Color.red;
            }
       }
        


    }

    public void checkButtonPrice()
    {
        foreach(Button button in buttonArr)
        {
            int cost;
            int index = System.Array.IndexOf(buttonArr, button);
            GameObject tower = objects[index];
            if(tower.GetComponent<BasicTowerScript>() != null)
            {
                cost = tower.GetComponent<BasicTowerScript>().cost;
            }
            else if (tower.GetComponent<ProjectileScript>() != null)
            {
                cost = tower.GetComponent<ProjectileScript>().cost;
            }
            else
            {
                cost = 0;
            }

            if(cost > manaManager.currentManaAmount)
            {
                button.interactable = false;
            }
            else
            {
                button.interactable = true;
            }
        }
    }
}
