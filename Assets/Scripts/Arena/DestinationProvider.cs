using System.Collections;
using UnityEngine;

namespace Arena
{
    public abstract class DestinationProvider : MonoBehaviour
    {
        public abstract bool GetDestination(out Vector3 destination);
    }
}