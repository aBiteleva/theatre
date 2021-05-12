using System;
using AppKit;
using CoreGraphics;
using Foundation;
using System.Collections;
using System.Collections.Generic;

namespace kursach
{
    public class ProductTableDelegate : NSTableViewDelegate
    {
        #region Constants 
        private const string CellIdentifier = "ProdCell";
        #endregion

        #region Private Variables
        private ProductTableDataSource DataSource;
        #endregion

        #region Constructors
        public ProductTableDelegate(ProductTableDataSource datasource)
        {
            this.DataSource = datasource;
        }
        #endregion

        #region Override Methods
        
    public override NSView GetViewForItem(NSTableView tableView, NSTableColumn tableColumn, nint row)
        {
            // This pattern allows you reuse existing views when they are no-longer in use.
            // If the returned view is null, you instance up a new view
            // If a non-null view is returned, you modify it enough to reflect the new data
            NSTextField view = (NSTextField)tableView.MakeView(tableColumn.Title, this);
            if (view == null)
            {
                view = new NSTextField();
                view.Identifier = tableColumn.Title;
                view.BackgroundColor = NSColor.Clear;
                view.Bordered = false;
                view.Selectable = false;
                view.Editable = true;

                view.EditingEnded += (sender, e) => {

                    // Take action based on type
                    switch (view.Identifier)
                    {
                        case "Название спектакля":
                            ((Comp)DataSource.Products[(int)view.Tag]).perfomance = view.StringValue;
                            break;
                        case "Количество актеров":
                            ((Comp)DataSource.Products[(int)view.Tag]).actors = view.IntValue;
                            break;
                        case "Концерт":
                            ((Comp)DataSource.Products[(int)view.Tag]).conсert = view.StringValue;
                            break;
                        case "Количество мест":
                            ((Comp)DataSource.Products[(int)view.Tag]).seats = view.IntValue;
                            break;
                        case "Цена билетов":
                            ((Comp)DataSource.Products[(int)view.Tag]).ticketsPrice = view.IntValue;
                            break;
                        case "Популярность посещения":
                            ((Comp)DataSource.Products[(int)view.Tag]).popularity = view.IntValue;
                            break;
                    }
                };
            }

            // Tag view
            view.Tag = row;

            // Setup view based on the column selected
            switch (tableColumn.Title)
            {
                case "Название спектакля":
                    view.StringValue = ((Comp)DataSource.Products[(int)row]).perfomance;
                    break;
                case "Количество актеров":
                    view.IntValue = ((Comp)DataSource.Products[(int)row]).actors;
                    break;
                case "Концерт":
                    view.StringValue = ((Comp)DataSource.Products[(int)row]).conсert;
                    break;
                case "Количество мест":
                    view.IntValue = ((Comp)DataSource.Products[(int)row]).seats;
                    break;
                case "Цена билетов":
                    view.IntValue = ((Comp)DataSource.Products[(int)row]).ticketsPrice;
                    break;
                case "Популярность посещения":
                    view.DoubleValue = ((Comp)DataSource.Products[(int)row]).popularity;
                    break;
            }

            return view;
        }
        #endregion

        public override bool ShouldSelectRow(NSTableView tableView, nint row)
        {
            return true;
        }

        public override nint GetNextTypeSelectMatch(NSTableView tableView, nint startRow, nint endRow, string searchString)
        {
            nint row = 0;
            foreach (Comp product in DataSource.Products)
            {
                if (product.perfomance.Contains(searchString)) return row;

                // Increment row counter
                ++row;
            }

            // If not found select the first row
            return 0;
        }
    }
}

//using System;
//using AppKit;
//using CoreGraphics;
//using Foundation;
//using System.Collections;
//using System.Collections.Generic;

//namespace kursach
//{
//    public class ProductTableDelegate : NSTableViewDelegate
//    {
//        #region Constants 
//        private const string CellIdentifier = "ProdCell";
//        #endregion

//        #region Private Variables
//        private ProductTableDataSource DataSource;
//        #endregion

//        #region Constructors
//        public ProductTableDelegate(ProductTableDataSource datasource)
//        {
//            this.DataSource = datasource;
//        }
//        #endregion

//        #region Override Methods
//        public override NSView GetViewForItem(NSTableView tableView, NSTableColumn tableColumn, nint row)
//        {
//            // This pattern allows you reuse existing views when they are no-longer in use.
//            // If the returned view is null, you instance up a new view
//            // If a non-null view is returned, you modify it enough to reflect the new data
//            NSTextField view = (NSTextField)tableView.MakeView(CellIdentifier, this);
//            if (view == null)
//            {
//                view = new NSTextField();
//                view.Identifier = CellIdentifier;
//                view.BackgroundColor = NSColor.Clear;
//                view.Bordered = false;
//                view.Selectable = false;
//                view.Editable = false;
//            }

//            // Setup view based on the column selected
//            switch (tableColumn.Title)
//            {
//                case "Product":
//                    view.StringValue = DataSource.Products[(int)row].Title;
//                    break;
//                case "Details":
//                    view.StringValue = DataSource.Products[(int)row].Description;
//                    break;
//            }

//            return view;
//        }
//        #endregion
//    }
//}