using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mapbox.Unity.MeshGeneration.Interfaces;

public class ParkInfoSetter : MonoBehaviour, IFeaturePropertySettable
{
    public Text title;
    public Text description;

    public void Set(Dictionary<string, object> props)
    {
        if(props.ContainsKey("title"))
        {
            title.text = props["title"].ToString();
        }
        if(props.ContainsKey("description"))
        {
            description.text = props["description"].ToString();
        }
    }
}
