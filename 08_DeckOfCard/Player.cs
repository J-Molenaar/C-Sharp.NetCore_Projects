using System;
using System.Collections.Generic;

namespace _08_DeckOfCard
{
public class Player
    {
        public string Name{get; set;}
        public List<Card> Hand{get; set;}
        public Player(string name){
            Name = name;
            Hand = new List<Card>();
        }
        public Card Draw(Deck Deck){
            Card DealtCard = Deck.Deal();
            Hand.Add(DealtCard);
            return DealtCard;
        }
        public Card Discard(int val){
            val --;
            if(val > Hand.Count){
                System.Console.WriteLine("You do not have that many cards");
                return null;
            }
            else{
                Card returnCard = Hand[val];
                Hand.RemoveAt(val);
                return returnCard;
            }
        } 
            public void Kat(){
                System.Console.WriteLine("            A___A  ");
                System.Console.WriteLine("           ( o o ) ");
                System.Console.WriteLine("           > _Y_ <  ");
                System.Console.WriteLine("             `-'    ");
                System.Console.WriteLine("  Welcome to Exploding Kittens! ");
                System.Console.WriteLine(" ");
                System.Console.WriteLine("How to Play:");
                System.Console.WriteLine("1: Each player a takes turn a drawing a card.");
                System.Console.WriteLine("2: You can get: a Kitten card (like TacoCat), a See The Future card, a Shuffle card, an Attack card or an EXPLODING KITTEN card.");
                System.Console.WriteLine("3: If you get an EXPLODING KITTEN, YOU A DEAD KITTY and by that we mean you lose!");
                System.Console.WriteLine("4: If you get a Kitten card, congratulations! The card is added to your hand and you are still alive.");
                System.Console.WriteLine("5: If you get a See The Future card, the card is added to your hand. You can play this anytime to SEE the top 3 cards in the deck.");
                System.Console.WriteLine("6: If you get a Shuffle card, the card is added to your hand. You can play this anytime to reshuffle the deck");
                System.Console.WriteLine("5: If you get an Attack card, the card is added to your hand. You can play this anytime and force the top two cards from the deck into the player's hand.");
            }
        public void Boom(){
            System.Console.WriteLine(" oooooooooo    ooooooo      ooooooo    oooo    ooo    oo    oo    oo  ");
            System.Console.WriteLine(" 888    888  o888   888o  o888   888o  8888o   888   8888  8888  8888 ");
            System.Console.WriteLine(" 888oooo88   888     888  888     888  88 888o8 88   8888  8888  8888 ");
            System.Console.WriteLine(" 888    888  888o   o888  888o   o888  88  888  88    88    88    88  ");
            System.Console.WriteLine(" o888ooo888    88ooo88      88ooo88   o88o  8  o88o    *    *      *  ");
            System.Console.WriteLine("  ");
            System.Console.WriteLine(" YOU A DEAD KITTY!");

        }
    }  
}
