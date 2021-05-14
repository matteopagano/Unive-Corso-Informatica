package com.company.generics;

import java.io.File;
import java.util.*;

public class TestCollection {

    private static Random r=new Random(10);
    //è buona norma usare la subsumption il più possibile perche il codice è più versatile(Per pproblemi di compatibilità)
    public static void populateCollection(Collection<Integer> c){
        for (int i=0;i< r.nextInt(100);++i){
            c.add(i);
        }
    }
    //Iterable -> Iterabile, una cosa che può essere iterata, ha un suo type parameter
    public static void printCollection(Iterable<Integer> c){
        Iterator<Integer> it=c.iterator();
        while(it.hasNext()){
            int n=it.next();//Esegue,ordinatamente,prima ritorna l'oggetto su cui è sopra poi si sposta in avanti
            System.out.println(n);
        }
        //Zucchero sintattico dell'iteratore
        for(Integer n:c){
            System.out.println(n);
        }
        // For each è uno Zucchero Sintattico
        /*for(T x : e){
            st1;
            ..
            stn;
        }
        // For Each si dezucchera in :
         Iterator<T> it = new e.iterator();
         while(it.hasNext()){
             T x = it.next();
             st1;
             ...
             stn;
         }

        for(ArrayList<File>  miavariabile : new LinkedList<ArrayList<File>>()){
            System.out.println(miavariabile.size());
        }

        Iterator<ArrayList<File>> it1= new LinkedList<ArrayList<File>>().iterator();
        while(it.hasNext()){
            ArrayList<File> miaVariabile=it1.next();
            System.out.println(miaVariabile.size());
        }

        //Si programma sempre utilizzando codice più alto che si possa fare (Gerarchia delle classi)
        //Bisogna guardare se esistono nell'interfaccia i metodi da utilizzare nella funzione
        */

    }
    //Dato che usa nello zuccher sintattico del for each l'iterator c deve essere almeno un tipo che implementa iterable e la funzione size
    // Questo tipo deve essere perforza Collection
    public static double average(Collection<Integer> c){
        double r =0;
        for (int n : c){
            r += n;
        }
        return r / c.size();
    }
    //Overloading -> algoritmo di static dispatching-> è il compilatore che decide cosa chiamare
    public static double median(List<Integer> c){
        return c.get(c.size()/2);
    }
    public static double median(Collection<Integer> c){
        Iterator<Integer> it = c.iterator();
        int r=0;
        for(int i=0;i< c.size();++i){
            r=it.next();
        }
        return r;
    }

    public static void main(String[] args) {

        ArrayList<Integer> c=new ArrayList<>();
        populateCollection(c);
        printCollection(c);
        //Dato che esistono 2 metodi median, il copilatore sceglie di utilizzare quello che ha il il genitore più vicino con la Subsumption
        //la median(List) ha la subsumption più specializzata (più vicina ad arrayList) percui chiama quella.
        System.out.println(String.format("avg = %g,median = %d", average(c), median(c)));

        Collection<Integer> c1=new LinkedList<>();
        populateCollection(c1);
        printCollection(c1);

        Collection<Integer> c2=new ArrayList<>();
        populateCollection(c2);
        printCollection(c2);

        Collection<Integer> c3=new HashSet<>();
        populateCollection(c3);
        printCollection(c3);

    }

}
