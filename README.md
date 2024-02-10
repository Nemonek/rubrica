# rubrica
 
## Requisiti

- Classe Persona e classe Contatto.
- Le informazioni di contatto di ogni persona devono essere salvate in un file chiamato contatti.csv .
- Le informazioni di ogni persona devono essere salvate in un file chiamato persone.csv .
- Il programma deve mettere a disposizione due griglie per visualizzare il contenuto dei due file.
- Implementare una funzionalità che permetta, alla selezione di una persona, di mostrare tutti i contatti ad essa associati.

## Basi sul funzionamento
All'interno del file *persone.csv* ogni persona ha una chiave primaria *PK*: la stessa cosa vale per i contatti memorizzati nel file *contatti.csv*.<br>
All'avvio il programma apre i due file, e carica in due liste sia le persone, sia i contatti: quando si clicca su una persona vengono selezionati tutti i contatti con la stessa chiave primaria della persona tramite l'uso delle LINQ Expression ( Language Integrate Query ), e viene generata una lista. Suddetta lista è poi collegata ad una seconda DataGrid nella quale ne sarà mostrato il contenuto.