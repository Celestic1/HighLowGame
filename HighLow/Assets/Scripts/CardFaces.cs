using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardFaces : MonoBehaviour {

    public Sprite[] faces;
    public int[] indexArray = new int[52];
    SpriteRenderer cardsprite;
    public GameObject cardBack;
    public GameObject cardFront;
    int CardIndex;
    public int value { get; set; }
    public int suit { get; set; }
    public bool isFlipped = false;

    void Start()
    {
        for (int i = 0; i < indexArray.Length; i++)
        {
            indexArray[i] = i;
        }
        Shuffle(indexArray);
        cardBack.SetActive(true);
        cardFront.SetActive(false);
        cardsprite = cardFront.gameObject.GetComponent<SpriteRenderer>();
        CardIndex = getShuffledCard();
        setCardInfo(CardIndex);

        //Debug.Log("value: " + value + " suit: " + suit);
        cardsprite.sprite = faces[CardIndex];
    }

    public void setCardSprite(int CardIndex)
    {
        cardsprite = cardFront.gameObject.GetComponent<SpriteRenderer>();
        cardsprite.sprite = faces[CardIndex];
    }

    public void setCardInfo(int CardIndex)
    {
        if (CardIndex < 13)
        {
            value = CardIndex + 1;
            suit = 2;
        }
        else if (CardIndex >= 13 && CardIndex < 26)
        {
            value = CardIndex + 1 - 13;
            suit = 1;
        }
        else if (CardIndex >= 26 && CardIndex < 39)
        {
            value = CardIndex + 1 - 26;
            suit = 3;
        }
        else
        {
            value = CardIndex + 1 - 39;
            suit = 4;
        }
    }

    public int getRandomCard()
    {
        return Random.Range((int)0, (int)51);
    }

    public int getShuffledCard()
    {
        int index = getRandomCard();
        return indexArray[index];
    }


    void flipCard()
    {
        cardBack.SetActive(false);
        cardFront.SetActive(true);
        isFlipped = true;
    }

    void OnMouseDown()
    {
        flipCard();
    }

    public void Shuffle(int[] ints)
    {
        int temp;
        for (int i = 0; i < indexArray.Length; i++)
        {
            temp = ints[i];
            int swapIndex = getRandomCard();
            ints[i] = ints[swapIndex];
            ints[swapIndex] = temp;
        }
    }
}
