(*Esercizio 1. Scrivere una funzione prefisso che date due liste lst1 e lst2 verifichi se lst1 e un `
prefisso di lst2. Per esempio:
# prefisso [1; 2] [1; 2; 3; 4];;
- : bool = true
# prefisso [’a’; ’b’; ’c’] [’a’; ’b’; ’d’];;
- : bool = false
prefisso [ ] [true];;
- : bool = true
prefisso [1.0; 2.0] [ ];;
- : bool = false
Infine si scriva il tipo della funzione prefisso.*)

let rec prefisso l1 l2=
    match (l1,l2) with
        ([],_)->true 
        |(_,[])->false
        |(x::xs,y::ys)-> if (x=y) then prefisso xs ys
                         else
                         false

//val prefisso= l1: 'a list -> l2: 'a list -> bool

(*
Esercizio 2. Definire una funzione ricorsiva somma uguali: ’a list -> ’a list che data una lista di interi l restituisca la lista ottenuta da l sostituendo ogni sequenza di elementi uguali e contigui
in l con un unico elemento uguale alla somma degli elementi nella sequenza. Per esempio:
# somma uguali [1;1;2;2;2;2;3;3;4;3;3;3]);;
- : int list = [2;8;6;4;9].
# somma uguali [];;
- : int list = []

*)
//Uguale a compitino 2015

(*Esercizio 3. Scrivere un predicato perfetto che verifica se un numero intero positivo e un numero `
perfetto. Un numero si dice perfetto se la somma dei suoi divisori e uguale al doppio del numero `
stesso, ovvero se esso vale quanto la somma dei suoi divisori escluso lui stesso.
Per esempio il numero 6 e un numero perfetto perch ` e 6` = 1+2+3, il numero 28 e un numero perfetto `
perche 28 ` = 1+2+4+7+14. Quindi:
# perfect 6
- : bool = true
# perfect 16
- : bool = false
# perfect 28
- : bool = true
Infine si scriva il tipo della funzione perfetto*)

let divisori a=
    let rec aux p n=
        match n with
             n when n=p->[]
            |n when p=0->[]
            |n when n<>p-> if(p%n)=0 then n::(aux p (n+1))
                           else
                           aux p (n+1)
    in 
    aux a 1

let rec somma_lista l=
    match l with
        []->0
        |x::xs-> x + somma_lista (xs) 

let perfect n =
    if (somma_lista (divisori n))=n then true
    else false

//val divisori = a:int -> int list 
//val somma_lista = l:int list -> int 
//val perfect = n:int -> bool
