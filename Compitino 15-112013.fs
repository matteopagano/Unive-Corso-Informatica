(*
Esercizio 1. Definire una funzione ricorsiva compress: ’a list -> ’a list che data una lista di
elementi l restituisca la lista ottenuta da l sostituendo ogni sequenza di elementi uguali e contigui in
l con una sola occorrenza di tali elementi.
Per esempio:
# compress [1;1;2;2;2;3;3;4;3;3;3]
- : int list = [1;2;3;4;3].
Soluzione Esercizio 1.
*)

let rec compress l=
    match l with
        l when l=[]->[]
        |[x]->[x]
        |x::y::xs->if(x=y) then compress (y::xs)
                   else x::compress (y::xs)

(*
Esercizio 2. Scrivere una funzione factors che dato un numero intero n restituisca la lista dei fattori
primi di n con le opportune ripetizioni.
Per esempio:
# factors 315;;
- : int list = [3; 3; 5; 7].
Infine si scriva il tipo della funzione factors.
*)

let factors n =
    let rec aux n d=
        match n with
            n when n=1->[]
            |n when n<>1-> if (n%d)=0 then d:: aux (n/d) d
                           else aux n (d+1)
    in 
    aux n 2

//val factors = n:int -> int list = <fun>


(*
Esercizio 4. Scrivere una funzione remove che dati un numero intero k e una lista l restituisca la lista
che si ottiene da l rimuovendo il k-eseimo elemento, assumendo che il primo elemento della lista si
trovi in posizione 0, il secondo in posizione 1, e cos`ı via.
Per esempio:
# remove 1 [1.0; 5.3; 7.9; 6.8];;
- : float list = [1.0; 7.9; 6.8]
Infine si scriva il tipo della funzione remove
*)

let rec remove n l=
        match (n,l) with
            (_,[])->[]
            |(n,x::xs)-> if (n=0) then xs
                         else x::remove (n-1) xs

//val remove = n:int -> l: 'a list -> 'a list = <fun>
