(*
Esercizio 1. Scrivere una funzione num dispari che data una lista di liste di interi ls restituisca la
lista di interi che indica il numero di elementi dispari in ciascuna lista appartenente a ls.
Per esempio:
# num dispari [[1; 2];[1; 2; 3; 4];[]];;
- : int list = [1; 2; 0]
# num dispari [[]];;
- : int list = [0]
# num dispari [];;
- : int list = []
Infine si scriva il tipo della funzione num dispari.
*)

let rec aux l=
    match l with
        []->0
        |x::xs -> if((x%2)<>0) then 1 + (aux xs)
                  else
                  aux xs

let rec num_dispari ls =
    match ls with
        []->[]
        |x::xs->(aux x)::(num_dispari xs)

(*

Esercizio 2. Definire una funzione lista fattori: int -> int list che dato un numero intero
non negativo n restituisca la lista dei fattori primi di n (escluso 1). Per esempio:
# lista fattori 6;;
- : int list = [2; 3]
# lista fattori 7
- : int list = [7]
# lista fattori 0;;
- : int list = []
# lista fattori 1;;
- : int list = []
# lista fattori 2;;
- : int list = [2]
*)

let rec tryPrime (n,i)=
    match (n,i) with
            (a,b) when (b=a) -> true
            |(a,b) -> if ((a%b)=0) then false
                                  else
                                  (tryPrime (a,(b+1)))
let isPrime a =
    if (tryPrime (a,2)) then true
    else 
    false
        
let rec isPrimeList l=
    match l with
        []->[]
        |x::xs->if (isPrime x) then (x::(isPrimeList xs))
                else
                (isPrimeList xs)

let lista_fattori n= 
    let rec aux (n,b) = 
        match n with
            n when n=0->[]
            |n when n=b->[b]
            |n when n<>b->if ((n%b)=0) then b::(aux (n,b+1))
                          else
                          aux (n,b+1)
    in
    isPrimeList (aux (n,2))

 (*
 Esercizio 3. Definire una funzione ricorsiva somma uguali: int list -> int list che data una
 lista di interi l restituisca la lista ottenuta da l sostituendo ogni sequenza di elementi uguali e contigui
 in l con un unico elemento uguale alla somma degli elementi nella sequenza. Per esempio:
 # somma uguali [1;1;2;2;2;2;3;3;4;3;3;3]);;
 - : int list = [2;8;6;4;9].
 # somma uguali [];;
 - : int list = []
 
 *)   


 
let rec somma_uguali (l:int list) =

    let rec aux (l:int list) somma=
        match l with

            []->[somma]
            |[x]->[x]
            |[x;y]->if (x=y) then aux [] (somma+y+x)
                    else
                    (somma+x)::[y]
            |x::y::xs->if (x=y) then aux (y::xs) (somma + y)
                       else 
                       (somma+x)::aux (y::xs) 0
    in
    if(l =[]) then []
    else
    aux l 0


        
       
        

