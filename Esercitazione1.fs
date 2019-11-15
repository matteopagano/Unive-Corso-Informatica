
module Es1.Impl

let NomeCognome : string = "Matteo Pagano" // <---- SCRIVI IN QUESTA STRINGA IL TUO NOME E COGNOME

(*
Date le coordinate di due punti distinti nel piano (x1,y1) e (x2,y2), calcolare la distanza tra di essi
*)
let distanza (x1, y1) (x2, y2) : float = 
    let latox = x1 - x2
    let latoy = y1 - y2
    sqrt(latox * latox + latoy * latoy)



(*
Date le coordinate di tre punti distinti nel piano (xA,yA), (xB,yB) e (xC,yC) rappresentanti i vertici di un triangolo qualsiasi, 
calcolare il perimetro del triangolo.
*)
let perimetro_triangolo (xA, yA) (xB, yB) (xC, yC) = 

    let ab = distanza (xA , yA) (xB , yB)
    let bc = distanza (xB , yB) (xC , yC)
    let ca = distanza (xC , yC) (xA , yA)
    ab + bc + ca

(*
Data una coppia di città (partenza, arrivo), restituisce il costo del biglietto del treno che collega le due città.
Nel caso la tratta ferroviaria specificata non sia disponibile sollevare l'errore "Tratta non disponibile"
*)
let costo_biglietto (partenza : string, arrivo : string) : float = 
        match (partenza, arrivo) with
        |("Venezia","Mestre")|("Mestre","Venezia") -> 1.25
        |("Venezia","Padova")|("Padova","Venezia") -> 4.15
        |("Mestre","Treviso")|("Treviso","Mestre") -> 3.40
        |("Mestre","Bolzano")|("Bolzano","Mestre") -> 25.85
        |_-> failwith "Tratta non disponibile"

(*
Data la coppia (partenza, arrivo) e un valore credito, restituisce il resto dell'acquisto del biglietto relativo alla tratta ferroviaria scelta con il credito fornito.
Nel caso in cui il credito sia insufficiente sollevare l'errore "Credito insufficiente".
*)
let resto (partenza : string, arrivo : string) (credito : float) : float = 
        if (credito - costo_biglietto (partenza ,arrivo))>=0.0 then credito - costo_biglietto (partenza ,arrivo)
        else failwith "Credito insufficiente"
        

