(*Esercizio 1. Scrivere una funzione ricorsiva conta valli che data una lista di elementi su cui e defi- `
nito un ordinamento, conta gli elementi che sono minori di tutti i successivi.
Per esempio:
> conta valli [ ];;
val it : int = 0
> conta valli [6; 4; 5; 3; 1; 10; 3; 3];;
val it : int = 2
> conta valli [6.0; 4.1; 8.2; 6.5; 1.2; 10.2; 3.5; 7.4; 5.3; 4.0];;
val it : int = 3
> conta valli [’a’];;
val it : int = 1*)


let rec isMinore n l=
    match l with
        []->true 
        |x::xs->if(n<x)then isMinore n xs
                else
                false

//val isMinore : 'a -> 'a list -> bool
let rec conta_valli l =
    match l with
        []->0
        |x::xs -> if (isMinore x xs) then 1+(conta_valli xs)
                  else   
                  conta_valli xs

//val contaVali : 'a list -> int

(*Esercizio 2. Scrivere una funzione ricorsiva elimina coppie che elimina da una generica lista l tutti
gli elementi consecutivi uguali a due a due.
Per esempio:
> elimina coppie [];;
val it : ’a list = []
> elimina coppie [10;10;10;3;4;4;4;4;2;2;2];;
val it : int list = [10;3;2]
> elimina coppie [’a’];;
val it : char list = [’a’]
Infine si scriva il tipo della funzione elimina coppie.*)

let rec elimina_coppie l=
    match l with
        []->[]
        |[x]->[x]
        |x::y::xs -> if (x=y) then (elimina_coppie xs)
                     else 
                     x::(elimina_coppie (y::xs))

//val elimina_coppie : 'a list -> 'a list
