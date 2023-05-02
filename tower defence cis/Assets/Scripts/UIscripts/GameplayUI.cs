using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Pathfinding;

public class GameplayUI : MonoBehaviour
{
    // script object reference
    public GameObject gameplayUIobj;

    // openning drop menu button objects set
    public Button dropShOpen;
    public Button dropMineOpen;

     // structure placement buttons set
    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;
    public Button button5;
    public Button button6;
    public Button spellButton;

    // drop menu button objects set
    public Button subButton1_1;
    public Button subButton1_2;
    public Button subButton1_3;
    public Button subButton6_1;
    public Button subButton6_2;
    public Button subButton6_3;


    // array for gathering buttons
    Button[] buttonArr;

    // audio objects set
    public AudioSource audioSource;
    public AudioClip cantPlaceSound;

    // objects for placement
    public GameObject[] objects;
    public GameObject selectedObj;

    // objects and variables set for placement mathematics and grid snapping
    Vector2 position;
    RaycastHit rayHit;
    public LayerMask mask;
    BasicTowerScript towerScript;
    ProjectileScript ProjScript;
    ManaTower manaScript;
    public float gridSize;
    bool canPlace;

    // sprite adjusters and mana object reference set
    Color originalColor;
    SpriteRenderer sprite;
    Mana manaManager;
    GraphUpdateObject scan;

    // drop menu references set
    public dropShootUI dShootOBJ;
    public dropMineUI dMineOBJ;

    // level name variable
    private string levelName;

    // Start is called before the first frame update
    void Start()
    {
        // button array is set
        buttonArr = new Button[] { button1, button2, button3, button4, button5, button6, spellButton, subButton1_1, subButton1_2, subButton1_3, subButton6_1, subButton6_2, subButton6_3 };

        // mana manager is set
        manaManager = FindObjectOfType<Mana>();

        // listeners are initiated
        dropShOpen.onClick.AddListener(onShootOpen);
        dropMineOpen.onClick.AddListener(onMineOpen);

        // scene name is set as variable
        Scene levelScene = SceneManager.GetActiveScene();
        levelName = levelScene.name;
    }

    // Checks placement of structure on every game tick
    void Update()
    {
        placeCheck();
    }

    // checks placement of structure
    public void placeCheck()
    {
        Debug.Log("obj: " + selectedObj);
        checkButtonPrice();
        getPlaceRay();
        collisionCheck();

        // if no enemy, object, or other structure is underneath the hovering tower, the player can place the tower
        if (selectedObj != null)
        {
            selectedObj.transform.position = new Vector2(snapToGrid(position.x), snapToGrid(position.y));

            if (Input.GetMouseButtonDown(1))
            {
                Destroy(selectedObj);
                place(false);
            }
            if (Input.GetMouseButtonDown(0) && canPlace)
            {
                place(true);
            }
            else if (Input.GetMouseButtonDown(0))
            {
                audioSource.PlayOneShot(cantPlaceSound);
            }
        }
    }

    // activate placement for mana tower
    public void on1()
    {
        startPlacement(0);
    }

    // activate placement for shoot tower
    public void on2()
    {
        startPlacement(1);
    }

    // activate placement for barracks tower
    public void on3()
    {
        startPlacement(2);
    }

    // activate placement for AOE tower
    public void on4()
    {
        startPlacement(3);
    }

    // activate placement for wall
    public void on5()
    {
        if (levelName == "Level1" || levelName == "Level2" || levelName == "Level3" || levelName == "Level4")
        {
            startPlacement(4);
        }
        else if (levelName == "Level5")
        {
            startPlacement(13);
        }
    }

    // activate placement for spike trap
    public void on6()
    {
        startPlacement(5);
    }

    // // activate placement for shoot tower
    public void onSub1_1()
    {
        startPlacement(1);
    }

    // activate placement for bomb tower
    public void onSub1_2()
    {
        startPlacement(9);
    }

