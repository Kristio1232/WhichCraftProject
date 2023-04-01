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
    private string pc;

    // Start is called before the first frame update
    void Start()
    {
        potionShown = this.GetComponent<Image>();
        pc = potionCode.getSelectedItems();
        Debug.Log(pc);
    }

    // Update is called once per frame
    void Update()
    {
        if(pc == "154" || pc == "145")
        {
            potionShown.sprite = sprite_potion145;
        }
    }

    void changeImage()
    {

    }

}
