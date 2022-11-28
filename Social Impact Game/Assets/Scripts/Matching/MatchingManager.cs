using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MatchingManager : MonoBehaviour
{

    public Texture[] _cardFace;
    public Texture _cardBack;
    public GameObject[] cards;
    public TextMeshProUGUI matchText;

    private bool _init = false;
    private int _matches = 3;

    
    // Update is called once per frame
    void Update()
    {
        if (!_init)
        {
            initializeCards();
        }
        if (Input.GetMouseButtonUp(0))
        {
            checkCards();
        }
    }

    void initializeCards()
    {

        //Initialize the amount of matches needed
        for (int id = 0; id < 2; id++)
        {
            for (int i = 1; i < 4; i++)
            {
                bool test = false;
                int choice = 0;
                while (!test)
                {
                    //Look if a card is initialized or not
                    choice = Random.Range(0, cards.Length);
                    test = !(cards[choice].GetComponent<Card>()._initialized);
                }
                //If not initialize it and give it a value
                cards[choice].GetComponent<Card>()._cardshape = i;
                cards[choice].GetComponent<Card>()._initialized = true;
            }
        }

        //Gives the cardface related to the cardvalue
        foreach (GameObject c in cards)
         c.GetComponent<Card>().setupCardFace();
        //Everything is initialized
        if (!_init)
            _init = true;
    }

    //Gets cardback and face
    public Texture getCardBack()
    {
        return _cardBack;
    }

    public Texture getCardFace(int i)
    {
        return _cardFace[i-1];
    }


    void checkCards()
    {
        //List of cards available and checks
        List<int> c = new List<int>();

        for(int i = 0; i < cards.Length; i++)
        {
            //Checks how many are cards are faced up
            if(cards[i].GetComponent<Card>().state == 1)
            {
                
                c.Add(i);
            }
        }
        //If 2 are faced up they compare them
        if(c.Count == 2)
        {
            cardComparison(c);
        }
    }

    void cardComparison(List<int> c)
    {
        Card.NoMoreFlips = true;

        int x = 0;
        //If the first card flipped matches the second card flipped it matches them
        if(cards[c[0]].GetComponent<Card>()._cardshape == cards[c[1]].GetComponent<Card>()._cardshape)
        {
            x = 2;
            _matches--;
            matchText.text = "Number of Matches: " + _matches;
            if(_matches == 0)
            {
                //When matches are complete do something
                //SceneManager.LoadScene("Menu");
            }
        }

        //If they are not matched, the game pauses for a second to see the faces
        for(int i = 0; i < c.Count; i++)
        {
            cards[c[i]].GetComponent<Card>().state = x;
            cards[c[i]].GetComponent<Card>().falseCheck();
        }

    }
}
