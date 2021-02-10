using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace GuiMediatorDemo
{
    public class MarkerMediator
    {
        //Collection of colleagues
        private List<Marker> markers = new List<Marker>();

        /// <summary>
        /// CreateMarker creates a new colleague and adds it to the list of colleagues, and also sets the mediator on the new colleague to itself.
        /// </summary>
        /// <returns>Newly minted Marker instance</returns>
        public Marker CreateMarker()
        {
            var m = new Marker();
            m.SetMediator(this);
            this.markers.Add(m);
            return m;
        }

        /// <summary>
        /// Send is used to receive a colleague's location, and to broadcast it to other colleagues except the sender
        /// </summary>
        /// <param name="location"></param>
        /// <param name="marker"></param>
        public void Send(Point location, Marker marker)
        {
            this.markers.Where(m => m != marker).ToList().ForEach(m => m.ReceiveLocation(location));
        }
    }
}
