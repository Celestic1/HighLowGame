using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardFaces : MonoBehaviour {

    public Sprite[] faces;
    public int[] indexArray = new int[52];
    public int[] weights;
    SpriteRenderer cardsprite;
    public GameObject cardBack;
    public GameObject cardFront;
    int CardIndex;
    public int value { get; set; }
    public int suit { get; set; }
    public bool isFlipped = false;
    public int weightTotal;

    // initalizes weights array, weightedTotal, deck index array, and card fields.
    void Start()
    {
        weights = new int[52];
        for (int i = 0; i < weights.Length; i++)
        {
            if (i == 39)
            {
                weights[i] = 3;
            }
            else if (i >= 26 && i <= 38)
            {
                weights[i] = 2;
            }
            else {
                weights[i] = 1;
            }
            weightTotal += weights[i];
        }
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

    // sets card sprite corresponding to index of sprite array
    public void setCardSprite(int CardIndex)
    {
        cardsprite = cardFront.gameObject.GetComponent<SpriteRenderer>();
        cardsprite.sprite = faces[CardIndex];
    }

    // sets card info based on the index of sprite array
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

    // Returns a index from RandomWeighted function
    public int getRandomCard()
    {
        return RandomWeighted();
        //return Random.Range((int)0, (int)51);
    }

    // grabs weighted probability for 2x hearts and 3x ace of spades.
    int RandomWeighted()
    {
        int result = 0, total = 0;
        int randomValue = Random.Range(0, weightTotal + 1);
        for (result = 0; result < weights.Length; result++)
        {
            total += weights[result];
            if (total >= randomValue)
            {
                break;
            }
        }
        return result;
    }

    // gets a card fromt he shuffled deck
    public int getShuffledCard()
    {
        int index = getRandomCard();
        return indexArray[index];
    }

    // flips card 
    void flipCard()
    {
        cardBack.SetActive(false);
        cardFront.SetActive(true);
        isFlipped = true;
    }

    // checks for mouse click to flip card
    void OnMouseDown()
    {
        flipCard();
    }

    // shuffles an int array corresponding to each card
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
