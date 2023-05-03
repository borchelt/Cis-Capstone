using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class EnemyTakeDamage : MonoBehaviour
{
    //variables for taking damage
    public float hp;
    public SpriteRenderer sprite;
    public bool killParent = false;
    public GameObject parent;
    Color originalColor;
    float colorCD = .01f;
    bool dead = false;
    //variables for audio 
    public AudioSource source;
    public AudioClip damageSFX;
    public AudioClip deathSFX;
    bool playAudio;

    // Start is called before the first frame update
    void Start()
    {
        //checks for audio
        if (source == null)
            playAudio = false;
        else
            playAudio = true;

        //get the sprite renderer and color
        sprite = GetComponent<SpriteRenderer>();
        originalColor = sprite.color;
    }

    // Update is called once per frame
    void Update()
    {
        //handles enemies changing color when damaged 
        handleColorCD();
        //handles dying
        die();
    }

    //reduce health by however much damage
    public void takeDamage(float damage)
    {
        //changes the audio to play if the target is only damaged and not killed
        if (hp - damage > 0 && playAudio)
            source.clip = damageSFX;

        //dies and plays the death sound effect
        else if(playAudio && dead == false)
        {
            dead = true;
            sprite.enabled = false;
            gameObject.layer = 16;
            source.clip = deathSFX;
            source.Play();
        }

        //plays the damage sound if damaged, using the same cooldown as changing color
        if (playAudio && dead == false && colorCD > 0f)
            source.Play();
            
        //change sprite color and take damage
        sprite.color = Color.red;
        hp -= damage;
    }

    //check if dealth is below 1, if it is, die.
    void die()
    {
        if (hp <= 0 && sprite.color == originalColor)
        {
            //wont destroy the object if it's death sound is still playing
            if (playAudio && source.isPlaying)
                return;
            if(killParent)
            {
                Destroy(parent);
            }
            Destroy(gameObject);
        }
            
    }

    //handles the timing on color flashes for damage.
    void handleColorCD()
    {
        if (colorCD < 0)
        {
            sprite.color = originalColor;
            colorCD = .15f;
        }

        if (sprite.color != originalColor)
        {
            colorCD -= Time.deltaTime;
        }
    }
}
