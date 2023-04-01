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
        potionCode = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        potionShown = this.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        pc = potionCode.getSelectedItems();
        if (pc == "154" || pc == "145" || pc == "415" || pc == "451" || pc == "514" || pc == "541")
        {
            potionShown.sprite = sprite_potion145;
        }
        else if(pc == "256" || pc == "265" || pc == "526" || pc == "562" || pc == "625" || pc == "652")
        {
            potionShown.sprite = sprite_potion256;
        }
        else if (pc == "346" || pc == "364" || pc == "436" || pc == "463" || pc == "634" || pc == "643")
        {
            potionShown.sprite = sprite_potion346;
        }
        else if (pc == "156" || pc == "165" || pc == "516" || pc == "561" || pc == "615" || pc == "651")
        {
            potionShown.sprite = sprite_potion156;
        }
        else if (pc == "345" || pc == "354" || pc == "435" || pc == "453" || pc == "534" || pc == "543")
        {
            potionShown.sprite = sprite_potion345;
        }
        else if (pc == "246" || pc == "264" || pc == "426" || pc == "462" || pc == "624" || pc == "642")
        {
            potionShown.sprite = sprite_potion246;
        }
    }
}
