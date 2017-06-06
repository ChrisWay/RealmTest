using Realms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RealmTest
{
    public partial class MainPage : ContentPage
    {
        public MainPage() {
            var realm = Realm.GetInstance();
            var ship = new Ship { Captain = new Captain() };
            BindingContext = ship;
            realm.Write(() =>
                realm.Add(ship)
            );
            InitializeComponent();
        }
    }

    public class Ship : RealmObject
    {
        public Captain Captain { get; set; }
    }

    public class Captain : RealmObject
    {
        protected override void OnPropertyChanged(string propertyName) => Debug.WriteLine(propertyName);
        public string Name { get; set; }

        [Backlink(nameof(Ship.Captain))]
        public IQueryable<Ship> Ships { get; }
        public string Age { get; set; }
    }
}
