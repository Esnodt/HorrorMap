using HorrorMap.Context;
using HorrorMap.SQL;
using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }




        private void ListMain_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            {
                try
                {
                    MainInfoFilm infoGame = (MainInfoFilm)ListMain.SelectedItem;
                    if (infoGame != null)
                    {
                        NavigationService.Navigate(new MoreInfo(infoGame));
                    }
                    else
                    {
                        throw new Exception("Выберите элемент!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.Source, MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddPage());
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ListMain.ItemsSource = dbContext.db.MainInfoFilm.ToList();

        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MainInfoFilm EditFilm = (MainInfoFilm)ListMain.SelectedItem;

                if (EditFilm != null)
                {
                    NavigationService.Navigate(new EditPage(EditFilm));
                }

                else
                {
                    MessageBox.Show("Вы не выбрали строку которую хотите изменить", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

                }

            }

            catch
            {

            }

        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MainInfoFilm deleteMainInfoFilm = (MainInfoFilm)ListMain.SelectedItem;

                if (deleteMainInfoFilm != null)
                {
                    if (MessageBox.Show("Вы уверены, что хотите удалить элемент?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        {
                            dbContext.db.MainInfoFilm.Remove(deleteMainInfoFilm);
                            dbContext.db.SaveChanges();
                            Page_Loaded(null, null);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Вы не выбрали ни одного элемента!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButton.OK, MessageBoxImage.Error); 
            }
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListMain.ItemsSource = dbContext.db.MainInfoFilm.Where(item => item.Genres.Contains(tbSearch.Text)).ToList();
        }
    }
}
