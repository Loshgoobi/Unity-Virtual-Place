using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorPathScript : MonoBehaviour {

    /// <summary>
    /// Color of the path in the editor
    /// </summary>
    public Color rayColor = Color.black;
    /// <summary>
    /// List of the objects composing the path
    /// </summary>
    public List<Transform> path_objs = new List<Transform>();
    /// <summary>
    /// Looks through all the children of the main object
    /// </summary>
    Transform[] theArray;

    void OnDrawGizmos()
    {
        Gizmos.color = rayColor;
        theArray = GetComponentsInChildren<Transform>();
        path_objs.Clear();

        foreach (Transform path_obj in theArray)
        {
            if(path_obj != this.transform)
            {
                path_objs.Add(path_obj);
            }
        }
        
        for (int i = 0; i < path_objs.Count; i++)
        {
            Vector3 position = path_objs[i].position;
            if( i > 0 )
            {
                Vector3 previous = path_objs[i - 1].position;
                Gizmos.DrawLine(previous, position);
                Gizmos.DrawWireSphere(position, 0.3f);
            }
        }
    }
}
