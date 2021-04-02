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
    /// Логика взаимодействия для MoreInfo.xaml
    /// </summary>
    public partial class MoreInfo : Page
    {
        private MainInfoFilm selecteditem;
        public MoreInfo(MainInfoFilm selecteditem)
        {
            InitializeComponent();
            this.selecteditem = selecteditem;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ListMoreInfo.ItemsSource = dbContext.db.MainInfoFilm.Where (item => item.ID == selecteditem.ID && item.idBudgetAndFees == selecteditem.ID && item.idCreators == selecteditem.ID
                            && item.idRentalData == selecteditem.ID && item.idFilmDescription == selecteditem.ID).ToList();
        }
    }
}
