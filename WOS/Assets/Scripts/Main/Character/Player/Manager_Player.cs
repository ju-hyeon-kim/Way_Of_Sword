using UnityEngine;

public class Manager_Player : MonoBehaviour
{
    int myGold;

    public myGold_Text myGold_Text;

    /*public int _myGold 
    {
        get => myGold;        
        set => myGold = value;
    }*/

    private void Start()
    {
        myGold_Text.Change_Gold(myGold);
    }

    public void PlusGold(int price)
    {
        myGold += price;
        myGold_Text.Change_Gold(myGold);
    }

    public void MinusGold(int price)
    {
        myGold -= price;
        myGold_Text.Change_Gold(myGold);
    }
}
