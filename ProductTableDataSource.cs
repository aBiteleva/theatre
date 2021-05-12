﻿using System;
using AppKit;
using CoreGraphics;
using Foundation;
using System.Collections;
using System.Collections.Generic;

namespace kursach
{
    public class ProductTableDataSource : NSTableViewDataSource
    {
        #region Public Variables
        //public Hashtable Products = new Hashtable();
        public List<Comp> Products = new List<Comp>();
        #endregion

        #region Constructors
        public ProductTableDataSource()
        {
        }
        #endregion

        #region Override Methods
        public override nint GetRowCount(NSTableView tableView)
        {
            return Products.Count;
        }
        #endregion
        public void Sort(string key, bool ascending)
        {

            // Take action based on key
            switch (key)
            {
                case "perfomance":
                    if (ascending)
                    {
                        Products.Sort((x, y) => x.perfomance.CompareTo(y.perfomance));
                    }
                    else
                    {
                        Products.Sort((x, y) => -1 * x.perfomance.CompareTo(y.perfomance));
                    }
                    break;
                case "ticketsPrice":
                    if (ascending)
                    {
                        Products.Sort((x, y) => x.ticketsPrice.CompareTo(y.ticketsPrice));
                    }
                    else
                    {
                        Products.Sort((x, y) => -1 * x.ticketsPrice.CompareTo(y.ticketsPrice));
                    }
                    break;
            }

        }

        public override void SortDescriptorsChanged(NSTableView tableView, NSSortDescriptor[] oldDescriptors)
        {
            // Sort the data
            if (oldDescriptors.Length > 0)
            {
                // Update sort
                Sort(oldDescriptors[0].Key, oldDescriptors[0].Ascending);
            }
            else
            {
                // Grab current descriptors and update sort
                NSSortDescriptor[] tbSort = tableView.SortDescriptors;
                Sort(tbSort[0].Key, tbSort[0].Ascending);
            }

            // Refresh table
            tableView.ReloadData();
        }
    }

}