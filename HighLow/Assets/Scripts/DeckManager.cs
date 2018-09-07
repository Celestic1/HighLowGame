using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckManager : MonoBehaviour {

    public GameObject CardPrefab;
    public GameObject CardPosition1;
    public GameObject CardPosition2;
    int FirstCardValue, SecondCardValue, FirstCardSuit, SecondCardSuit;
    private Sprite cardsprite1, cardsprite2;
    public GameObject card1, card2;
    public Text ValueText, SuitText;    
    float speed = 0.1f; 


	// Use this for initialization
	void Start () {
        ValueText.enabled = false;
        SuitText.enabled = false;
        checkDuplicateCard();
	}

    // Simulates drawing one card at a time and only check high or low when both cards are flipped.
    void Update()
    {
        if (card1.transform.position != CardPosition1.transform.position)
        {
            card1.transform.position = new Vector3(card1.transform.position.x - speed, 0, 0);
        }

        if (card1.transform.position == CardPosition1.transform.position && card2.transform.position != CardPosition2.transform.position)
        {
            card2.transform.position = new Vector3(card2.transform.position.x - speed, 0, 0);
        }

        if (card1.gameObject.GetComponent<CardFaces>().isFlipped && card2.gameObject.GetComponent<CardFaces>().isFlipped)
        {
            checkHighorLow();
        }
    }

    // check if first card and second card are duplicates. And if they are, keep picking a new card until they are not dupliates.
    void checkDuplicateCard()
    {
        FirstCardValue = card1.gameObject.GetComponent<CardFaces>().value;
        FirstCardSuit = card1.gameObject.GetComponent<CardFaces>().suit;

        SecondCardValue = card2.gameObject.GetComponent<CardFaces>().value;
        SecondCardSuit = card2.gameObject.GetComponent<CardFaces>().suit;

        while((FirstCardValue==SecondCardValue) && (FirstCardSuit == SecondCardSuit))
        {
            int RandomCardIndex = card2.gameObject.GetComponent<CardFaces>().getShuffledCard();
            card2.gameObject.GetComponent<CardFaces>().setCardInfo(RandomCardIndex);
            card2.gameObject.GetComponent<CardFaces>().setCardSprite(RandomCardIndex);
            SecondCardValue = card2.gameObject.GetComponent<CardFaces>().value;
            SecondCardSuit = card2.gameObject.GetComponent<CardFaces>().suit;
        }
    }

    // checks each card's suit and value and changes text corresponding the rules of high or low.
    void checkHighorLow()
    {
        ValueText.enabled = true;
        SuitText.enabled = true;

        FirstCardValue = card1.gameObject.GetComponent<CardFaces>().value;
        FirstCardSuit = card1.gameObject.GetComponent<CardFaces>().suit;

        SecondCardValue = card2.gameObject.GetComponent<CardFaces>().value;
        SecondCardSuit = card2.gameObject.GetComponent<CardFaces>().suit;

        if (SecondCardValue > FirstCardValue)
        {
            ValueText.text = "Higher Value ";
        }
        else if (SecondCardValue < FirstCardValue)
        {
            ValueText.text = "Lower Value ";
        }
        else
        {
            ValueText.text = "Same Value ";
        }

        if (SecondCardSuit > FirstCardSuit)
        {
            SuitText.text = "Higher Suit";
        }
        else if (SecondCardSuit < FirstCardSuit)
        {
            SuitText.text = "Lower Suit";
        }
        else
        {
            SuitText.text = "Same Suit";
        }
    }

}
