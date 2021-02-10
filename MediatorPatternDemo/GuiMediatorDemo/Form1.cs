using System;
using System.Windows.Forms;

namespace GuiMediatorDemo
{
    public partial class Form1 : Form
    {
        private MarkerMediator mediator = new MarkerMediator();
        private Button addButton;

        public Form1()
        {
            InitializeComponent();
            this.addButton = new Button();
            this.addButton.Click += OnAddClick;
            this.addButton.Text = "Add marker";
            this.addButton.Dock = DockStyle.Bottom;
            this.Controls.Add(this.addButton);

        }

        private void OnAddClick(object sender, EventArgs e)
        {
            //Via the mediator, create a new marker
            var m = this.mediator.CreateMarker();

            //Add the new marker to the screen
            this.Controls.Add(m);
        }
    }
}
