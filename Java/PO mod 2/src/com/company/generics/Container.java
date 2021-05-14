package com.company.generics;

import com.company.Main;

import java.util.ArrayList;

public class Container {
    //forme di polimorfismo
    //SubTyping-> Tipi in relazione d'ereditarietà tra loro ->Polimorfismo Verticale
    //Generics-> Orizzontale

    //Tipo di lista Monoforma (In questo caso di Int)
    public static class MyIntList{

        private final int[] a;
        private int cnt;

        public MyIntList() {
            this.a = new int[100];
            cnt=0;
        }

        public void add(int v) {
            a[cnt++]=v;
        }

        public int size() {
            return cnt;
        }

        public int get(int i) {
            return a[i];
        }
    }

    //Tipo di lista Polimorfa con subTyping
    public static class MyList{

        private final Object[] a;
        private int cnt;

        public MyList() {
            this.a = new Object[100];
            cnt=0;
        }

        public void add(Object v) {
            a[cnt++]=v;
        }

        public int size() {
            return cnt;
        }

        public Object get(int i) {
            return a[i];
        }
    }

    //Tipo di Lista Polimorfa con Generics
    //Classe parametrica o classe generica
    //Tipo che ha come parametro un altro tipo
    //public static class MyGenList<T extends Number>{ //UpperBound vincolo sul Type argument->Posso creare
        // una MyGenList solo con Type argument di tipi che estendono Number!!!

    public static class MyGenList<T>{

        private final Object[] a;
        private int cnt;

        public MyGenList() {
            //this.a = new T[100];//Non si possono costruire array di cui tipo sono generics ->WorkAround -> Trucco per farlo funzionare
            this.a = new Object[100];
            cnt=0;
        }

        public void add(T v) {
            a[cnt++]=v;
        }

        public int size() {
            return cnt;
        }

        public T get(int i) {
            return (T)a[i]; //DownCast
        }
    }

    public static void main(String[] args) {

        //Scope Artificiale -> dentro uno scope si possono usare nomi per viarbili usate da altre parti sempre sulla stessa funzione
        //Monomorfo per Int
        {
            //Costruzione
            MyIntList l = new MyIntList();
            //Popolamento
            for (int i = 0; i < 10; ++i) {
                l.add(i);
            }
            //Lettura
            for (int i = 0; i < l.size(); ++i) {
                System.out.println(l.get(i));
            }
        }
        //Polimorfo SubTyping
        //Vantaggi -> Mi permette di fare un solo container con tipi diversi
        //Svantaggi -> Si deve castare e si ha solo object -> errori a RunTime e crash
        {
            //Costruzione
            MyList l = new MyList();
            //Popolamento
            for (int i = 0; i < 10; ++i) {
                l.add(i);
                //l.add((double)i);//Questo non è un cast ma una conversione da int a double
            }

            //6 : int = 00000000 00000000 00000000 00000110
            //
            //
            //


            l.add("ciao");
            l.add(6.78);
            l.add(new ArrayList<Integer>());
            //Lettura
            //Uplifting fare il binding di una funzione ad una variabile
            for (int i = 0; i < l.size(); ++i) {

                //String x=(String)l.get(i); //Downcast -> quel pointer non sta più puntatndo ad un
                // Object ma ad una Stringa(Vale sempre la regola che un tipo può essere castato solamente ad un tipo minore o sottotipo
                //String y=x.toLowerCase();
                //System.out.println(x);
            }
        }

        //Polimorfo Generics
        //Vantaggi->
        //Svantaggi->
        {
            //Costruzione
            MyGenList<Integer> l = new MyGenList<>();
            //Popolamento
            for (int i = 0; i < 10; ++i) {
                l.add(i);
            }

            //Lettura
            //Uplifting fare il binding di una funzione ad una variabile
            for (int i = 0; i < l.size(); ++i) {

                Integer x=(l.get(i)); //Downcast -> quel pointer non sta più puntatndo ad un Object ma ad una Stringa

                System.out.println(x);
            }
        }
        {
            MyGenList<Main.Animal> l=new MyGenList<>();
            l.add(new Main.Dog());
            l.add(new Main.Cat());
            l.add(new Main.Cocker());

            //Lettura
            for (int i=0;i<l.size();++i){
                Main.Animal n=l.get(i);
                System.out.println(n);
            }

        }

    }
}
