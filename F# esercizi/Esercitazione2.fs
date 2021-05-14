module Impl

let NomeCognome : string = "Matteo Pagano" // <---- SCRIVI IN QUESTA STRINGA IL TUO NOME E COGNOME

(*
Dato un numero intero n (compreso tra 0 e 1023), restituisce (come numero intero) la rappresentationi di n in binario.
*)
let dec_to_bin (x : int) = 
    let rec pow_ n k= 
        match k with
        0 -> 1
        |_ -> n * (pow_ (n) (k-1))
    if (x=1) then 1
    else if (x=0) then 0
    else if not((x>=0)&&(1023>=x)) then failwith "devi inserire un numero compreso o uguale a 0 e 1023"
    else let rec aux (n:int) m= match n with
                                n when (n = 1) -> 1 * pow_ 10 m
                               |n when (n<>1) -> if ((n%2)=1) 
                                                 then 1*(pow_ 10 m) + aux (n/2) (m + 1)
                                                 else
                                                 aux (n/2) (m + 1)
         in aux x 0
   
(*
Data una lista, non vuota, di liste, non vuote, l, restituisce la lista ottenuta concatenando tutte le liste contenute in l.
*)
let rec flatten (l : 'a list list ) : 'a list =
    match l with
        [[]]->[]
        |x::xs->x@flatten xs



(*
Data una funzione f e una lista l, restituisce l'applicazione della funzione f al primo elemento della lista e al risultato
della funzione sum_by avente come parametri la stessa funzione f e la coda della lista l. Se la lista l è vuota la funzione 
restituisce il valore 0.
*)
let rec sum_by (f : 'a -> 'a -> 'a) (z : 'a) (l : 'a list ) : 'a = 
    match l with
        []->z
        |[]->0
        |x::xs -> f x (sum_by f z xs)


(*
Date due liste a e b restituisce true se b è uguale alla lista inversa di a.
*)
let reverse (a : 'a list) (b : 'a list) : bool when 'a : equality = false


