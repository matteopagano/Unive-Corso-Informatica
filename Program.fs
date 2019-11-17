(*
Data la seguente funzione:
let rec f w =
    match w with
        | [] -> 0
        | x :: y -> if ( x % 2 = 0) then 1 + ( f y )
                    else ( f y ) ;;

Qual `e il tipo (o prototipo) della funzione ?
A. int list -> int B. int -> int list C. int -> int D. (int -> int) -> int
*)

//val f -> int list -> int

(*
Data la funzione f dell’esercizio precedente, dire che cosa restituisce.
A. il numero degli elementi pari in una lista di interi B. il numero degli elementi in posizione
pari di una lista di interi C. il numero degli elementi in posizione dispari di una lista di interi
D. il numero degli elementi dispari in una lista di interi
*)

//Risposta A

(*
Dire quale delle seguenti espressioni ha come valore int list = [2;4;7;5;9] :
A. [2;4;7]@[5;9] B. [2]::[4;7;5;9] C. [2;4;7]::[5;9] D. 2@[4;7;5;9]
*)

//Risposta A

(*
Definire le funzioni init e last che prendono come argomenti un numero naturale n tale che
0<=n<=length(ls) e una lista ls: init n ls restituisce la lista contenente i primi n elementi di ls
e last n ls restituisce la lista contenente gli ultimi elementi della lista ls esclusi i primi n.
Inoltre si scriva il tipo (o prototipo) delle funzioni init e last.
*)


let rec length ls=
    match ls with 
        []->0
        |x::xs -> 1+ length xs

let rec init n ls =
    if ((0>n)||(n>length ls)) then failwith "Input di n non valido"
    else 
    match ls with
            ls when n=0 -> []
            |x::xs -> x::(init (n-1) xs)

//var init : n:int -> ls: 'a list -> 'a list
        
let rec last n ls=
    if ((0>n)||(n>length ls)) then failwith "Input di n non valido"
    else 
    match ls with
        ls when n=0->ls
        |x::xs when n<>0 -> last (n-1) xs


//var last : n:int -> ls: 'a list -> 'a list
(*
Scrivere una funzione shift: ’a list -> int -> ’a list che data una lista generica ls e un
intero n tale che 0<=n<=length(ls) ruota di n posizioni gli elementi della lista verso sinistra. Per
esempio:
# shift: [1;2;3;4;5;6;7;8] 3;;
- : int list = [4;5;6;7;8;1;2;3]
Suggerimento: Usare le funzioni init e last dell’esercizio precedente
*)

let shift l n=
    (last n l) @ (init n l)

(*
Scrivere una funzione unzip: (int * ’a) list -> ’a list che data una lista di coppie di tipo
(int * ’a) restituisce la lista che si ottiene sostituendo ogni coppia (k,el) con la sequenza di k
elementi uguali a el e contigui. Si assuma che k sia sempre non negativo. Per esempio:
# unzip [(4, ’a’); (1, ’b’); (2, ’c’); (1, ’d’); (4, ’e’)];;
- : char list = [’a’;’a’;’a’;’a’;’b’;’c’;’c’;’d’;’e’;’e’;’e’;’e’]
*)

let rec aux (a,b) =
    match (a,b) with
        (0,_)->[]
        |(a,b) when a<>0 -> b::aux (a-1,b)

let rec unzip l=
    match l with
        []->[]
        |x::xs-> (aux x)@(unzip xs)