using UnityEngine;
using UnityEngine.UI;

public class TutorialController : MonoBehaviour
{
    public Button btnLeft, btnRight, btnJump, btnAttack, btnJump2, btnItems;
    public Sprite jumpSprite, jumpSpriteHighlight;
    public Sprite aSprite, aSpriteHighlight;
    public Sprite dSprite, dSpriteHighlight;
    public Sprite enterSprite, enterSpriteHighlight;
	public Sprite itemSprite, itemSpriteHighlight;
    public Canvas canvas;

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            btnJump.image.sprite = jumpSpriteHighlight;
            btnJump2.image.sprite = jumpSpriteHighlight;

        }
        else if (Input.GetKeyUp("space"))
        {
            btnJump.image.sprite = jumpSprite;
            btnJump2.image.sprite = jumpSprite;
        }

        if (Input.GetKeyDown("a"))
        {
            btnLeft.image.sprite = aSpriteHighlight;
        }
        else if (Input.GetKeyUp("a"))
        {
            btnLeft.image.sprite = aSprite;
        }

        if (Input.GetKeyDown("d"))
        {
            btnRight.image.sprite = dSpriteHighlight;
        }
        else if (Input.GetKeyUp("d"))
        {
            btnRight.image.sprite = dSprite;
        }

        if (Input.GetKeyDown("return"))
        {
            btnAttack.image.sprite = enterSpriteHighlight;
        }
        else if (Input.GetKeyUp("return"))
        {
            btnAttack.image.sprite = enterSprite;
        }

		if (Input.GetKeyDown("i"))
		{
			btnItems.image.sprite = itemSpriteHighlight;
		}
		else if (Input.GetKeyUp("i"))
		{
			btnItems.image.sprite = itemSprite;
		}

    }
}
