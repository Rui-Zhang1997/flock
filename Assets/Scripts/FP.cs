using System;
using System.Collections.Generic;
class FP {
    public static R[] Map<T,R>(T[] items, Function.Fn1<T,R> fn) {
        R[] r = new R[items.Length];
        for (int i = 0; i < items.Length; i++) {
            r[i] = fn(items[i]);
        }
        return r;
    }

    public static T[] Filter<T, Boolean>(T[] items, Function.Fn1<T,bool> fn) {
        List<T> r = new List<T>();
        for (int i = 0; i < items.Length; i++) {
            if (fn(items[i])) {
                r.Add(items[i]);
            }
        }
        return r;
    }

    public static R[] FilterMap<T,R>(T[] items, Function.Fn1<T,R> fn, Function.Fn1<T,Boolean> cmp) {
        List<T> r = new List<T>();
        for (int i = 0; i < items.Length; i++) {
            if (cmp(items[i])) {
                r.Add(fn(items[i]));
            }
        }
        return r;
    }
}