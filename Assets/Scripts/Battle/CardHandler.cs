using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class CardHandler : MonoBehaviour
{
    private int curSelectionInt;
    private int lastSelectionInt;

    public int maxRange;
    public int minRange; 

    public List<ButtonHandler> buttons;
    private PlayerInputAction inputs;
    private float inputsCurrentVal;

    private bool selectingBool;

    void OnEnable()
    {
        inputs = new PlayerInputAction();
        inputs.UI.Enable();
    }

    void Update()
    {
        inputsCurrentVal = inputs.UI.Navigation.ReadValue<float>();
        lastSelectionInt = curSelectionInt;

        NavigationHandling();

        //makes sure it doesn't go over the max amount allowed
        if (curSelectionInt < minRange)
        {
            curSelectionInt = maxRange;
        }else if (curSelectionInt > maxRange)
        {
            curSelectionInt = minRange;
        }

        //checks if there has been a change in the input
        if (lastSelectionInt != curSelectionInt)
        {
            for(int i = 0; i < buttons.Count; i++)
            {
                if (buttons[i].selectionInt == curSelectionInt)
                {
                    buttons[i].isButtonSelected = true;
                }
                else
                {
                    buttons[i].isButtonSelected = false;
                }
            }
        }
    }

    void NavigationHandling()
    {

        //checks for which input to put
        if (inputsCurrentVal >= 1)
        {
            if (selectingBool) return;
            selectingBool = true;
            curSelectionInt += 1;
        }
        else if (inputsCurrentVal <= -1)
        {
            if (selectingBool) return;
            selectingBool = true;
            curSelectionInt -= 1;
        }
        else
        {
            selectingBool = false;
        }

    }
}
