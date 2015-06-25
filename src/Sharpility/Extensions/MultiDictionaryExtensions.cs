﻿using Sharpility.Collections;

namespace Sharpility.Extensions
{
    /// <summary>
    /// Extensions for MultiDictionary.
    /// </summary>
    public static class MultiDictionaryExtensions
    {
        /// <summary>
        /// Converts MultiDictionary to ImmutableMultiDictionary.
        /// If MultiDictionary is already immutable returns it.
        /// </summary>
        /// <typeparam name="TKey">Type of dictionary key</typeparam>
        /// <typeparam name="TValue">Type of dictionary value</typeparam>
        /// <param name="multiDictionary">Converted MultiDictionary</param>
        /// <returns>ImmutableMultiDictionary</returns>
        public static ImmutableMultiDictionary<TKey, TValue> ToImmutableMultiDictionary<TKey, TValue>(
            this MultiDictionary<TKey, TValue> multiDictionary)
        {
            if (multiDictionary is ImmutableMultiDictionary<TKey, TValue>)
            {
                return (ImmutableMultiDictionary<TKey, TValue>) multiDictionary;
            }
            if (multiDictionary is HashSetMultiDictionary<TKey, TValue>)
            {
                return ToImmutableSetMultiDictionary(multiDictionary);
            }
            return ToImmutableListMultiDictionary(multiDictionary);
        }

        /// <summary>
        /// Converts MultiDictionary to ImmutableListMultiDictionary.
        /// If MultiDictionary is already ImmutableListMultiDictionary returns it.
        /// </summary>
        /// <typeparam name="TKey">Type of dictionary key</typeparam>
        /// <typeparam name="TValue">Type of dictionary value</typeparam>
        /// <param name="multiDictionary">Converted MultiDictionary</param>
        /// <returns>ImmutableListMultiDictionary</returns>
        public static ImmutableListMultiDictionary<TKey, TValue> ToImmutableListMultiDictionary<TKey, TValue>(
            this MultiDictionary<TKey, TValue> multiDictionary)
        {
            if (multiDictionary is ImmutableListMultiDictionary<TKey, TValue>)
            {
                return (ImmutableListMultiDictionary<TKey, TValue>)multiDictionary;
            }
            var result = ImmutableListMultiDictionary<TKey, TValue>.Builder();
            result.PutAll(multiDictionary);
            return result.Build();
        }

        /// <summary>
        /// Converts MultiDictionary to ImmutableSetMultiDictionary.
        /// If MultiDictionary is already ImmutableSetMultiDictionary returns it.
        /// </summary>
        /// <typeparam name="TKey">Type of dictionary key</typeparam>
        /// <typeparam name="TValue">Type of dictionary value</typeparam>
        /// <param name="multiDictionary">Converted MultiDictionary</param>
        /// <returns>ImmutableSetMultiDictionary</returns>
        public static ImmutableSetMultiDictionary<TKey, TValue> ToImmutableSetMultiDictionary<TKey, TValue>(
            this MultiDictionary<TKey, TValue> multiDictionary)
        {
            if (multiDictionary is ImmutableSetMultiDictionary<TKey, TValue>)
            {
                return (ImmutableSetMultiDictionary<TKey, TValue>)multiDictionary;
            }
            var result = ImmutableSetMultiDictionary<TKey, TValue>.Builder();
            result.PutAll(multiDictionary);
            return result.Build();
        } 
    }
}
