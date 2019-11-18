using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] Text textComponent;
    [SerializeField] State startingState;
    State state;

    // Use this for initialization
    void Start()
    {
        state = startingState;
        ChangeTextComponent();
    }

    void ChangeTextComponent()
    {
        textComponent.text = state.GetStoryText();
    }

    // Update is called once per frame
    void Update()
    {
        ManageState();
    }

    private void ManageState()
    {
        if (state.isEnd)
        {
            if (Input.GetKeyDown(KeyCode.R))
                state = startingState;
            return;
        }

        State[] nextStates = state.GetNextStates();

        for (int i = 0; i < nextStates.Length; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i))
                state = nextStates[i];
        }

        ChangeTextComponent();
    }
}
