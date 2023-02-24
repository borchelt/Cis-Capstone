using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTakeDamage : MonoBehaviour
{
    //variables for taking damage
    public float hp;
    public SpriteRenderer sprite;
    Color originalColor;
    float colorCD = .01f;

    // Start is called before the first frame update
    void Start()
    {
        //get the sprite renderer and color
        sprite = GetComponent<SpriteRenderer>();
        originalColor = sprite.color;
    }

    // Update is called once per frame
    void Update()
    {
        handleColorCD();
        die();
    }

    //reduce health by however much damage
    public void takeDamage(float damage)
    {
        sprite.color = Color.red;
        hp -= damage;
    }

    //check if dealth is below 1, if it is, die.
    void die()
    {
        if (hp <= 0 && sprite.color == originalColor)
            Destroy(gameObject);
    }

    //handles the timing on color flashes for damage.
    void handleColorCD()
    {
        if (colorCD < 0)
        {
            sprite.color = originalColor;
            colorCD = .1f;
        }

        if (sprite.color != originalColor)
        {
            colorCD -= Time.deltaTime;
        }
    }
}
