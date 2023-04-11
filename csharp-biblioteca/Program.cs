namespace csharp_biblioteca
{
    internal class Program
    {

        //definizione Utente
        class Utente
        {
            public string Cognome { get; set; }
            public string Nome { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public string Telefono { get; set; }
        }

        //definizione dei prestiti in base al tipo
        class inPrestito
        {
            public string Codice { get; set; }
            public string Titolo { get; set; }
            public int Anno { get; set; }
            public string Settore { get; set; }
            public string Scaffale { get; set; }
            public Autore Autore { get; set; }
        }

        //definizione tipo prestito: LIBRO

        class Libro : inPrestito
        {
            public int NumeroPagine { get; set; }
        }

        //definizione tipo prestito: DVD
        class DVD : inPrestito
        {
            public TimeSpan Durata { get; set; }
        }

        //Informazioni autore
        class Autore
        {
            public string Nome { get; set; }
            public string Cognome { get; set; }
        }

        //Dettagli del prestito
        class Prestito
        {
            public Utente Utente { get; set; }
            public inPrestito Documento { get; set; }
            public string DataInizio { get; set; }
            public string DataFine { get; set; }
        }

        //classe per raggruppare tutte le liste, con vari metodi per interagirci
        class Biblioteca
        {
            private List<inPrestito> inPrestito = new List<inPrestito>();
            private List<Utente> utenti = new List<Utente>();
            private List<Prestito> prestiti = new List<Prestito>();

            //aggiunta elemento in prestito
            public void AggInPrestito(inPrestito elem)
            {
                inPrestito.Add(elem);
            }

            //aggiunta di un utente
            public void AggUtente(Utente utente)
            {
                utenti.Add(utente);
            }

            //aggiunta del prestito vero e proprio
            public void AggPrestito(Prestito prestito)
            {
                prestiti.Add(prestito);
            }

            //ricerca dei prestiti tramite il codice dell'articolo
            public List<inPrestito> PrestitiPerCodice(string codice)
            {
                return inPrestito.FindAll(doc => doc.Codice == codice);
            }

            //ricerca dei prestiti tramite nome dell'utente che ha richiesto il prestito
            public List<Prestito> PrestitiPerUtente(string nome, string cognome)
            {
                return prestiti.FindAll(prest => prest.Utente.Nome == nome && prest.Utente.Cognome == cognome);
            }

            //ricerca di un prestito tramite il titolo dell'articolo in prestito
            public List<inPrestito> PrestitiPerTitolo(string titolo)
            {
                return inPrestito.FindAll(doc => doc.Titolo.Contains(titolo));
            }

            public void PrestitoElem(inPrestito elem, Utente utente, string dataInizio, string dataFine)
            {
                if (inPrestito.Contains(elem) && utenti.Contains(utente))
                {
                    prestiti.Add(new Prestito
                    {
                        Utente = utente,
                        Documento = elem,
                        DataInizio = dataInizio,
                        DataFine = dataFine
                    });
                }
            }
        }

        static void Main(string[] args)
        {

        }

    }
}