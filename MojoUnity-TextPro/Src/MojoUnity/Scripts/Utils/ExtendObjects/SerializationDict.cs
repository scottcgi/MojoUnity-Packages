/*
 * Copyright (c) scott.cgi All Rights Reserved.
 *
 * This source code belongs to project MojoUnity-Packages, which is hosted on GitHub, and licensed under the MIT License.
 *
 * License: https://github.com/scottcgi/MojoUnity-Packages/blob/main/LICENSE
 * GitHub : https://github.com/scottcgi/MojoUnity-Packages
 * Package: https://github.com/scottcgi/MojoUnity-Packages/tree/main/MojoUnity-TextPro
 *
 * Since  : 2021-5-28
 * Update : 2021-5-28
 * Author : scott.cgi
 */

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace MojoUnity
{
    [Serializable]
    public class SerializationSpriteDict : SerializationDict<string, Sprite>     { }
    [Serializable]
    public class SerializationEventDict  : SerializationDict<string, UnityEvent> { }


    /// <summary>
    /// Before Unity-2020 do not support serialization generic type in Inspector.
    /// So custom SerializationDict needs to inherit SerializationDict<TKey, TValue>.
    /// But from Unity-2020 we can use SerializationDict<TKey, TValue> directly.
    /// </summary>
    [Serializable]
    public class SerializationDict<TKey, TValue> : Dictionary<TKey, TValue>
    {
        public TKey  [] serializationKeys;
        public TValue[] serializationValues;


        /// <summary>
        /// Set serializationKeys by serializationValues.
        /// </summary>
        public void SetSerializationKeys(Func<TValue, TKey> GetKey)
        {
            if (this.serializationValues != null)
            {
                var len = this.serializationValues.Length;

                if (this.serializationKeys == null || this.serializationKeys.Length != len)
                {
                    this.serializationKeys = new TKey[len];
                }

                for (var i = 0; i < len; ++i)
                {
                    this.serializationKeys[i] = GetKey(this.serializationValues[i]);
                }
            }
        }


        /// <summary>
        /// Sync serialization keys and values.
        /// </summary>
        public void SyncSerializationKeysAndValues()
        {
            if (this.serializationValues != null)
            {
                var len = this.serializationValues.Length;

                if (this.serializationKeys == null)
                {
                    this.serializationKeys = new TKey[len];
                }
                else if (this.serializationKeys.Length != len)
                {
                    var newKeys = new TKey[len];

                    if (this.serializationKeys.Length > len)
                    {
                        Array.Copy(this.serializationKeys, newKeys, len);
                    }
                    else if (this.serializationKeys.Length < len)
                    {
                        this.serializationKeys.CopyTo(newKeys, 0);
                    }
                    
                    this.serializationKeys = newKeys;
                }
            }
        }


        /// <summary>
        /// Copy Dict into serialization keys and values.
        /// </summary>
        public void Serialize()
        {
            var len                  = this.Count;
            this.serializationKeys   = new TKey  [len];
            this.serializationValues = new TValue[len];

            this.Keys  .CopyTo(this.serializationKeys,   0);
            this.Values.CopyTo(this.serializationValues, 0);
        }


        /// <summary>
        /// Copy serialization keys and values into Dict.
        /// </summary>
        public void Deserialize()
        {
            if (this.serializationValues != null)
            {
                this.Clear();

                var len = Mathf.Min(this.serializationKeys.Length, this.serializationValues.Length);
                for (var i = 0; i < len; ++i)
                {
                    var key = this.serializationKeys[i];

                    if (this.ContainsKey(key) == false)
                    {
                        this.Add(key, this.serializationValues[i]);
                    }
                    else
                    {
                        this[key] = this.serializationValues[i];
                    }
                }
            }
        }
    }
}

