using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameUIScript : MonoBehaviour
{
    UIDocument uidoc;

    Label labelPointsCount;
    Label labelStartGameMessage;

    // Start is called before the first frame update
    void Start()
    {
        uidoc = GetComponent<UIDocument>();

        labelPointsCount = uidoc.rootVisualElement.Q<Label>("PointsCount");
        labelStartGameMessage = uidoc.rootVisualElement.Q<Label>("StartGameMessage");
    }

    public void ChangePointsCount(int pointsCount)
    {
        labelPointsCount.text = $"Счёт: {pointsCount}";
    }

    public void ChangeStartGameMsgVisibility(bool inIsVisible)
    {
        if (inIsVisible)
        {
            labelStartGameMessage.style.display = DisplayStyle.Flex;
        }
        else
        {
            labelStartGameMessage.style.display = DisplayStyle.None;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
