// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace kursach
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		AppKit.NSTextField ActorsOutlet { get; set; }

		[Outlet]
		AppKit.NSTextField ConcertOutlet { get; set; }

		[Outlet]
		AppKit.NSTextField DeleteItemOutlet { get; set; }

		[Outlet]
		AppKit.NSTableColumn DetailsColumn { get; set; }

		[Outlet]
		AppKit.NSTextField ErrorOutlet { get; set; }

		[Outlet]
		AppKit.NSTextField FilterNameOutlet { get; set; }

		[Outlet]
		AppKit.NSTextField PerfomanceOutlet { get; set; }

		[Outlet]
		AppKit.NSTextField PopularityOutlet { get; set; }

		[Outlet]
		AppKit.NSTableColumn ProductColumn { get; set; }

		[Outlet]
		AppKit.NSTableView ProductTable { get; set; }

		[Outlet]
		AppKit.NSTextField SaveSuccessfullyOutlet { get; set; }

		[Outlet]
		AppKit.NSTextField SeatsOutlet { get; set; }

		[Outlet]
		AppKit.NSTextField TicketPriceOutlet { get; set; }

		[Action ("AddPerfomanceAction:")]
		partial void AddPerfomanceAction (Foundation.NSObject sender);

		[Action ("ClearAllAction:")]
		partial void ClearAllAction (Foundation.NSObject sender);

		[Action ("DeleteItemAction:")]
		partial void DeleteItemAction (Foundation.NSObject sender);

		[Action ("FilterAction:")]
		partial void FilterAction (Foundation.NSObject sender);

		[Action ("FilterCancelAction:")]
		partial void FilterCancelAction (Foundation.NSObject sender);

		[Action ("ReadFromFileAction:")]
		partial void ReadFromFileAction (Foundation.NSObject sender);

		[Action ("SaveInFileAction:")]
		partial void SaveInFileAction (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (ActorsOutlet != null) {
				ActorsOutlet.Dispose ();
				ActorsOutlet = null;
			}

			if (ConcertOutlet != null) {
				ConcertOutlet.Dispose ();
				ConcertOutlet = null;
			}

			if (DeleteItemOutlet != null) {
				DeleteItemOutlet.Dispose ();
				DeleteItemOutlet = null;
			}

			if (DetailsColumn != null) {
				DetailsColumn.Dispose ();
				DetailsColumn = null;
			}

			if (ErrorOutlet != null) {
				ErrorOutlet.Dispose ();
				ErrorOutlet = null;
			}

			if (FilterNameOutlet != null) {
				FilterNameOutlet.Dispose ();
				FilterNameOutlet = null;
			}

			if (PerfomanceOutlet != null) {
				PerfomanceOutlet.Dispose ();
				PerfomanceOutlet = null;
			}

			if (PopularityOutlet != null) {
				PopularityOutlet.Dispose ();
				PopularityOutlet = null;
			}

			if (ProductColumn != null) {
				ProductColumn.Dispose ();
				ProductColumn = null;
			}

			if (ProductTable != null) {
				ProductTable.Dispose ();
				ProductTable = null;
			}

			if (SaveSuccessfullyOutlet != null) {
				SaveSuccessfullyOutlet.Dispose ();
				SaveSuccessfullyOutlet = null;
			}

			if (SeatsOutlet != null) {
				SeatsOutlet.Dispose ();
				SeatsOutlet = null;
			}

			if (TicketPriceOutlet != null) {
				TicketPriceOutlet.Dispose ();
				TicketPriceOutlet = null;
			}
		}
	}
}
