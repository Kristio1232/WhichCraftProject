using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PotionSpriteChange : MonoBehaviour
{
  
    public GameObject MiniGameWinMenu;
    public Image potionShown;
    public Sprite sprite_potion145;
    public Sprite sprite_potion256;
    public Sprite sprite_potion346;
    public Sprite sprite_potion156;
    public Sprite sprite_potion345;
    public Sprite sprite_potion246;
    public Player potionCode;

    // Start is called before the first frame update
    void Start()
    {
        potionShown = this.GetComponent<Image>();
        potionShown.sprite = sprite_potion145;
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void changeImage()
    {

    }

}
