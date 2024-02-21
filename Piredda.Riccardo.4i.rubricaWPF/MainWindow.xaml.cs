using System;
using System.IO;
using System.Windows;
using System.Collections.Generic;
using System.Linq;

namespace Piredda.Riccardo._4i.rubricaWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private Contatti _tuttiIContatti;
        private List<Contatto> _itemSourceContatti;
        private Persone _itemSourcePersone;


        public List<Contatto> ItemSourceContatti { get => this._itemSourceContatti; }
        public Persone ItemSourcePersone { get => this._itemSourcePersone; }

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            // Tutta la roba va inserita all'interno dell'evento Loaded della MainWindow.
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Siccome l'apertura di un file può causare un'eccezione per diversi motivi
            try
            {
                this._itemSourceContatti = new();
            
                
                this._tuttiIContatti = new("Contatti.csv");
                
                this._itemSourcePersone = new("Persone.csv");
                StatusBar.Text = $"Trovati {this._tuttiIContatti.Count} contatti e {this._itemSourcePersone.Count} persone";

            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }

            GrigliaContatti.ItemsSource = this.ItemSourceContatti;
            GrigliaPersone.ItemsSource = this.ItemSourcePersone;
        }

        private void GrigliaContatti_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            //StatusBar.Text = $"Contatto selezionato: {((Contatto)e.AddedItems[0]).Nome}";
        }
        private void GrigliaPersone_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            this._itemSourceContatti.Clear();
            Persona p = e.AddedItems[0] as Persona;
            this._itemSourceContatti = new Contatti(this._tuttiIContatti.Where(t => t.IdPersona == p.PK));

            GrigliaContatti.ItemsSource = this.ItemSourceContatti;
        }
    }

    public class Persone : List<Persona>
    {
        public Persone(string PathPersone)
        {

            using (StreamReader sr = new(PathPersone))
            {
                sr.ReadLine();
                string riga = string.Empty;

                while (!sr.EndOfStream)
                    this.Add(new Persona(sr.ReadLine()));

                sr.Close();
            }
        }
    }

    public class Contatti : List<Contatto> 
    {
        public Contatti(string ContattiPath) : base()
        {
            using (StreamReader sr = new(ContattiPath))
            {
                sr.ReadLine();
                string riga = string.Empty;

                while (!sr.EndOfStream)
                    this.Add(Contatto.CreaEreditante(sr.ReadLine()));

                sr.Close();
            }
        }
        public Contatti(IEnumerable<Contatto> s) : base(s)
        { }
    }
}
