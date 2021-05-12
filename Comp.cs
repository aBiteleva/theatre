using System;
namespace kursach
{
    public class Comp
    {
        static public int count = 0;
        public string perfomance;           //Название спектакля
        public int actors;                  //Количество актеров
        public string conсert;              //Концерт
        public int seats;                   //Количество мест
        public int ticketsPrice;            //Цена билетов
        public double popularity;           //Популярность посещения

        public Comp()
        {
            perfomance = "Нет названия";
            actors = 0;
            conсert = "";
            seats = 0;
            ticketsPrice = 0;
            popularity = 0;
        }
        public Comp(string name)
        {
            perfomance = name;
            actors = 0;
            conсert = "";
            seats = 0;
            ticketsPrice = 0;
            popularity = 0;
        }
        public Comp(string name, int number)
        {
            perfomance = name;
            actors = number;
            conсert = "";
            seats = 0;
            ticketsPrice = 0;
            popularity = 0;
        }
        public Comp(string perf, int act, string conc, int s, int tick, double p)
        {
            perfomance = perf;
            actors = act;
            conсert = conc;
            seats = s;
            ticketsPrice = tick;
            popularity = p;
        }
        public string getPerfomance()
        {
            return this.perfomance;
        }
        private void setPerfomance(string d)
        {
            this.perfomance = d;
        }
        public int getActors()
        {
            return this.actors;
        }
        private void setActors(string d)
        {
            int n = System.Convert.ToInt32(d);
            this.actors = n;
        }
        public string getConсert()
        {
            return this.conсert;
        }
        private void setConсert(string d)
        {
            this.conсert = d;
        }
        public int getSeats()
        {
            return this.seats;
        }
        private void setSeats(String d)
        {
            int n = System.Convert.ToInt32(d);
            this.seats = n;
        }
        public int getTicketPrice()
        {
            return this.ticketsPrice;
        }
        private void setTicketPrice(String d)
        {
            int n = System.Convert.ToInt32(d);
            this.ticketsPrice = n;
        }
        public double getPopularity()
        {
            return this.popularity;
        }
        private void setPopularity(String d)
        {
            double n = System.Convert.ToDouble(d);
            this.popularity = n;
        }
       
        public String changeField(String field, String newValue)
        {
            String str = "";
            switch (field)
            {
                case "Название спектакля":
                    this.setPerfomance(newValue);
                    str = this.ToString() + "\n";
                    break;
                case "Количество жильцов":
                    this.setActors(newValue);
                    str = this.ToString() + "\n";
                    break;
                case "Концерт":
                    this.setConсert(newValue);
                    str = this.ToString() + "\n";
                    break;
                case "Количество мест":
                    this.setSeats(newValue);
                    str = this.ToString() + "\n";
                    break;
                case "Цена билетов":
                    this.setTicketPrice(newValue);
                    str = this.ToString() + "\n";
                    break;
                case "Популярность посещения":
                    this.setPopularity(newValue);
                    str = this.ToString() + "\n";
                    break;
                default:
                    str = "Нет такого поля!\n";
                    break;
            }
            return str;
        }
    }
}
