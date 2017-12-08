using System;
using System.Collections.Generic;

namespace _08_DeckOfCard{
        public class Deck{
            public List <Card> Cards;
            
            public Deck Build(){
                Cards = new List<Card>();
                // create an array of suits
                string[] suits = {"Hearts", "Clubs", "Spades", "Diamonds"};
                // for each suit in suits
                foreach(string suit in suits){
                    for(int i = 1; i<14; i++){
                       Card newCard= new Card(suit, i);
                       Cards.Add(newCard);
                       
                    }
                }
                return this;

                }
            public Card Deal(){
                Card returnCard = Cards[0];
                Cards.RemoveAt(0);
                return returnCard;
            }
            public void Reset(){
            Cards =  new List <Card>();
            Build();
            }
            public void Shuffle(){
            Random rand = new Random();
            for( int i = 0; i< Cards.Count; i++){
                int randidx = rand.Next(i, Cards.Count);
                Card temp = Cards[randidx];
                Cards[randidx] = Cards[i];
                Cards[i] = temp;
                }
            }

        }       
}
