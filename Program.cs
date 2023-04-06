namespace GestionStock
{
    class Article
    {
        public int Reference { get; set; }
        public string Nom { get; set; }
        public double Prix { get; set; }
        public int Quantite { get; set; }

        public Article(int reference, string nom, double prix, int quantite)
        {
            Reference = reference;
            Nom = nom;
            Prix = prix;
            Quantite = quantite;
        }

        public override string ToString()
        {
            return $"Référence: {Reference} | Nom: {Nom} | Prix: {Prix} | Quantité: {Quantite}";
        }
    }

    class Program
    {
        static List<Article> stock = new List<Article>();

        static void Main(string[] args)
        {
            int choix;
            do
            {
                Console.WriteLine("************ GESTION DU STOCK ************");
                Console.WriteLine("1. Rechercher un article par référence.");
                Console.WriteLine("2. Ajouter un article au stock en vérifiant l’unicité de la référence.");
                Console.WriteLine("3. Supprimer un article par référence.");
                Console.WriteLine("4. Modifier un article par référence.");
                Console.WriteLine("5. Rechercher un article par nom.");
                Console.WriteLine("6. Rechercher un article par intervalle de prix de vente.");
                Console.WriteLine("7. Afficher tous les articles.");
                Console.WriteLine("8. Quitter.");
                Console.WriteLine("*******************************************");
                Console.Write("Entrez votre choix : ");
                choix = int.Parse(Console.ReadLine());
                Console.WriteLine();

                switch (choix)
                {
                    case 1:
                        rechercherArticleParReference(stock);
                        break;
                    case 2:
                        ajouterArticle();
                        break;
                    case 3:
                        supprimerArticleParReference(stock);
                        break;
                    case 4:
                        modifierArticleParReference(stock);
                        break;
                    case 5:
                        rechercherArticleParNom(stock);
                        break;
                    case 6:
                        rechercherArticleParIntervallePrix(stock);
                        break;
                    case 7:
                        afficherStock(stock);
                        break;
                    case 8:
                        Console.WriteLine("Au revoir !");
                        break;
                    default:
                        Console.WriteLine("Choix invalide, veuillez réessayer.");
                        break;
                }
                Console.WriteLine();
            } while (choix != 8);
        }

        static void ajouterArticle()
        {
            Console.Write("Entrez la référence de l'article : ");
            int reference = int.Parse(Console.ReadLine());

            if (stock.Any(article => article.Reference == reference))
            {
                Console.WriteLine("Erreur : Il existe déjà un article avec cette référence !");
            }
            else
            {
                Console.Write("Entrez le nom de l'article : ");
                string nom = Console.ReadLine();

                Console.Write("Entrez le prix de vente de l'article : ");
                double prix = double.Parse(Console.ReadLine());

                Console.Write("Entrez la quantité de l'article : ");
                int quantite = int.Parse(Console.ReadLine());

                Article article = new Article(reference, nom, prix, quantite);
                stock.Add(article);
                Console.WriteLine("L'article a été ajouté avec succès !");
            }
        }

        static void modifierArticleParReference(List<Article> stock)
        {
            Console.Write("Veuillez saisir la référence de l'article à modifier : ");
            string refArticle = Console.ReadLine();
            int referenceInt = int.Parse(refArticle);
            Article articleAModifier = stock.Find(a => a.Reference == referenceInt);

            if (articleAModifier != null)
            {
                Console.WriteLine("Article trouvé : ");
                Console.WriteLine(articleAModifier.ToString());

                Console.Write("Veuillez saisir le nouveau nom de l'article : ");
                string nouveauNom = Console.ReadLine();
                articleAModifier.Nom = nouveauNom;

                Console.Write("Veuillez saisir le nouveau prix de vente de l'article : ");
                double nouveauPrix = double.Parse(Console.ReadLine());
                articleAModifier.Prix = nouveauPrix;

                Console.Write("Veuillez saisir la nouvelle quantité en stock de l'article : ");
                int nouvelleQuantite = int.Parse(Console.ReadLine());
                articleAModifier.Quantite = nouvelleQuantite;

                Console.WriteLine("Article modifié avec succès.");
            }
            else
            {
                Console.WriteLine("Aucun article trouvé avec cette référence.");
            }
        }

        static void supprimerArticleParReference(List<Article> stock)
        {
            Console.Write("Entrez la référence de l'article à supprimer : ");
            string reference = Console.ReadLine();
            int referenceInt = int.Parse(reference);
            int index = stock.FindIndex(a => a.Reference == referenceInt);

            if (index >= 0)
            {
                stock.RemoveAt(index);
                Console.WriteLine("L'article a été supprimé du stock.");
            }
            else
            {
                Console.WriteLine("Aucun article avec cette référence n'a été trouvé dans le stock.");
            }
        }

        static void rechercherArticleParNom(List<Article> stock)
        {
            Console.Write("Entrez le nom de l'article à rechercher : ");
            string nomRecherche = Console.ReadLine();

            // Recherche des articles dont le nom contient la chaîne de caractères entrée
            List<Article> resultats = stock.Where(article => article.Nom.ToLower().Contains(nomRecherche.ToLower())).ToList();

            if (resultats.Count == 0)
            {
                Console.WriteLine("Aucun article trouvé.");
            }
            else
            {
                Console.WriteLine($"Résultats pour la recherche '{nomRecherche}' :");

                foreach (Article article in resultats)
                {
                    Console.WriteLine(article.ToString());
                }
            }
        }

        static void rechercherArticleParIntervallePrix(List<Article> stock)
        {
            Console.WriteLine("Rechercher un article par intervalle de prix de vente :");

            Console.Write("Prix minimum : ");
            double prixMin = Convert.ToDouble(Console.ReadLine());

            Console.Write("Prix maximum : ");
            double prixMax = Convert.ToDouble(Console.ReadLine());

            List<Article> articlesTrouves = stock.FindAll(article => article.Prix >= prixMin && article.Prix <= prixMax);

            if (articlesTrouves.Count == 0)
            {
                Console.WriteLine("Aucun article trouvé.");
            }
            else
            {
                Console.WriteLine($"Liste des articles dont le prix de vente est compris entre {prixMin} et {prixMax} :");
                foreach (Article article in articlesTrouves)
                {
                    Console.WriteLine(article);
                }
            }
        }

        public static void afficherStock(List<Article> stock)
        {
            Console.WriteLine("Voici la liste de tous les articles du stock :");
            Console.WriteLine("-------------------------------------------------\n");

            foreach (Article article in stock)
            {
                Console.WriteLine(article.ToString());
            }

            Console.WriteLine("\nFin de la liste.");
        }

        static void rechercherArticleParReference(List<Article> stock)
        {
            Console.WriteLine("Entrez la référence de l'article à rechercher :");
            string reference = Console.ReadLine();
            int referenceInt = int.Parse(reference);

            Article article = stock.Find(match: a => a.Reference == referenceInt);

            if (article != null)
            {
                Console.WriteLine(article.ToString());
            }
            else
            {
                Console.WriteLine("Aucun article trouvé avec cette référence.");
            }
        }
    }
}