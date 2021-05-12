using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using AppKit;
using Foundation;

namespace kursach
{
    public partial class ViewController : NSViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        { 
            base.ViewDidLoad();
            var alert = new NSAlert()
            {
                AlertStyle = NSAlertStyle.Informational,
                InformativeText = "19ВП1, Бителева А.О., 5 вариант",
                MessageText = "Курсовой проект 'Театр'",
            };
            alert.RunModal();
        }
        ProductTableDataSource DataSource = new ProductTableDataSource();
        public override void AwakeFromNib()
        {
            base.AwakeFromNib();
            ProductTable.DataSource = DataSource;
            ProductTable.Delegate = new ProductTableDelegate(DataSource);
        }

        public override NSObject RepresentedObject
        {
            get
            {
                return base.RepresentedObject;
            }
            set
            {
                base.RepresentedObject = value;
            }
        }

        partial void AddPerfomanceAction(NSObject sender)
        {
            try
            {
                if ((Convert.ToInt32(ActorsOutlet.StringValue) < 0) || (Convert.ToInt32(SeatsOutlet.StringValue) < 0) || (Convert.ToInt32(TicketPriceOutlet.StringValue) < 0)
                    || (Convert.ToInt32(PopularityOutlet.StringValue) < 0))
                {
                    throw new Exception("Отрицательное!");
                }
                else
                {
                    DataSource.Products.Add(new Comp(PerfomanceOutlet.StringValue, ActorsOutlet.IntValue,
                    ConcertOutlet.StringValue, SeatsOutlet.IntValue, TicketPriceOutlet.IntValue, PopularityOutlet.IntValue));
                    ProductTable.ReloadData();
                }
            }
            catch (FormatException)
            {
                var alert = new NSAlert()
                {
                    AlertStyle = NSAlertStyle.Critical,
                    InformativeText = "Вводимые символы должны быть цифрами",
                    MessageText = "Вызвано исключение - неверный формат",
                };
                alert.RunModal();
            }
            catch
            {
                var alert = new NSAlert()
                {
                    AlertStyle = NSAlertStyle.Critical,
                    InformativeText = "Вводимые цифры должны быть положительными",
                    MessageText = "Вызвано исключение - отрицательное число",
                };
                alert.RunModal();
            }
        }

        partial void DeleteItemAction(NSObject sender)
        {
            try
            {
                ErrorOutlet.StringValue = "";
                DataSource.Products.RemoveAt(DeleteItemOutlet.IntValue);
                ProductTable.ReloadData();
            }
            catch (ArgumentOutOfRangeException)
            {
                ErrorOutlet.StringValue = "Элемента с таким номером не существует!";
            }
        }

        partial void FilterAction(NSObject sender)
        {
            ProductTableDataSource DataSource2 = new ProductTableDataSource();
            foreach (var elem in DataSource.Products)
            {
                if (elem.perfomance.Contains(FilterNameOutlet.StringValue))
                {
                    DataSource2.Products.Add(elem);
                }
            }
            ProductTable.DataSource = DataSource2;
            ProductTable.Delegate = new ProductTableDelegate(DataSource2);
            ProductTable.ReloadData();
        }

        partial void FilterCancelAction(NSObject sender)
        {
            ProductTable.DataSource = DataSource;
            ProductTable.Delegate = new ProductTableDelegate(DataSource);
            ProductTable.ReloadData();
        }

        partial void ClearAllAction(NSObject sender)
        {
            DataSource.Products.Clear();
            ProductTable.ReloadData();
        }

        partial void SaveInFileAction(NSObject sender)
        {
            SaveSuccessfullyOutlet.StringValue = "";
            String str = "";
            foreach (var elem in DataSource.Products)
            {
                str += elem.perfomance + ", " + elem.actors + ", " + elem.conсert + ", " + elem.seats + ", "
                    + elem.ticketsPrice + ", " + elem.popularity + ", " + "\n";
            }

            File.WriteAllText("/Users/anastasiabiteleva/projects/kursach/kursach/output.txt", str);
            SaveSuccessfullyOutlet.StringValue = "Сохранено!";
        }

        partial void ReadFromFileAction(NSObject sender)
        {
            SaveSuccessfullyOutlet.StringValue = "";
            string s;
            using (StreamReader sr = File.OpenText("/Users/anastasiabiteleva/projects/kursach/kursach/output.txt")) {
                while ((s = sr.ReadLine()) != null)
                {
                    string[] subs = s.Split(", ");
                    string[] subsLine = s.Split("\n");
                    foreach (var sub in subsLine)
                    {
                        DataSource.Products.Add(new Comp(subs[0], Convert.ToInt32(subs[1]), subs[2], Convert.ToInt32(subs[3]), Convert.ToInt32(subs[4]), Convert.ToInt32(subs[5])));
                        ProductTable.ReloadData();
                    }
                }
            }
        }
    }
}
