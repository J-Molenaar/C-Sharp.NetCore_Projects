namespace _08_DeckOfCard{
public class Card{
        public string StringVal{
            get{
                if(Value > 1 && Value<11){
                    return Value.ToString();
                }
                if(Value == 11){
                    return "Jack";
                }
                if(Value == 12){
                    return "Queen";
                }
                if(Value == 13){
                    return "King";
                }
                if(Value == 1){
                    return "Ace";
                }
                else{
                    return "Joker";
                }
            } 
        }
        public string Suit{get; set;}
        public int Value {get; set;}
        public Card(string suit, int val ){
            Suit = suit;
            Value = val;
        }
    }

}