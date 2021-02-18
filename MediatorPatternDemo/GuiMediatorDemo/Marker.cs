using System;
using System.Drawing;
using System.Windows.Forms;

namespace GuiMediatorDemo
{
    /// <summary>
    /// The marker class is our colleague in the mediator pattern. It has a reference to the mediator but not to other colleagues.
    /// </summary>
    public class Marker :Label
    {
        private MarkerMediator mediator;
        private Point mouseDownLocation;
        
        //Constructor sets some basic props and event handlers for mouse events
        public Marker()
        {
            this.Text = "{Drag me}";
            this.TextAlign = ContentAlignment.MiddleCenter;
            this.MouseDown += OnMouseDown;
            this.MouseMove += OnMouseMove;
        }

        //Sets the mediator for the colleague to the supplied one (called by the mediator itself)
        public void SetMediator(MarkerMediator concreteMediator)
        {
            mediator = concreteMediator;
        }

        //Event handler which records the position of the mouse when the left button is held
        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.mouseDownLocation = e.Location;
            }
        }

        //Event handler that tracks the movement of the mouse
        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Text = this.Location.ToString();
                this.Left = e.X + this.Left - this.mouseDownLocation.X;
                this.Top = e.Y + this.Top - this.mouseDownLocation.Y;
                this.mediator.Send(this.Location, this);
            }
        }

        //ReceiveLocation is sent the locations of OTHER colleagues from the mediator (which this colleague does not know about itself) and reacts to them
        public void ReceiveLocation(Point location)
        {
            var distance = CalcDistance(location);
            if (distance < 100 && this.BackColor != Color.Red)
            {
                this.BackColor = Color.Red;
            }
            else if (distance >= 100 && this.BackColor != Color.Green)
            {
                this.BackColor = Color.Green;
            }

            double CalcDistance(Point location) => Math.Sqrt(Math.Pow(location.X - this.Location.X, 2) + Math.Pow(location.Y - this.Location.Y, 2));
        }

        
    }
}