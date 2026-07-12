using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public int woodCount = 0;
    public int woodRequiredToWin = 10;

    public void AddWood(int amount)
    {
        woodCount += amount;
        Debug.Log("Wood Collected! Current Total: " + woodCount + " / " + woodRequiredToWin);
    }
}
