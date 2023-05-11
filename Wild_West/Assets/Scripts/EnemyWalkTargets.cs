using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalkTargets : MonoBehaviour
{
    public Transform[] _targets;

    int _index = 0;
    public Transform GetCurrentTargetPoint() {

        var t = _targets[_index];      

        return t;

    }

    public void NextTarget()
    {
        _index++;
        _index = (_index >= _targets.Length) ? 0 : _index;
    }

}
