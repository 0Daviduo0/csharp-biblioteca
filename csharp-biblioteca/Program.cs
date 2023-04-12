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
            public string Durata { get; set; }
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
            private List<inPrestito> inPrestito = new List<inPrestito>(); //sono contenute le info sugli articoli
            private List<Utente> utenti = new List<Utente>(); //sono contenute le info sugli utenti
            private List<Prestito> prestiti = new List<Prestito>(); //sono contenute le info sui prestiti

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
                return inPrestito.FindAll(inPrestito => inPrestito.Codice == codice);
            }

            //ricerca dei prestiti tramite nome dell'utente che ha richiesto il prestito
            public List<Prestito> PrestitiPerUtente(string nome, string cognome)
            {
                return prestiti.FindAll(prest => prest.Utente.Nome == nome && prest.Utente.Cognome == cognome);
            }

            //ricerca dei prestiti tramite nome dell'utente che ha richiesto il prestito
            public List<Utente> CercaUser(string nome, string cognome)
            {
                return utenti.FindAll(user => user.Nome == nome && user.Cognome == cognome);
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
            Biblioteca biblioteca = new Biblioteca();

            //creazione degli autori
            Autore autore1 = new Autore { Nome = "Giacomino", Cognome = "Robertini" };
            Autore autore2 = new Autore { Nome = "Cristian", Cognome = "Lorenzini" };
            Autore autore3 = new Autore { Nome = "Giovanni", Cognome = "Capelletti" };

            //creazione dei prodotti
            Libro libro1 = new Libro { Codice = "L01A", Titolo = "Er librone sgravato", Anno = 2057, Settore = "Horror", Scaffale = "A", Autore = autore1, NumeroPagine = 345 };
            Libro libro2 = new Libro { Codice = "L02B", Titolo = "Cent'anni di solitudine", Anno = 999, Settore = "Meccanica Quantistica", Scaffale = "B", Autore = autore2, NumeroPagine = 432 };
            DVD dvd1 = new DVD { Codice = "DVD01C", Titolo = "Laravel-lo", Anno = 2010, Settore = "Informatica", Scaffale = "C", Autore = autore3, Durata = "1h 33m" };

            //creazione degli utenti
            Utente utente1 = new Utente { Cognome = "Rossi", Nome = "Mario", Email = "mario.rossi@mail.com", Password = "123456", Telefono = "1234567890" };
            Utente utente2 = new Utente { Cognome = "Verdi", Nome = "Anna", Email = "anna.verdi@mail.com", Password = "password", Telefono = "0987654321" };

            //creazione della biblioteca e aggiunta dei prodotti e degli utenti
            biblioteca.AggInPrestito(libro1);
            biblioteca.AggInPrestito(libro2);
            biblioteca.AggInPrestito(dvd1);
            biblioteca.AggUtente(utente1);
            biblioteca.AggUtente(utente2);

            while (true)
            {
                Console.WriteLine("Cosa vuoi fare?");
                Console.WriteLine("1. Aggiungi un utente");
                Console.WriteLine("2. Aggiungi un prestito");
                Console.WriteLine("3. Cerca prestiti per codice");
                Console.WriteLine("4. Cerca prestiti per utente");
                Console.WriteLine("5. Cerca prestiti per titolo");
                Console.WriteLine("6. Esci");

                int scelta;
                Console.Write("Scelta: ");
                if (!int.TryParse(Console.ReadLine(), out scelta))
                {
                    Console.WriteLine("Scelta non valida.");
                    continue;
                }

                switch (scelta)
                {
                    case 1:
                        Console.Write("Inserisci il cognome dell'utente: ");
                        string cognome = Console.ReadLine();

                        Console.Write("Inserisci il nome dell'utente: ");
                        string nome = Console.ReadLine();

                        Console.Write("Inserisci l'email dell'utente: ");
                        string email = Console.ReadLine();

                        Console.Write("Inserisci la password dell'utente: ");
                        string password = Console.ReadLine();

                        Console.Write("Inserisci il telefono dell'utente: ");
                        string telefono = Console.ReadLine();

                        Utente utente = new Utente
                            {
                                Cognome = cognome,
                                Nome = nome,
                                Email = email,
                                Password = password,
                                Telefono = telefono
                            };

                        biblioteca.AggUtente(utente);
                        Console.WriteLine("Utente aggiunto con successo.");
                        break;


                    case 2:
                        //Richiesta dati prestito
                        Console.Write("Inserisci il codice dell'articolo in prestito: ");
                        string codice = Console.ReadLine();

                        Console.Write("Inserisci il cognome dell'utente: ");
                        string cognomeUtente = Console.ReadLine();

                        Console.Write("Inserisci il nome dell'utente: ");
                        string nomeUtente = Console.ReadLine();

                        Console.Write("Inserisci la data di inizio prestito [gg/mm/yyyy]: ");
                        string dataInizio = Console.ReadLine();

                        Console.Write("Inserisci la data di fine prestito [gg/mm/yyyy]: ");
                        string dataFine = Console.ReadLine();

                        //Ricerca dell'articolo in prestito
                        List<inPrestito> articoliInPrestito = biblioteca.PrestitiPerCodice(codice);
                        if (articoliInPrestito.Count == 0)
                        {
                            Console.WriteLine($"Nessun articolo trovato con il codice {codice}");
                            break;
                        }

                        //Ricerca dell'utente
                        List<Utente> utenti = biblioteca.CercaUser(nomeUtente, cognomeUtente);
                        if (utenti.Count == 0)
                        {
                            Console.WriteLine($"Nessun utente trovato per {nomeUtente} {cognomeUtente} ");
                            break;
                        }

                        //Aggiunta del prestito
                        biblioteca.PrestitoElem(articoliInPrestito[0], utenti[0], dataInizio, dataFine);
                        Console.WriteLine("Prestito aggiunto con successo!");

                        break;


                    case 3:
                        Console.Write("Inserisci il codice del documento: ");
                        string codicePrestito = Console.ReadLine();

                        List<inPrestito> prestitiCodice = biblioteca.PrestitiPerCodice(codicePrestito);

                        if (prestitiCodice.Count == 0)
                        {
                            Console.WriteLine($"Nessun prestito trovato per il codice {codicePrestito}.");
                        }
                        else
                        {
                            Console.WriteLine($"Trovati {prestitiCodice.Count} prestiti per il codice {codicePrestito}:");
                            foreach (inPrestito prestito in prestitiCodice)
                            {
                                Console.WriteLine($"- {prestito.Titolo}, {prestito.Autore.Nome} {prestito.Autore.Cognome}, settore {prestito.Settore}, scaffale {prestito.Scaffale}");
                            }
                        }

                        break;


                    case 4:

                        Console.Write("Inserisci cognome utente: ");
                        string cognomeUtente2 = Console.ReadLine();

                        Console.Write("Inserisci nome utente: ");
                        string nomeUtente2 = Console.ReadLine();

                        List<Prestito> prestitiUtente = biblioteca.PrestitiPerUtente(nomeUtente2, cognomeUtente2);

                        if (prestitiUtente.Count > 0)
                        {
                            Console.WriteLine($"Prestiti per {nomeUtente2} {cognomeUtente2}:");
                            foreach (var prestito in prestitiUtente)
                            {
                                Console.WriteLine($"- Titolo: {prestito.Documento.Titolo} | Data inizio: {prestito.DataInizio} | Data fine: {prestito.DataFine}");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Nessun prestito trovato per {nomeUtente2} {cognomeUtente2}.");
                        }
                        break;


                    case 5:
                        Console.Write("Inserisci il titolo da cercare: ");
                        string titolo = Console.ReadLine();
                        List<inPrestito> prestitiPerTitolo = biblioteca.PrestitiPerTitolo(titolo);
                        if (prestitiPerTitolo.Count > 0)
                        {
                            Console.WriteLine($"Trovati {prestitiPerTitolo.Count} prestiti:");
                            foreach (inPrestito prestito in prestitiPerTitolo)
                            {
                                Console.WriteLine($"Titolo: {prestito.Titolo}, Codice: {prestito.Codice}");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Nessun prestito trovato per {titolo}.");
                        }
                        break;


                    case 6:
                        Console.WriteLine("Adios!");
                        Environment.Exit(0);
                        break;


                }
            }
        }
    }
}