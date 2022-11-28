using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public static bool NoMoreFlips = false;

    [SerializeField]
    private int _state;
    [SerializeField]
    private int cardshape;
    [SerializeField]
    private bool initialized = false;

    private Texture cardBack;
    private Texture cardFace;

    private GameObject manager;

    // Start is called before the first frame update
    void Start()
    {
        _state = 1;
        manager = GameObject.FindGameObjectWithTag("Manager");
    }

    public void setupCardFace()
    {
        //Switches from the card back to the face of the card
        cardBack = manager.GetComponent<MatchingManager>().getCardBack();
        cardFace = manager.GetComponent<MatchingManager>().getCardFace(cardshape);

        flipCard();
    }

    public void flipCard()
    {
        if(_state == 0)
        {
            _state = 1;
        }
        else if(_state == 1)
        {
            _state = 0;
        }

        //If state is in the front change to cardback
        if (_state == 0 && !NoMoreFlips)
        {
           GetComponent<RawImage>().texture = cardBack;
        }
        //else if state is in the back change to the front
        else if (_state == 1 && !NoMoreFlips) 
        {
            GetComponent<RawImage>().texture = cardFace;
        }
    }
    
    //Allow variables to publicly changed through other code
    public int _cardshape
    {
        get { return cardshape; }
        set { cardshape = value; }
    }

    public int state
    {
        get { return _state; }
        set { _state = value; }
    }

    public bool _initialized
    {
        get { return initialized; }
        set { initialized = value; }
    }

    //Checks to see if they are matched if not pauses so the player can memorize and remember where cards are placed
    public void falseCheck()
    {
        StartCoroutine(pause());
    }

    IEnumerator pause()
    {
        yield return new WaitForSeconds(1);
        if(_state == 0)
        {
            GetComponent<RawImage>().texture = cardBack;
        }
        else if(_state == 1)
        {
            GetComponent<RawImage>().texture = cardFace;
        }
        NoMoreFlips = false;
    }
}
