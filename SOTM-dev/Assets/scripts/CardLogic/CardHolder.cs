using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardHolder : MonoBehaviour
{
    [SerializeField] private Card selectedCard;
    [SerializeReference] private Card hoverdCard;

    private bool dragging = false;

    public List<Card> cards;
    public List<Transform> cardSlots;

    private bool isCrossing;

    // Start is called before the first frame update

    private void Awake()
    {
        
    }
    void Start()
    {
        cards = GetComponentsInChildren<Card>().ToList();

        foreach (Card card in cards)
        {
            card.PointerEnterEvent.AddListener(CardPointerEnter);
            card.PointerExitEvent.AddListener(CardPointerExit);
            card.BeginDragEvent.AddListener(BeginDrag);
            card.EndDragEvent.AddListener(EndDrag);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!dragging)
            return;

        for (int i = 0; i < cards.Count; i++)
        {

            if (selectedCard.transform.position.x > cards[i].transform.position.x)
            {
                if (selectedCard.ParentIndex() < cards[i].ParentIndex())
                {
                    Swap(i);
                    break;
                }
            }

            if (selectedCard.transform.position.x < cards[i].transform.position.x)
            {
                if (selectedCard.ParentIndex() > cards[i].ParentIndex())
                {
                    Swap(i);
                    break;
                }
            }
        }
    }

    private void BeginDrag(Card card)
    {
        selectedCard = card;
        
        dragging = true;
    }


    void EndDrag(Card card)
    {
        if (selectedCard == null)
            return;

        selectedCard = null;
        dragging = false;
    }

    private void CardPointerEnter(Card card)
    {
        hoverdCard = card;
    }

    private void CardPointerExit(Card card)
    {
        hoverdCard = null;
    }

    void Swap(int index)
    {
        isCrossing = true;

        Transform focusedParent = selectedCard.transform.parent;
        Transform crossedParent = cards[index].transform.parent;

        cards[index].transform.SetParent(focusedParent);
        cards[index].transform.localPosition = Vector3.zero;
        selectedCard.transform.SetParent(crossedParent);

        isCrossing = false;

        //if (cards[index].cardVisual == null)
        //    return;

        //bool swapIsRight = cards[index].ParentIndex() > selectedCard.ParentIndex();
        //cards[index].cardVisual.Swap(swapIsRight ? -1 : 1);

        //Updated Visual Indexes
        //foreach (Card card in cards)
        //{
        //    card.cardVisual.UpdateIndex(transform.childCount);
        //}
    }

}
