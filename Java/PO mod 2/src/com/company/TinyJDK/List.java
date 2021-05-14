package com.company.TinyJDK;

public interface List<T> extends Collection<T>{
    T get(int index);
    void set(int index,T x);

}
