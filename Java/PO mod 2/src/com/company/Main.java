package com.company;

import java.util.ArrayList;
import java.util.Collection;

public class Main {//Main space dove si inseriscono tutte le altre classi
    private int a;
    private void a(){};
    public static String s;//Quando un campo è static vuol dire che non c'è this nel right value cioè può
    // esistere senza l'istanza della classe che lo contiene
    protected static int n(int n){//Non c'è this dentro il blocco quindi può esistere senza l'istanza della classe
        return n*1;
    }
    private static class
    Internal{
        private float x;
        protected static class Another{ //La classe another può esistere senza che ci sia un'istanza della classe Internal
            //non ha senso fare una nested class statica di una nested class non statica

        }
        //La keyword static slega this dall'ambiente
        //In altre parole static rende reale quel membro senza istanziare la classe che lo contiene
    }





    public static class Animal{
        protected int weight;

        public void eat(Animal a){
            this.weight+=a.weight;
        }
    }
    public static class Humanoid extends Animal{
        public  void marry(Humanoid h){}
    }
    public static class Elf extends Humanoid{
        private int mana;
        public int getMana(){
            return mana;
        }
    }
    public static class Dwarf extends Humanoid{

    }

    public static class Dog extends Animal{
        public void bark(){};
        public void marry(Dog d){

        }
        public void eat(Animal a){
            this.weight+=a.weight/2; //this colui che mangia, this ha tipo Dog in questo momento
        }
    }
    public static class Cocker extends Dog{
        @Override
        public void eat(Animal a) {
                this.weight += a.weight/3; // In questo caso il this ha tipo cocker

            //this.weight += a.weight/3; // In questo caso il this ha tipo cocker
        }
    }
    public static class Cat extends Animal{
        public void meow(){
            System.out.println("meow");
        }
    }
    public static class Siamese extends Cat{
        @Override
        public void meow() {
            System.out.println("maaaauuuu");
        }
    }
    private static Dog makeAnimal(){
        return new Dog();
    }

    //public static class MyClass extends A implements B, C, D{}
    //A è una superclasse
    // B,C,D  sono interfacce
    //Myclass è sottoclasse si A e A è superclasse di Myclasse
    //MyClass è sottotipo di A,B,C,D



    public static class A<T>{ //T è un generic TypeParameter
        private T x;
        public void m(T o){

        }
    }

    //SUBTYPING Tipo di polimorfismo
    public static int f(int x){//x è il parametro
        return x*1;
    }

    public static void main(String[] args) {//Entry point

	    int n;
	    Dog a;
	    Animal fido = makeAnimal(); //Binding
	    Animal dodi= new Dog();
	    dodi=new Cat();
	    Dog lilly= new Dog();
	    fido.eat(dodi);    //SUBSUMPTION;

        int y=f(7); //7 è l'argomento

        Humanoid john = new Humanoid();
        Humanoid alice = new Humanoid();
        Elf tara=new Elf();

        john.marry(tara);
        tara.marry(john);

        Collection<Dog> dogs=new ArrayList<Dog>();//Il tipo della variabile dogs è Collection di Dog //Dog è il typeArgument
        //I Generics non subsumono


        dogs.add(lilly); //Il metodo add è il metodo dell'arrayList però è collection che impone ad arrayList di implementarlo

        A<Integer> d=new A<>(); //Integer TypeArgument

        //TypeInference è un servizio che propone il compilatore per capire il tipo




        //Si chiama Tipo Parametrico tutti i tipi che hanno dei generic ovvero dei Type Parameter
        //Differenza tra moduli e package
        //Moduli -> è una cosa nuova di java ed è una raccolta di package
        //Package -> raccolta ad albero

        //Generics -> Programmare in modo sicuro
        //I tipi che usiamo come typeArgument non devono perforza essere classi ma possono essere anche interfacce
        //SOUND NESS = Sicuro,ok ->Sicurezza

        //Tipi sono sia Interfacce che Classi
	    //lilly.marry(fido);  // non compila perche fido:Animal;

        //3 tipi di subsumption -> Nel tipo di ritorno di un metodo, nel parametro passato, nell'inizializzazione e nell'assegnamento;

        //T x = e; e deve avere un tipo minore o uguale di T;
        //Quando un oggetto viene passato come parametro ,Viene passato il reference all'oggetto e quindi non viene copiato
        //API -> applications programmer interface -> tutto ciò che è chiamabile dal programmatore - metodi ecc
        //l'API più usata in java è il JDK

        //Design patterns->Tecniche avanzate per programmare ad un livello più alto;

        //Tecniche di programmazione avanzate
        //1)Binary methods
    }
}
