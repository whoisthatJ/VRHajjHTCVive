using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlHaramTutorialManager : MonoBehaviour
{
    [SerializeField] private GameObject infoWindow;
    [SerializeField] private ArrowBehaviour arrows;
    [SerializeField] private Transform kaabaTrigger;
    [SerializeField] private Transform[] aroundKaabaTriggers;

    [SerializeField] private Transform safaTrigger;
    [SerializeField] private Transform mauraTrigger;
    [SerializeField] int aroundKaabaCountGoal = 8;
    // Start is called before the first frame update
    void Start()
    {
        arrows.SetTarget(kaabaTrigger);
    }
    public void KaabaReached()
    {
        Debug.Log("KaabaReached");
        kaabaTrigger.gameObject.SetActive(false);
        AroundKaabaStart();
    }
    void AroundKaabaStart()
    {
        aroundKaabaTriggers[0].gameObject.SetActive(true);
        arrows.SetTarget(aroundKaabaTriggers[0]);
    }
    int aroundKaabaCount;
    public void AroundKaabaReached()
    {
        aroundKaabaTriggers[aroundKaabaCount % 4].gameObject.SetActive(false);
        aroundKaabaCount++;
        if (aroundKaabaCount >= aroundKaabaCountGoal)
        {
            infoWindow.SetActive(true);
            arrows.PlaceObjectNearPlayer(infoWindow.transform);
            SafaStart();
        }
        else
        {
            aroundKaabaTriggers[aroundKaabaCount % 4].gameObject.SetActive(true);
            arrows.SetTarget(aroundKaabaTriggers[aroundKaabaCount % 4]);
        }
    }
    void SafaStart()
    {
        safaTrigger.gameObject.SetActive(true);
        arrows.SetTarget(safaTrigger);
    }
    int mauraSafaCount;
    public void SafaReached()
    {
        if (mauraSafaCount == 0)
        {
            safaTrigger.gameObject.SetActive(false);
            MauraSafaStart();
        }
        else
        {
            MauraSafaReached();
        }
    }
    void MauraSafaStart()
    {
        mauraTrigger.gameObject.SetActive(true);
        arrows.SetTarget(mauraTrigger);
    }
    public void MauraSafaReached()
    {
        mauraSafaCount++;
        if (mauraSafaCount >= 14)
        {
        }
        else
        {
            if (mauraSafaCount % 2 > 0)
            {
                mauraTrigger.gameObject.SetActive(false);
                safaTrigger.gameObject.SetActive(true);
                arrows.SetTarget(safaTrigger);
            }
            else
            {
                safaTrigger.gameObject.SetActive(false);
                mauraTrigger.gameObject.SetActive(true);
                arrows.SetTarget(mauraTrigger);
            }
        }
    }
}