    // activate placement for mage tower
    public void onSub1_3()
    {
        startPlacement(10);
    }

    // activate placement for pit trap
    public void onSub6_2()
    {
        startPlacement(11);
    }

    // activate placement for mine trap
    public void onSub6_3()
    {
        startPlacement(12);
    }

    // opens shoot tower dropdown menu
    public void onShootOpen()
    {
        dShootOBJ.dropShoot.SetActive(true);
    }

    // opens traps dropdown menu
    public void onMineOpen()
    {
        dMineOBJ.dropMine.SetActive(true);
    }

    // activate spell use
    public void onSpell()
    {
        startPlacement(Random.Range(6, 9));
    }

    // mathematics for tower placement
    public void getPlaceRay()
    {
        Vector2 placeRay = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D rayHit = Physics2D.Raycast(placeRay, transform.forward, 1000);
        if (rayHit.collider)
        {
            position = rayHit.point;
        }
    }

    // tower placement logic
    public void startPlacement(int i)
    {

        Debug.Log("obj: spawned: " + selectedObj);
        selectedObj = Instantiate(objects[i], position, transform.rotation);

        sprite = selectedObj.GetComponent<SpriteRenderer>();
        Debug.Log("color " + sprite.color);
        originalColor = sprite.color;

        if (selectedObj.GetComponent<ManaTower>() != null)
        {
            manaScript = selectedObj.GetComponent<ManaTower>();
            manaScript.active = false;
        }


        if (selectedObj.GetComponent<BasicTowerScript>() != null)
        {
            towerScript = selectedObj.GetComponent<BasicTowerScript>();
            towerScript.active = false;
        }

        if (selectedObj.GetComponent<ProjectileScript>() != null)
        {
            ProjScript = selectedObj.GetComponent<ProjectileScript>();
            ProjScript.active = false;

        }
    }

    // method for placing the tower
    public void place(bool subtractCost)
    {
        audioSource.Play();
        if (selectedObj.layer == 8)
        {
            scan = new GraphUpdateObject(selectedObj.GetComponent<Collider2D>().bounds);
            scan.updatePhysics = true;
            AstarPath.active.UpdateGraphs(scan);
        }

        sprite = null;
        selectedObj = null;
        Debug.Log("obj: placed");
        if (towerScript && subtractCost)
        {
            towerScript.active = true;
            manaManager.currentManaAmount -= towerScript.cost;
            manaManager.UpdateManaBar();
        }

        towerScript = null;
        Debug.Log("obj: tower activated");
        if (ProjScript && subtractCost)
        {
            ProjScript.active = true;
            manaManager.currentManaAmount -= ProjScript.cost;
            manaManager.UpdateManaBar();
        }

        ProjScript = null;
        Debug.Log("obj: proj activated");
        if (manaScript && subtractCost)
        {
            manaScript.active = true;
        }

        manaScript = null;

    }

    // snap grid logic
    float snapToGrid(float position)
    {
        float difference = position % gridSize;
        position -= difference;
        if (difference > gridSize / 2)
        {
            position += gridSize;
        }
        return position;
    }

    // method to check if there are obstructions to tower placement
    public void collisionCheck()
    {
        if (towerScript != null)
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

    // method to assign and check mana prices for structures
    public void checkButtonPrice()
    {
        foreach (Button button in buttonArr)
        {
            int cost;
            int index = System.Array.IndexOf(buttonArr, button);

            //spaghetti code for the extra drop down buttons
            if (index == 7)
                index = 1;
            if (index == 10)
                index = 5;
            //if (index > 7)
            //  index--;
            if (index > 11)
                index--;
            GameObject tower = objects[index];
            Debug.Log("Tower: " + button.name + " : " + tower.name);
            if (tower.GetComponent<BasicTowerScript>() != null)
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

            if (cost > manaManager.currentManaAmount)
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
