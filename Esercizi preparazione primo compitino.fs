//1
let rec isThere n l=
        match l with
            []->false
            |x::xs->if(n=x) then true
                    else
                    isThere n xs

let rec elementiDifferenti l1 l2=
    match l2 with
        []->[]
        |x::xs->if(isThere x l1) then elementiDifferenti l1 xs
                else
                x::(elementiDifferenti l1 xs)

let unione l1 l2 = l1@(elementiDifferenti l1 l2)

let rec intersezione l1 l2 =
    match l1 with
        []->[]
        |x::xs->if(isThere x l2) then x::(intersezione xs l2)
                else 
                intersezione xs l2

let rec differenza l1 l2 =
    match l1 with
        []->[]
        |x::xs->if(isThere x l2) then (differenza xs l2)
                else 
                x::(differenza xs l2)

//2

let rec subset l1 l2 =
    match l1 with
        []->true
        |x::xs->if(isThere x l2) then subset xs l2
                else false

//3


let rec aux a b =
    match b with
        0->(a,b)::[]
        |_->((a-b),b)::(aux a (b-1))


let rec intpairs n = 
    aux n n

//4

let rec length l=
    match l with        
        []->0
        |x::xs->1+(length xs)

let rec trips l =   
    let rec aux list =
        match list with
            list when (length list) = 2->[]
            |x::y::z::xs-> (x,y,z)::(aux (y::z::xs))
    in
    if ((length l)=3) then []
    else aux l
        
//5

let rec choose k (l:'a list)=

    let rec aux k l=
        match (l,k) with
            (_,0) -> []
            |(x::xs,_) -> x::(aux (k-1) xs)
    in 
    match l with
        l when (length l) = k -> [l]
        |x::xs-> (aux k l)::(choose k xs)

//6

let rec strike_ball l1 l2=
    let rec strike l1 l2=
        match (l1,l2) with
            (_,[])->0
            |([],_)->0
            |(x::xs,y::ys)->if(isThere x l2)&&(x<>y) then 1+(strike xs ys)
                            else (strike xs l2)
    let rec ball l1 l2=
        match (l1,l2) with
            (_,[])->0
            |([],_)->0
            |(x::xs,y::ys)->if(isThere x l2)&&(x=y) then 1+(ball xs ys)
                            else (ball xs l2)
    in
    ((strike l1 l2),(ball l1 l2))

     


        
