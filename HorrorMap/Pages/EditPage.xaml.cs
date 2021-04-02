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
    /// Логика взаимодействия для EditPage.xaml
    /// </summary>
    public partial class EditPage : Page
    {
        private MainInfoFilm selecteditems;
       


        public EditPage(MainInfoFilm selecteditems)
        {
            InitializeComponent();
            this.selecteditems = selecteditems;
            if (selecteditems.ImageMovie != null)
            {
                BitmapImage bitmap = new BitmapImage();
                using (MemoryStream stream = new MemoryStream(selecteditems.ImageMovie))
                {
                    bitmap.BeginInit();
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                    bitmap.StreamSource = stream;
                    bitmap.EndInit();
                }
                imgLoad.Source = bitmap;
            }


            tbName.Text = selecteditems.Name;
            tbCountryCreator.Text = selecteditems.CountryCreator;
            tbOperator.Text = selecteditems.Operator;
            tbGenres.Text = selecteditems.Genres;


            tbBudget.Text = Convert.ToString(selecteditems.BudgetAndFees.Budget);
            tbWorldwideFees.Text = Convert.ToString(selecteditems.BudgetAndFees.WorldwideFees);

            tbDirector.Text = selecteditems.Creators.Director;
            tbProducer.Text = selecteditems.Creators.Producer;

            tbPremiereInRussia.SelectedDate = selecteditems.RentalData.PremiereInRussia;
            tbPremiereInWorld.SelectedDate = selecteditems.RentalData.PremiereInWorld;

            tbDescription.Text = selecteditems.FilmDescription.Description;

            cmbMPAA.ItemsSource = dbContext.db.AgeLimit.Select(item => item.MPAA).ToList();
        }




        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            MainInfoFilm Save = dbContext.db.MainInfoFilm.FirstOrDefault(item => item.ID == selecteditems.ID);

            Save.Name = tbName.Text;
            Save.CountryCreator = tbCountryCreator.Text;
            Save.Operator = tbOperator.Text;
            Save.Genres = tbGenres.Text;

            MemoryStream stream = new MemoryStream();
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create((BitmapImage)imgLoad.Source));
            encoder.Save(stream);
            Save.ImageMovie = stream.ToArray();
            var edcmbMPAA = dbContext.db.AgeLimit.FirstOrDefault(item => item.MPAA == cmbMPAA.Text);

            Save.BudgetAndFees.Budget = Convert.ToInt32(tbBudget.Text);
            Save.BudgetAndFees.WorldwideFees = Convert.ToInt32(tbWorldwideFees.Text);

            Save.Creators.Director = tbDirector.Text;
            Save.Creators.Producer = tbProducer.Text;

            Save.RentalData.PremiereInRussia = tbPremiereInRussia.SelectedDate;
            Save.RentalData.PremiereInWorld = tbPremiereInWorld.SelectedDate;

            Save.FilmDescription.Description = tbDescription.Text;

            dbContext.db.SaveChanges();
            MessageBox.Show("Данные успешно изменены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);

            NavigationService.GoBack();

        }


        


        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }








        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonimage_Click(object sender, RoutedEventArgs e)
        {
            {
                OpenFileDialog fileImg = new OpenFileDialog();
                fileImg.Filter = "Image (*.png; *.jpg; *.jpeg;) | *.png; *.jpg; *.jpeg;";
                if (fileImg.ShowDialog() == true)
                {
                    BitmapImage imgBitmap = new BitmapImage(new Uri(fileImg.FileName));
                    imgLoad.Source = imgBitmap;
                }
            }
        }
    }
}
