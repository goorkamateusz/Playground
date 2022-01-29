using UnityEngine;

namespace Goo.Tools
{
    public static class OptionalComponentsHelper
    {
        public static T Null<T>(this T unityObject) where T : Object
        {
            if (unityObject == null)
                return null;
            return unityObject;
        }
    }
}