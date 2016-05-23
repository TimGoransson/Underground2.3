using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StatusIndicator : MonoBehaviour {

    [SerializeField]
    private RectTransform healthBarRect;

    void Start()
    {
        if(healthBarRect == null)
        {
            Debug.Log("no healthbar");
        }
    }
	public  void SetHealth(float curr, float max)
    {
        float value = (float) curr / max;

        healthBarRect.localScale =new Vector3(value, healthBarRect.localScale.y, healthBarRect.localScale.z);
    }
    
}
