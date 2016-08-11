using System.Collections;
using UnityEngine;

namespace Assets.strangerocks
{
    public interface IRoutineRunner
    {
        Coroutine StartCoroutine(IEnumerator method);
    }
}
