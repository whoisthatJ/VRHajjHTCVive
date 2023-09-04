using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FittingRoomManager : MonoBehaviour
{
    //[SerializeField] Oculus.Interaction.Samples.SceneLoader sceneLoader;
    [SerializeField] Animator doorsAnimator;
    [SerializeField] UnityEngine.Video.VideoPlayer tutorialPlayer;
    private const string ANIMATION_TRIGGER_OPEN = "Open";
    private const string ANIMATION_TRIGGER_CLOSE = "Close";
    private const string ANIMATION_TRIGGER_EXIT = "Exit";
    private const string NEXT_SCENE_NAME = "Test";

    private bool fitRoomEntered;


    public void DoorClicked(int id)
    {
        if (id == 1)
            FitDoorClicked();
        else
            ExitDoorClicked();
    }

    public void FitDoorClicked()
    {
        doorsAnimator.SetTrigger(ANIMATION_TRIGGER_OPEN);
    }
    public void FitRoomEntered()
    {
        doorsAnimator.SetTrigger(ANIMATION_TRIGGER_CLOSE);
        tutorialPlayer.Play();
        fitRoomEntered = true;
    }
    public void ExitDoorClicked()
    {
        if (fitRoomEntered)
        {
            doorsAnimator.SetTrigger(ANIMATION_TRIGGER_EXIT);
            //sceneLoader.Load(NEXT_SCENE_NAME);
            UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(NEXT_SCENE_NAME);
        }
    }
}
