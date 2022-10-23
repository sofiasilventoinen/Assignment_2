using Assignment_2.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Assignment_2
{
    
    public partial class MainWindow : Window
    {
        //Visar att det ska finnas en lista som heter contacts
        private ObservableCollection<ContactPerson> contacts;

        public MainWindow()
        {
            InitializeComponent();
            //Skapar en lista som heter contacts
            contacts = new ObservableCollection<ContactPerson>();
            lv_Contacts.ItemsSource = contacts;
        }

        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {
            //metod som kollar att emailadress inte redan finns
            var contact = contacts.FirstOrDefault(x => x.Email == tb_Email.Text);
            if (contact == null)
            {
                //min metod som lägger till kontakt i listan
                contacts.Add(new ContactPerson
                {
                    FirstName = tb_FirstName.Text,
                    LastName = tb_LastName.Text,
                    Email = tb_Email.Text,
                });
            }
            //om det finns en likadan mailadress registrerad visas detta meddelande
            else
            {
                MessageBox.Show("There is already a contact registered with this email");
            }

            ClearFields();

        }

        //min metod för att tömma kontaktfältet
        private void ClearFields()
        {
            tb_FirstName.Text = "";
            tb_LastName.Text = "";
            tb_Email.Text = "";
        }

        //Min metod för att radera en kontakt
        private void btn_Remove_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var contact = (ContactPerson)button!.DataContext;

            contacts.Remove(contact);
            ClearFields();
        }


        //Min metod för att se detaljerad vy av kontakt
        private void lv_Contacts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try //här lade jag in en try/catch då systemet kraschade utan den.
            {
                var contact = (ContactPerson)lv_Contacts.SelectedItems[0]!;
                tb_FirstName.Text = contact.FirstName;
                tb_LastName.Text = contact.LastName;
                tb_Email.Text = contact.Email;
            }
            catch { }
        }
    }
}
