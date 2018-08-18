using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;


namespace CH11
{
    public class Cards: CollectionBase, ICloneable
    {
        public object Clone()
        {
            Cards newCards = new Cards();
            foreach (Card sourceCard in List)
            {
                newCards.Add((Card)sourceCard.Clone());
            }
            return newCards;
        }

        public void Add(Card newCard)
        {
            List.Add(newCard);
        }
        public void Remove(Card oldCard)
        {
            List.Remove(oldCard);
        }
        public Card this[int cardIndex]
        {
            get { return (Card)List[cardIndex]; }
            set { List[cardIndex] = value; }
        }
        public void CopyTo(Cards targetCards)
        {
            for (int index = 0; index < this.Count; index++)
            {
                targetCards[index] = this[index];
            }
        }
        public bool Contains(Card card) => InnerList.Contains(card);
    }
}
