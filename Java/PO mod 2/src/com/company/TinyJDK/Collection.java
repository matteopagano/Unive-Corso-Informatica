package com.company.TinyJDK;

public interface Collection <T> extends Iterable<T>{//Dalla e di extends in poi la T (Generic) esiste e la T di Iterable è il tipe Argument
    void add(T x);
    boolean contains(T x);
    int size();
    void remove(T x);

}
