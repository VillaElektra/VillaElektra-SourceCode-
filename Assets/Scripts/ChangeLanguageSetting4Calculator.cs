
using System.Globalization;
using System.Threading;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

/*
This script is necessary for the calculator.  System Language of systems can be different en may cause problems with . and , decimal numbers.
This script fixes that
*/

#if UNITY_EDITOR
[InitializeOnLoad]
public static class FixCultureEditor
{
    static FixCultureEditor()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
    }
}
#endif
 
public static class FixCultureRuntime
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void FixCulture()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
    }
}
