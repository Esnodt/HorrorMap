using HorrorMap.Context;
using HorrorMap.SQL;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace HorrorMap.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddPage.xaml
    /// </summary>
    public partial class AddPage : Page
    {
        public AddPage()
        {
            InitializeComponent();
            cmbMPAA.ItemsSource = dbContext.db.AgeLimit.Select(item => item.MPAA).ToList();
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {


            MainInfoFilm newMainInfoFilm = new MainInfoFilm();
            Creators newCreators = new Creators();
            BudgetAndFees newBudgetAndFees = new BudgetAndFees();
            FilmDescription newFilmDescription = new FilmDescription();
            RentalData newRentalData = new RentalData();
            AgeLimit newAgeLimit = new AgeLimit();


            newMainInfoFilm.Name = tbName.Text;
            newMainInfoFilm.CountryCreator = tbCountryCreator.Text;
            newMainInfoFilm.Operator = tbOperator.Text;
            newMainInfoFilm.Genres = tbGenres.Text;
            newMainInfoFilm.idCreators = newCreators.ID;
            newMainInfoFilm.idFilmDescription = newFilmDescription.ID;
            newMainInfoFilm.idBudgetAndFees = newBudgetAndFees.ID;
            newMainInfoFilm.idRentalData = newRentalData.ID;
            newMainInfoFilm.idAgeLimit = newAgeLimit.ID;
            MemoryStream stream = new MemoryStream();
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create((BitmapImage)imgLoad.Source));
            encoder.Save(stream);
            newMainInfoFilm.ImageMovie = stream.ToArray();

            var currentType = dbContext.db.AgeLimit.FirstOrDefault(item => item.MPAA == cmbMPAA.Text);
            newMainInfoFilm.ID = currentType.ID;

            newBudgetAndFees.Budget = Convert.ToInt32(tbBudget.Text);
            newBudgetAndFees.WorldwideFees = Convert.ToInt32(tbWorldwideFees.Text);

            newCreators.Director = tbDirector.Text;
            newCreators.Producer = tbProducer.Text;

            newRentalData.PremiereInRussia = (DateTime)tbPremiereInRussia.SelectedDate;
            newRentalData.PremiereInWorld = (DateTime)tbPremiereInWorld.SelectedDate;

            newFilmDescription.Description = tbDescription.Text;

            dbContext.db.BudgetAndFees.Add(newBudgetAndFees);
            
            dbContext.db.Creators.Add(newCreators);
            dbContext.db.AgeLimit.Add(newAgeLimit);
            dbContext.db.RentalData.Add(newRentalData);
            dbContext.db.FilmDescription.Add(newFilmDescription);
            dbContext.db.MainInfoFilm.Add(newMainInfoFilm);

            dbContext.db.SaveChanges();

            MessageBox.Show("Вы успешно добавили данные", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);



        }

        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            tbCountryCreator.Text = "";
            tbBudget.Text = ""; 
            tbDescription.Text = "";
            tbDirector.Text = "";
            tbGenres.Text = "";
            tbProducer.Text = "";
            tbWorldwideFees.Text = "";
            tbName.Text = "";
            tbOperator.Text = "";
            tbPremiereInRussia.Text = "";
            tbPremiereInWorld.Text = "";
            cmbMPAA.Text = null;
            tbPremiereInRussia.SelectedDate = null;
            tbPremiereInWorld.SelectedDate = null; 
            
        }

        private void buttonimage_Click(object sender, RoutedEventArgs e)
        {
            try 
            {
                OpenFileDialog imgFile = new OpenFileDialog();
                imgFile.Filter = "image (*.png *.jpg *.jpeg .jfif) | *.png; *.jpg; *.lpeg; *.jfif";
                if(imgFile.ShowDialog() == true)
                {
                    BitmapImage imgBitmap = new BitmapImage(new Uri(imgFile.FileName));
                    imgLoad.Source = imgBitmap;
                }
            }
            catch
            {
                MessageBox.Show("Что?");
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
