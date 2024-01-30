using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Homework
{
    public class Bus
    {
        private int kav;
        private double price;
        private Node<Station> stations;
        public void SetKav(int kav)
        { this.kav = kav; }
        public void SetPrice(double price)
        {
             this.price = price;
        }

        public double CanArrive(Station start,Station end)
        {
            Node<Station> current = stations;
            double price = 0;
            while(current != null&&start!=current.GetValue())
            {
                current=current.GetNext();
            }
            while(current!=null&&current.GetValue()!=end)
            {
                price += this.price;
                current = current.GetNext();
            }
            if(current==null)
            {
                return -1;
            }
            return price;
        }

    }
}
