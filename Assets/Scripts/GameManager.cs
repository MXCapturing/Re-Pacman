using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum GhostState
{
    Scatter = 0,
    Chase = 1,
    Frightened = 2
}

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GhostState ghostState;

    public int dotCount;
    public int points;
    public TMP_Text pointText;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        pointText.text = "0";
        StartCoroutine(GhostSwitchTimer());
    }

    IEnumerator GhostSwitchTimer()
    {
        ghostState = GhostState.Scatter;
        yield return new WaitForSeconds(10f);
        ghostState = GhostState.Chase;
        yield return new WaitForSeconds(20f);
        ghostState = GhostState.Scatter;
        yield return new WaitForSeconds(10f);
        ghostState = GhostState.Chase;
        yield return new WaitForSeconds(20f);
        ghostState = GhostState.Scatter;
        yield return new WaitForSeconds(7f);
        ghostState = GhostState.Chase;
        yield return new WaitForSeconds(20f);
        ghostState = GhostState.Scatter;
        yield return new WaitForSeconds(7f);
        ghostState = GhostState.Chase;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
