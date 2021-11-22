using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Mapbox.Unity.MeshGeneration.Interfaces;

public class EvacuationSetter : MonoBehaviour, IFeaturePropertySettable
{
    public Text[] setValueTexts;
    public Text[] activateTexts;

    private Dictionary<GameObject, string> objectKeyMap = new Dictionary<GameObject, string>();

    void Awake()
    {
        foreach(var text in setValueTexts.Concat(activateTexts))
        {
            objectKeyMap[text.gameObject] = text.text;
        }
    }

    public void Set(Dictionary<string, object> props)
    {
        foreach(var text in setValueTexts)
        {
            string key = objectKeyMap[text.gameObject];
            if (props.ContainsKey(key))
            {
                text.text = props[key].ToString();
            }
        }
        foreach (var text in activateTexts)
        {
            string key = objectKeyMap[text.gameObject];
            bool active = props.ContainsKey(key) && props[key].ToString() == "◎";
            text.gameObject.SetActive(active);
        }
    }
}
