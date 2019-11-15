module Impl

let NomeCognome : string = "Mionome Miocognome" // <---- SCRIVI IN QUESTA STRINGA IL TUO NOME E COGNOME

(*
Dato un valore x ed una lista l, restituisce la posizione dell'ultima occorrenza di x nella lista. 
Se x non è presente nella lista l la funzione fallisce con il messaggio d'errore "empty list".
*)

let last_index (x : 'a) (l : 'a list): int = 
    match l with
        []-> failwith "Lista vuota"
        |_-> let mutable n=(-1)
             let rec aux p l = match l with
                                [] -> n
                                |s::xs -> if (s=x) then n<-p 
                                                        aux (p+1) xs
                                          else 
                                          aux (p+1) xs
             in 
             if((aux 0 l)=(-1)) then failwith "Empty list"
             else
             aux 0 l

(*
Dato un predicato p ed una list l, rimuove da l gli elementi che non soddisfano il predicato p.
*)
let rec filter (p : 'a -> bool) (l : 'a list) : 'a list = 
    match l with
        []->[]
        |x::xs-> if (p x) then x::(filter p xs)
                 else
                 (filter p xs)


(*
Data una lista l restituisce la lista contenente tutti gli elementi di l senza duplicati.
*)

let rec isThere (n: 'a) (l : 'a list)= 
    match l with
        []->false
        |x::xs->if(x=n)then true
                else isThere n xs

let rec distinct (l : 'a list) : 'a list = 
    if(l=[]) then []
    else
        let rec aux (a: 'a list) (lista: 'a list) : 'a list=
            match a with
                [] when a=[]->lista
                |x::xs->if isThere x lista then aux xs lista
                        else 
                        aux xs (lista@[x])
            in
        aux l []
                

    
        



