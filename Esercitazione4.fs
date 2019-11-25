module Impl

let NomeCognome : string = "Matteo Pagano" // <---- SCRIVI IN QUESTA STRINGA IL TUO NOME E COGNOME

(*
Data una funzione f ed una lista l, restituisce una nuova lista i cui elementi sono il risultato  di f per ogni elemento di l.
*)
let rec map (f:'a -> 'b)  (l:'a list): 'b list = 
    match l with    
        []->[]
        |x::xs->(f x)::(map f xs)
   
(*
Data una funzione f, un accumulatore acc ed una lista l effettua l'operazione di reduce. Ovvero, per ogni elemento x in l 
applica f su acc e x e assegna il valore ottenuto all'accumulatore. Per esempio, se la funzione in input è f, gli
elementi sono i0, i1, i2 e lo stato iniziale è s allora il risultato della computazione sarà 
f (f (f s i0) i1) i2.
*)
let rec fold (f:'State -> 'T -> 'State) (acc: 'State) (l:'a list): 'State = 
    match l with
        []->failwith "Lista vuota!"
        |x::xs->fold f (f acc x) xs

(*
Data una funzione f ed una lista l applica f ad ogni elemento di l.
*)
let rec iter (f:'a -> unit)  (l:'a list): unit = 
    match l with    
        []-> ()
        |x::xs->f x
                iter f xs



