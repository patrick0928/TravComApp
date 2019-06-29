using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TravCom.DbLayer;
using TravCom.Helper;
using TravCom.Model;

namespace TravCom.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        string _searchBox_l;
        string _searchBox_r;
        string _recordFound_l;
        string _recordFound_r;
        public ObservableCollection<Invoice> Invoices_Left { get; set; }
        public ObservableCollection<Invoice> Invoices_Right { get; set; }
        InvoiceContext InvoiceContext = new InvoiceContext();
        public RelayCommand SearchCommand_Left { get; set; }
        public RelayCommand SearchCommand_Right { get; set; }
        public string SearchBox_Left
        {
            get { return _searchBox_l; }
            set
            {
                if(_searchBox_l != value)
                {
                    _searchBox_l = value;
                    OnPropertyChanged("SearchBox");
                    if (string.IsNullOrWhiteSpace(SearchBox_Left))
                    {
                        Invoices_Left.Clear();
                        RecordFound_Left = " record/s found";
                    }                      
                }
            }
        }
        public string SearchBox_Right
        {
            get { return _searchBox_r; }
            set
            {
                if (_searchBox_r != value)
                {
                    _searchBox_r = value;
                    OnPropertyChanged("SearchBox");
                    if (string.IsNullOrWhiteSpace(SearchBox_Right))
                    {
                        Invoices_Left.Clear();
                        RecordFound_Left = " record/s found";
                    }
                }
            }
        }
        public string RecordFound_Left
        {
            get { return _recordFound_l; }
            set
            {
                if (_recordFound_l != value)
                {
                    _recordFound_l = value;
                    OnPropertyChanged("RecordFound_Left");
                }
            }
        }
        public string RecordFound_Right
        {
            get { return _recordFound_r; }
            set
            {
                if (_recordFound_r != value)
                {
                    _recordFound_r = value;
                    OnPropertyChanged("RecordFound_Right");
                }
            }
        }
        void SearchLeft(object parameter)
        {         
            Invoices_Left.Clear();
            RecordFound_Left = " record/s found";
            int records = 0;

            if (!string.IsNullOrWhiteSpace(parameter.ToString()))
            {
                int rec;
                bool success = Int32.TryParse(parameter.ToString(), out rec);

                if (success)
                {
                    var query = from t in InvoiceContext.GetInvoices
                                where t.Record == rec
                                select new { t.RecordLocator,
                                             t.Record,
                                             t.InvoiceNumber,
                                             t.IfMenu,
                                             ClientID = t.ProfileNumber,
                                             ClientName = t.ProfileName,
                                             t.InvoiceDate,
                                             t.BookingDate };

                                foreach (var item in query.ToList())
                                {
                                    Invoices_Left.Add(new Invoice
                                    {
                                        IdData = item.Record + item.IfMenu,
                                        Record = item.Record,
                                        IfMenu = item.IfMenu,
                                        RecordLocator = item.RecordLocator,
                                        InvoiceNumber = item.InvoiceNumber,
                                        ProfileNumber = item.ClientID,
                                        ProfileName = item.ClientName,
                                        BookingDate = item.BookingDate,
                                        InvoiceDate = item.InvoiceDate
                                    });
                                    records++;
                                }
                }
                else
                {
                    var query = from t in InvoiceContext.GetInvoices
                                where t.RecordLocator.StartsWith(parameter.ToString()) || t.ProfileName.StartsWith(parameter.ToString())
                                select new{ t.RecordLocator,
                                            t.Record,
                                            t.InvoiceNumber,
                                            t.IfMenu,
                                            ClientID = t.ProfileNumber,
                                            ClientName = t.ProfileName,
                                            t.InvoiceDate,
                                            t.BookingDate };

                                foreach (var item in query.ToList())
                                {
                                    Invoices_Left.Add(new Invoice
                                    {
                                        IdData = item.Record + item.IfMenu,
                                        Record = item.Record,
                                        IfMenu = item.IfMenu,
                                        RecordLocator = item.RecordLocator,   
                                        InvoiceNumber = item.InvoiceNumber,
                                        ProfileNumber = item.ClientID,
                                        ProfileName = item.ClientName,
                                        BookingDate = item.BookingDate,
                                        InvoiceDate = item.InvoiceDate
                                    });
                                    records++;
                                }
                }
                RecordFound_Left = records.ToString() + RecordFound_Left;
            }
        }
        void SearchRight(object parameter)
        {
            Invoices_Right.Clear();
            RecordFound_Right = " record/s found";
            int records = 0;

            if (!string.IsNullOrWhiteSpace(parameter.ToString()))
            {
                int rec;
                bool success = Int32.TryParse(parameter.ToString(), out rec);

                if (success)
                {
                    var query = from t in InvoiceContext.GetInvoices
                                where t.Record == rec
                                select new
                                {
                                    t.RecordLocator,
                                    t.Record,
                                    t.InvoiceNumber,
                                    t.IfMenu,
                                    ClientID = t.ProfileNumber,
                                    ClientName = t.ProfileName,
                                    t.InvoiceDate,
                                    t.BookingDate
                                };

                    foreach (var item in query.ToList())
                    {
                        Invoices_Right.Add(new Invoice
                        {
                            IdData = item.Record + item.IfMenu,
                            Record = item.Record,
                            IfMenu = item.IfMenu,
                            RecordLocator = item.RecordLocator,
                            InvoiceNumber = item.InvoiceNumber,
                            ProfileNumber = item.ClientID,
                            ProfileName = item.ClientName,
                            BookingDate = item.BookingDate,
                            InvoiceDate = item.InvoiceDate
                        });
                        records++;
                    }
                }
                else
                {
                    var query = from t in InvoiceContext.GetInvoices
                                where t.RecordLocator.StartsWith(parameter.ToString()) || t.ProfileName.StartsWith(parameter.ToString())
                                select new
                                {
                                    t.RecordLocator,
                                    t.Record,
                                    t.InvoiceNumber,
                                    t.IfMenu,
                                    ClientID = t.ProfileNumber,
                                    ClientName = t.ProfileName,
                                    t.InvoiceDate,
                                    t.BookingDate
                                };

                    foreach (var item in query.ToList())
                    {
                        Invoices_Right.Add(new Invoice
                        {
                            IdData = item.Record + item.IfMenu,
                            Record = item.Record,
                            IfMenu = item.IfMenu,
                            RecordLocator = item.RecordLocator,
                            InvoiceNumber = item.InvoiceNumber,
                            ProfileNumber = item.ClientID,
                            ProfileName = item.ClientName,
                            BookingDate = item.BookingDate,
                            InvoiceDate = item.InvoiceDate
                        });
                        records++;
                    }
                }
                RecordFound_Right = records.ToString() + RecordFound_Right;
            }
        }
        //CONSTRUCTOR
        public MainViewModel()
        {
            RecordFound_Left = " record/s found";
            RecordFound_Right = " record/s found";
            Invoices_Left = new ObservableCollection<Invoice>();
            Invoices_Right = new ObservableCollection<Invoice>();
            SearchCommand_Left = new RelayCommand(SearchLeft);
            SearchCommand_Right = new RelayCommand(SearchRight);
        }
    }
}
