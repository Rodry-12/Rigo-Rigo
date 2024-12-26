namespace RigoRigo.Model
{
    public class Producto
    {
        private int _id;
        private string _nombre;
        private decimal _precio;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public decimal Precio
        {
            get { return _precio; }
            set { _precio = value; }
        }
    }
}