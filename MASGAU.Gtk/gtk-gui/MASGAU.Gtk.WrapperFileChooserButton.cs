
// This file has been generated by the GUI designer. Do not modify.
namespace MASGAU.Gtk
{
	public partial class WrapperFileChooserButton
	{
		private global::Gtk.FileChooserButton filechooserbutton1;
		
		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget MASGAU.Gtk.WrapperFileChooserButton
			global::Stetic.BinContainer.Attach (this);
			this.Name = "MASGAU.Gtk.WrapperFileChooserButton";
			// Container child MASGAU.Gtk.WrapperFileChooserButton.Gtk.Container+ContainerChild
			this.filechooserbutton1 = new global::Gtk.FileChooserButton (global::Mono.Unix.Catalog.GetString ("Select a File"), ((global::Gtk.FileChooserAction)(2)));
			this.filechooserbutton1.Name = "filechooserbutton1";
			this.Add (this.filechooserbutton1);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.Hide ();
			this.filechooserbutton1.SelectionChanged += new global::System.EventHandler (this.OnFilechooserbutton1SelectionChanged);
		}
	}
}