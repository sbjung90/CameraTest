using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    public class AutoList <T>
    {
        public static List<Type> typeList = new();

        public AutoList()
        {
            typeList.Add(typeof(T));
        }

        ~AutoList()
        {
            typeList.Remove(typeof(T));
        }
    }
}
