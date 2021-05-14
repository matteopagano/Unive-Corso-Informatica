// Learn more about F# at http://fsharp.org

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

let listTris l = 
    sprintf (" %c | %c | %c \n------------\n %c | %c | %c \n------------\n %c | %c | %c " )
        (take_element 0 l)
        (take_element 1 l)
        (take_element 2 l)
        (take_element 3 l)
        (take_element 4 l)
        (take_element 5 l)
        (take_element 6 l)
        (take_element 7 l)
        (take_element 8 l)

let spiegazioneTris = listTris ['0';'1';'2';'3';'4';'5';'6';'7';'8']
let tris = [' ';' ';' ';' ';' ';' ';' ';' ';' ']
let trisInitial = listTris tris



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




let rec giocoTris turno tris giocatore= 
    match turno with 
        9-> printfn "\nPareggio !"
        |10 -> if (giocatore='x') then printfn "\nHa vinto il giocatore X"
                  else printfn "\nHa vinto il giocatore Y"
        |_-> match giocatore with
                   'x' -> let giocatoreX='x'
                          printfn "Giocatore X:"
                          let a = int32(System.Console.ReadLine()) 
                          let refreshTris= (insert (giocatoreX) (a) (tris))
                          System.Console.Clear()
                          printfn "%s" (listTris refreshTris)
                          if(verificaVittoriaX refreshTris) 
                              then giocoTris 10 refreshTris 'x'
                          else
                              giocoTris (turno+1) refreshTris 'y'
                   |'y' -> let giocatoreY='y'
                           printfn "Giocatore Y:"
                           let b = int32(System.Console.ReadLine()) 
                           let refreshTris= (insert (giocatoreY) (b) (tris))
                           System.Console.Clear()
                           printfn "%s" (listTris refreshTris)
                           if(verificaVittoriaY refreshTris) 
                               then giocoTris 10 refreshTris 'y'
                           else
                           giocoTris (turno+1) refreshTris 'x'
        
[<EntryPoint>]

printfn "COME GIOCARE:"
printfn "Ad ogni turno inserire la posizione (intero) dove si vuole mettere la X o O"
printfn "posizioni:"
printfn "%s" spiegazioneTris
printfn "Premi un qualsiasi tasto per iniziare..."
Console.ReadLine();
System.Console.Clear()
printfn "%s" trisInitial
giocoTris 0 (tris) 'x'
