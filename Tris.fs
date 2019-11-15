﻿// Learn more about F# at http://fsharp.org

// Gioco scritto da Matteo Pagano

open System

let rec take_element p l= 
    match (p,l) with 
        (0,x::xs) -> x
        |(_,x::xs) ->take_element (p-1) xs
        |_->failwith "Nessun elemento"

let rec insert g p l=
    match (p,l) with
         (0,_)-> if(g='x') then 'x'::List.tail(l)
                 else
                 'o'::List.tail(l)
         |(_,x::xs)->x::(insert g (p-1) xs)

let tris = [' ';' ';' ';' ';' ';' ';' ';' ';' ']



let rec listaUguale l1 l2 = 
    match (l1,l2) with
        ([],[])->true
        |(x::xs,y::ys)->if(x=y)then listaUguale xs ys
                        else
                        false



let verificaVittoriaX l=
    match l with
                 l  when (((take_element 0 l )='x')&&((take_element 4 l )='x')&&((take_element 8 l )='x')) -> true
                |l  when (((take_element 2 l )='x')&&((take_element 4 l )='x')&&((take_element 6 l )='x')) -> true
                |l  when (((take_element 0 l )='x')&&((take_element 1 l )='x')&&((take_element 2 l )='x')) -> true
                |l  when (((take_element 3 l )='x')&&((take_element 4 l )='x')&&((take_element 5 l )='x')) -> true
                |l  when (((take_element 6 l )='x')&&((take_element 7 l )='x')&&((take_element 8 l )='x')) -> true
                |l  when (((take_element 0 l )='x')&&((take_element 3 l )='x')&&((take_element 6 l )='x')) -> true
                |l  when (((take_element 1 l )='x')&&((take_element 4 l )='x')&&((take_element 7 l )='x')) -> true
                |l  when (((take_element 2 l )='x')&&((take_element 5 l )='x')&&((take_element 8 l )='x')) -> true
                |_->false

let verificaVittoriaY l=
    match l with
                 l  when (((take_element 0 l )='o')&&((take_element 4 l )='o')&&((take_element 8 l )='o')) -> true
                |l  when (((take_element 2 l )='o')&&((take_element 4 l )='o')&&((take_element 6 l )='o')) -> true
                |l  when (((take_element 0 l )='o')&&((take_element 1 l )='o')&&((take_element 2 l )='o')) -> true
                |l  when (((take_element 3 l )='o')&&((take_element 4 l )='o')&&((take_element 5 l )='o')) -> true
                |l  when (((take_element 6 l )='o')&&((take_element 7 l )='o')&&((take_element 8 l )='o')) -> true
                |l  when (((take_element 0 l )='o')&&((take_element 3 l )='o')&&((take_element 6 l )='o')) -> true
                |l  when (((take_element 1 l )='o')&&((take_element 4 l )='o')&&((take_element 7 l )='o')) -> true
                |l  when (((take_element 2 l )='o')&&((take_element 5 l )='o')&&((take_element 8 l )='o')) -> true
                |_ ->false

let refString l = sprintf (" %c | %c | %c \n------------\n %c | %c | %c \n------------\n %c | %c | %c " )
                      (take_element 0 l)
                      (take_element 1 l)
                      (take_element 2 l)
                      (take_element 3 l)
                      (take_element 4 l)
                      (take_element 5 l)
                      (take_element 6 l)
                      (take_element 7 l)
                      (take_element 8 l)

let trisInitial = refString tris
let spiegazioneTris = refString ['0';'1';'2';'3';'4';'5';'6';'7';'8']
let rec giocoTris x l = 
    match x with 
        4-> printfn "Giocatore X:"
            let giocatoreX='x'
            let a = int32(System.Console.ReadLine()) 
            let refreshTris= (insert (giocatoreX) (a) (l))
            System.Console.Clear()
            printfn "%s" (refString refreshTris)
            if(verificaVittoriaX refreshTris) 
            then giocoTris 10 refreshTris
            else printfn "\nPareggio !"
        |10-> printfn "\nHa vinto il giocatore X"
        |11-> printfn "\nHa vinto il giocatore Y"
        |_-> let giocatoreX='x'
             let giocatoreY='o'
             printfn "Giocatore X:"
             let a = int32(System.Console.ReadLine()) 
             let refreshTris= (insert (giocatoreX) (a) (l))
             System.Console.Clear()
             printfn "%s" (refString refreshTris)
             if(verificaVittoriaX refreshTris) 
                then giocoTris 10 refreshTris
             else
                printfn "Giocatore Y:"
                let b = int32(System.Console.ReadLine()) 
                let refreshTris= (insert (giocatoreY) (b) (refreshTris))
                System.Console.Clear()
                printfn "%s" (refString refreshTris)
                if(verificaVittoriaY refreshTris) 
                then 
                    giocoTris 11 refreshTris
                else
                    giocoTris (x+1) refreshTris
          
          
[<EntryPoint>]



printfn "COME GIOCARE:"
printfn "Ad ogni turno inserire la posizione (intero) dove si vuole mettere la X o O"
printfn "posizioni:"
printfn "%s" spiegazioneTris
printfn "Premi un qualsiasi tasto per iniziare..."
Console.ReadLine();
System.Console.Clear()
printfn "%s" trisInitial
giocoTris 0 (tris)