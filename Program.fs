(*
Esercizio 1. Scrivere il tipo della seguente funzione g:
let rec g y =
match y with
| [] -> 0
| x::z -> if (x mod 2 =0) then x + (g z) else (g z);;
Che cosa restituisce ?
*)

//Risposta somma ti tutti i numeri pari nella lista y passata come parametro nella funzione g
//val g = y: int list -> int = <fun>

(*
Esercizio 2. Scrivere una funzione suffix che date due liste l1 e l2 verifichi se l1 e un suffisso di `
l2. Per esempio:
suffix [3; 4] [1; 2; 3; 4] = true
suffix [’a’; ’b’; ’c’] [’a’; ’b’; ’c’; ’d’] = false
suffix [ ] [true] = true
suffix [1.0; 2.0] [ ] = false.
Infine si scriva il tipo della funzione suffix
*)

let rec reverse l =
    match l with
        []->[]
        |x::xs->(reverse xs)@[x]

//val reverse = l:'a list -> 'a list = <fun>

let suffix l1 l2=
    let rec aux l1 l2=
        match (l1,l2) with
            ([],_)->true
            |(x::xs,[])->false
            |(x::xs,y::ys)->if(x=y) then aux xs ys
                            else false
    in
    aux (reverse l1) (reverse l2)

//val suffix = l1: 'a list -> l2: 'a list -> bool = <fun>

(*
Esercizio 3. Scrivere le funzioni prefix e last che data una lista non vuota restituiscono, rispettivamente, la lista senza l’ultimo elemento e l’ultimo elemento della lista. Per esempio:
prefix [1; 2; 0; 0] = [1; 2; 0]
prefix [’a’] = [ ]
prefix [5.9; 7.0; 2.9; 8.1] = [5.9; 7.0; 2.9]
last [1; 2; 0; 0] = 0
last [’a’] = ’a’
last [5.9; 7.0; 2.9; 8.1] = 8.1.
Infine si scrivano i tipi delle funzioni prefix e last.
*)

let rec prefix l=
    match l with
        [x]->[]
        |x::xs->x::(prefix xs)

let rec last l =
    match l with
        [x]->x
        |x::xs-> last xs

//val prefix = l:'a list -> 'a list = <fun>
//val last = l:'a list -> 'a = <fun>

(*
Esercizio 4. Scrivere una funzione list2num che decodifica un numero intero espresso come lista
non vuota di cifre. Per esempio:
list2num [1; 2; 0; 0] = 1200
list2num [0] = 0
list2num [9; 8; 6; 5] = 9865.
Suggerimento: si usino le funzioni prefix e last dell’esercizio precedente.
Infine si scriva il tipo della funzione list2num.
*)

let rec pow n p =   
    match p with 
        0-> 1
        |p when p<>0->n * pow n (p-1)

let rec list2num l=
    let rec aux l p=
        match l with
            []->0
            |l when p=0-> if((last l)=0) then  aux (prefix l) (p+1)
                          else ((pow 10 p)*(last l)) + aux (prefix l) (p+1)
            |l when p<>0-> if (last l)=0 then  aux (prefix l) (p+1)
                            else ((pow 10 p)*(last l)) + aux (prefix l) (p+1)
    in 
    aux l 0

// val list2num = l:int list -> int = <fun>