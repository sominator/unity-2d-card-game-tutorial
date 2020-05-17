using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardFlipper : MonoBehaviour
{
    public Sprite CyanCardFront;
    public Sprite CyanCardBack;
    public Sprite MagentaCardFront;
    public Sprite MagentaCardBack;

    private Sprite cardFront;
    private Sprite cardBack;

    public void SetSprite(string type)
    {
        if (type == "cyan")
        {
            cardFront = CyanCardFront;
            cardBack = CyanCardBack;
        }
        else if (type == "magenta")
        {
            gameObject.GetComponent<Image>().sprite = MagentaCardFront;
            cardFront = MagentaCardFront;
            cardBack = MagentaCardBack;
        }
    }

    public void Flip()
    {
        if (gameObject.GetComponent<Image>().sprite == cardFront)
        {
            gameObject.GetComponent<Image>().sprite = cardBack;
        }
        else
        {
            gameObject.GetComponent<Image>().sprite = cardFront;
        }
    }
}
